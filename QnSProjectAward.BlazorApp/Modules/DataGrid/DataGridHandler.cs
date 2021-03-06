//@QnSCodeCopy
//MdStart
using CommonBase.Extensions;
using CommonBase.Validator;
using Microsoft.AspNetCore.Components.Forms;
using QnSProjectAward.BlazorApp.Models;
using QnSProjectAward.BlazorApp.Pages;
using QnSProjectAward.BlazorApp.Shared.Components;
using Radzen;
using Radzen.Blazor;
using System;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;

namespace QnSProjectAward.BlazorApp.Modules.DataGrid
{
    public partial class DataGridHandler<TContract, TModel> : ComponentHandler, IDisposable, IDataGridHandler<TModel>
        where TContract : Contracts.IIdentifiable, Contracts.ICopyable<TContract>
        where TModel : IdentityModel, TContract, new()
    {
        #region EventHandler
        public event EventHandler<LoadDataArgs> BeforeLoadDataHandler;

        public event EventHandler<TModel[]> LoadModelDataHandler;

        public event EventHandler<TModel> BeforeRowSelectedHandler;
        public event EventHandler<TModel> AfterRowSelectedHandler;

        public event EventHandler<TModel> BeforeRowCollapseHandler;
        public event EventHandler<TModel> AfterRowCollapseHandler;

        public event EventHandler<TModel> BeforeRowExpandHandler;
        public event EventHandler<TModel> AfterRowExpandHandler;

        public event EventHandler<TModel> AfterCreateModelHandler;

        public event EventHandler<TModel> BeforeInsertModelHandler;
        public event EventHandler<TModel> AfterInsertModelHandler;

        public event EventHandler<TModel> BeforeUpdateModelHandler;
        public event EventHandler<TModel> AfterUpdateModelHandler;

        public event EventHandler<TModel> BeforeDeleteModelHandler;
        public event EventHandler<TModel> AfterDeleteModelHandler;

        public event EventHandler<TModel> BeforeEditModelHandler;
        public event EventHandler<TModel> AfterEditModelHandler;
        #endregion EventHandler

        #region Fields
        private bool allowAdd = true;
        private bool allowEdit = true;
        private bool allowDelete = true;
        private bool allowInlineEdit = true;
        private string[] modelItems = null;
        private DataAccess<TContract> dataAccess;
        private volatile bool loadDataActive = false;
        private bool hasFieldChanged;
        private bool disposedValue;
        #endregion Fields

        public RadzenGrid<TModel> RadzenGrid { get; set; }
        public EditContext EditContext { get; protected set; }
        public ModelPage ModelPage { get; init; }
        public DataAccess<TContract> DataAccess
        {
            get
            {
                if (ModelPage != null
                    && ModelPage.AuthorizationSession != null
                    && dataAccess != null)
                {
                    dataAccess.SessionToken = ModelPage.AuthorizationSession.Token;
                }
                return dataAccess;
            }
            init => dataAccess = value;
        }

        public virtual string ForPrefix => typeof(TModel).Name;
        public Func<string, string> Translate { get; init; }
        public string TranslateFor(string key) => Translate($"{ForPrefix}.{key}");

        public Action<NotificationMessage> ShowNotification { get; set; }
        public Func<Task> ShowEditItemDialogAsync { get; set; }
        public Func<Task> ShowConfirmDeleteDialogAsync { get; set; }

        public DataGridHandler(ModelPage modelPage)
        {
            Constructing();
            modelPage.CheckArgument(nameof(modelPage));

            ModelPage = modelPage;
            DataAccess = new DataAdapterAccess<TContract>(ModelPage.ServiceAdapter.Create<TContract>());
            Translate = ModelPage.Translate;
            Constructed();
        }
        public DataGridHandler(ModelPage modelPage, DataAccess<TContract> dataAccess)
        {
            Constructing();
            modelPage.CheckArgument(nameof(modelPage));
            dataAccess.CheckArgument(nameof(dataAccess));

            ModelPage = modelPage;
            DataAccess = dataAccess;
            Translate = ModelPage.Translate;
            Constructed();
        }
        protected virtual void Constructing()
        {
        }
        protected virtual void Constructed()
        {
        }

        public int Count { get; protected set; }
        public string AccessFilter { get; set; }

        public int PageSize { get; set; } = 50;
        public bool Editable 
        {
            get; 
            set; 
        } = true;
        public bool AllowAdd 
        {
            get => Editable && allowAdd;
            set => allowAdd = value; 
        }
        public bool AllowEdit
        {
            get => Editable && allowEdit;
            set => allowEdit = value;
        }
        public bool AllowDelete
        {
            get => Editable && allowDelete;
            set => allowDelete = value;
        }
        public bool AllowInlineEdit
        {
            get => Editable && allowInlineEdit;
            set => allowInlineEdit = value;
        }

        public bool AllowPaging { get; set; } = true;
        public bool AllowSorting { get; set; } = true;
        public bool AllowFiltering { get; set; } = true;
        public bool HasRowDetail { get; set; } = true;
        public bool HasNavigation { get; set; } = true;

        public int From { get; protected set; }
        public int To { get; protected set; }

        public string[] ModelItems
        {
            get => modelItems ?? Array.Empty<string>();
            set => modelItems = value ?? Array.Empty<string>();
        }

        public TModel[] Models { get; protected set; }
        public TModel ExpandModel { get; protected set; }
        public TModel SelectedModel { get; protected set; }
        public TModel EditModel { get; protected set; }
        public TModel DeleteModel { get; protected set; }

        protected virtual bool IsModelOrder(string orderBy)
        {
            return orderBy.HasContent() && ModelItems.Any(e => orderBy.Contains(e));
        }
        protected virtual string GetGridAccessFilter(string filter)
        {
            var result = new StringBuilder();

            foreach (var item in filter.Split("and"))
            {
                if (ModelItems.Any(e => item.Contains(e)) == false)
                {
                    if (result.Length > 0)
                        result.Append(" and ");

                    result.Append(item.Trim());
                }
            }
            return result.ToString();
        }
        protected virtual string GetGridModelFilter(string filter)
        {
            var result = new StringBuilder();

            foreach (var item in filter.Split("and"))
            {
                if (ModelItems.Any(e => item.Contains(e)))
                {
                    if (result.Length > 0)
                        result.Append(" and ");

                    var newFilter = item.Replace(".Contains", ".ToLower().Contains");
                    var tags = newFilter.GetAllTags(".Contains(", ")");

                    if (tags != null && tags.Count() == 1)
                    {
                        var tag = tags.ElementAt(0);

                        newFilter = tag.GetText($"{tag.InnerText}.ToLower()");
                    }
                    result.Append(newFilter.Trim());
                }
            }
            return result.ToString();
        }

        protected virtual bool ValidateModel(ModelObject model)
        {
            model.CheckArgument(nameof(model));

            var result = true;

            foreach (var item in ModelValidator.Validate(model))
            {
                result = false;
                var message = string.Format(Translate(item.Message), item.Parameters.Select(e => Translate(e.ToString())).ToArray());

                ShowError("Validate model", message);
            }
            return result;
        }

        protected Task InvokePageAsync(Action action)
        {
            return ModelPage.InvokePageAsync(action);
        }

        #region Model operations
        protected virtual TModel ToModel(TContract entity)
        {
            var handled = false;
            var model = new TModel();

            BeforeToModel(entity, model, ref handled);
            if (handled == false)
            {
                model.CopyProperties(entity);
            }
            AfterToModel(model);
            return model;
        }
        partial void BeforeToModel(TContract entity, TModel model, ref bool handled);
        partial void AfterToModel(TModel model);

        public Task ReloadDataAsync()
        {
            Task result;

            Models = Array.Empty<TModel>();
            if (RadzenGrid != null)
            {
                result = RadzenGrid.Reload();
            }
            else
            {
                result = Task.FromResult(0);
            }
            return result;
        }
        public async Task ReloadDataAsync(TModel model)
        {
            model.CheckArgument(nameof(model));

            await ReloadDataAsync().ConfigureAwait(false);

            var item = RadzenGrid.Data.FirstOrDefault(m => m.Id == model.Id);

            if (item != null)
            {
                await InvokePageAsync(() => RadzenGrid.SelectRow(item)).ConfigureAwait(false);
            }
        }
        public void ReloadModel(TModel model)
        {
            model.CheckArgument(nameof(model));

            var item = RadzenGrid.Data.FirstOrDefault(m => m.Id == model.Id);

            if (item != null)
            {
                item.CopyFrom(model);
            }
        }

        public bool IsLoadDataActive => loadDataActive;
        public virtual async Task LoadDataAsync(LoadDataArgs args)
        {
            if (DataAccess != null && loadDataActive == false)
            {
                try
                {
                    bool handled;

                    loadDataActive = true;
                    PrepareLoadDataArgs(args);
                    BeforeLoadDataHandler?.Invoke(this, args);
                    handled = await BeforeLoadDataAsync(args).ConfigureAwait(false);
                    if (handled == false && ModelPage.AuthorizationSession != null)
                    {
                        var pageIndex = args.Skip / args.Top;
                        var skip = pageIndex.GetValueOrDefault() * PageSize;
                        var orderBy = default(string);
                        var accessFilter = AccessFilter;
                        var modelFilter = default(string);

                        SelectedModel = null;
                        if (string.IsNullOrWhiteSpace(args.Filter) == false)
                        {
                            var gridAccessFilter = GetGridAccessFilter(args.Filter);

                            if (gridAccessFilter.HasContent())
                            {
                                if (accessFilter.HasContent() == false)
                                {
                                    accessFilter = $"{gridAccessFilter}";
                                }
                                else
                                {
                                    accessFilter = $"{accessFilter} and {gridAccessFilter}";
                                }
                            }

                            modelFilter = GetGridModelFilter(args.Filter);
                        }
                        if (string.IsNullOrWhiteSpace(args.OrderBy) == false)
                        {
                            orderBy = args.OrderBy;
                        }
                        // A:
                        if (accessFilter.HasContent() == false
                          && modelFilter.HasContent() == false
                          && orderBy.HasContent() == false)
                        {
                            Count = await DataAccess.CountAsync()
                                           .ConfigureAwait(false);
                            var query = (await DataAccess.GetPageListAsync(pageIndex.GetValueOrDefault(), PageSize)
                                           .ConfigureAwait(false))
                                           .Select(e => ToModel(e))
                                           .ToArray();
                            var saveCount = query.Length;
                            query = await QueriedDataAsync(query).ConfigureAwait(false);
                            LoadModelDataHandler?.Invoke(this, query);
                            Models = query;
                            Count = Count + query.Length - saveCount;
                        }
                        // B:
                        else if (accessFilter.HasContent()
                             && modelFilter.HasContent() == false
                             && orderBy.HasContent() == false)
                        {
                            Count = await DataAccess.CountByAsync(accessFilter)
                                           .ConfigureAwait(false);
                            var query = (await DataAccess.QueryPageListAsync(accessFilter, pageIndex.GetValueOrDefault(), PageSize)
                                           .ConfigureAwait(false))
                                           .Select(e => ToModel(e))
                                           .ToArray();
                            var saveCount = query.Length;
                            query = await QueriedDataAsync(query).ConfigureAwait(false);
                            LoadModelDataHandler?.Invoke(this, query);
                            Models = query;
                            Count = Count + query.Length - saveCount;
                        }
                        // C:
                        else if (accessFilter.HasContent()
                             && modelFilter.HasContent() == false
                             && orderBy.HasContent()
                             && IsModelOrder(orderBy) == false)
                        {
                            Count = await DataAccess.CountByAsync(accessFilter)
                                           .ConfigureAwait(false);
                            var query = (await DataAccess.QueryPageListAsync(accessFilter, pageIndex.GetValueOrDefault(), PageSize)
                                           .ConfigureAwait(false))
                                           .Select(e => ToModel(e))
                                           .ToArray();
                            var saveCount = query.Length;
                            query = await QueriedDataAsync(query).ConfigureAwait(false);
                            LoadModelDataHandler?.Invoke(this, query);
                            Models = query.AsQueryable()
                                    .OrderBy(orderBy)
                                    .ToArray();
                            Count = Count + query.Length - saveCount;
                        }
                        // D:
                        else if (accessFilter.HasContent()
                             && modelFilter.HasContent() == false
                             && orderBy.HasContent()
                             && IsModelOrder(orderBy))
                        {
                            Count = await DataAccess.CountByAsync(accessFilter)
                                           .ConfigureAwait(false);
                            var query = (await DataAccess.QueryPageListAsync(accessFilter, pageIndex.GetValueOrDefault(), PageSize)
                                           .ConfigureAwait(false))
                                           .Select(e => ToModel(e))
                                           .ToArray();
                            var saveCount = query.Length;
                            query = await QueriedDataAsync(query).ConfigureAwait(false);
                            LoadModelDataHandler?.Invoke(this, query);
                            Models = query.AsQueryable()
                                    .OrderBy(orderBy)
                                    .ToArray();
                            Count = Count + query.Length - saveCount;
                        }
                        // E:
                        else if (accessFilter.HasContent()
                             && modelFilter.HasContent()
                             && orderBy.HasContent() == false)
                        {
                            var query = (await DataAccess.QueryAllAsync(accessFilter)
                                            .ConfigureAwait(false))
                                            .Select(e => ToModel(e))
                                            .ToArray();
                            query = await QueriedDataAsync(query).ConfigureAwait(false);
                            LoadModelDataHandler?.Invoke(this, query);
                            var modelQuery = query.AsQueryable()
                                        .Where(modelFilter);
                            Count = modelQuery.Count();
                            Models = modelQuery.Skip(skip).Take(PageSize).ToArray();
                        }
                        // F:
                        else if (accessFilter.HasContent()
                             && modelFilter.HasContent()
                             && orderBy.HasContent()
                             && IsModelOrder(orderBy) == false)
                        {
                            var query = (await DataAccess.QueryAllAsync(accessFilter)
                                            .ConfigureAwait(false))
                                            .Select(e => ToModel(e))
                                            .ToArray();
                            query = await QueriedDataAsync(query).ConfigureAwait(false);
                            LoadModelDataHandler?.Invoke(this, query);
                            var modelQuery = query.AsQueryable()
                                        .Where(modelFilter)
                                        .OrderBy(orderBy);
                            Count = modelQuery.Count();
                            Models = modelQuery.Skip(skip).Take(PageSize).ToArray();
                        }
                        // G:
                        else if (accessFilter.HasContent()
                             && modelFilter.HasContent()
                             && orderBy.HasContent()
                             && IsModelOrder(orderBy))
                        {
                            var query = (await DataAccess.QueryAllAsync(accessFilter)
                                            .ConfigureAwait(false))
                                            .Select(e => ToModel(e))
                                            .ToArray();
                            query = await QueriedDataAsync(query).ConfigureAwait(false);
                            LoadModelDataHandler?.Invoke(this, query);
                            var modelQuery = query.AsQueryable()
                                        .Where(modelFilter)
                                        .OrderBy(orderBy);
                            Count = modelQuery.Count();
                            Models = modelQuery.Skip(skip).Take(PageSize).ToArray();
                        }
                        // H:
                        else if (accessFilter.HasContent() == false
                             && modelFilter.HasContent()
                             && orderBy.HasContent() == false)
                        {
                            var query = (await DataAccess.GetAllAsync()
                                            .ConfigureAwait(false))
                                            .Select(e => ToModel(e))
                                            .ToArray();
                            query = await QueriedDataAsync(query).ConfigureAwait(false);
                            LoadModelDataHandler?.Invoke(this, query);
                            var modelQuery = query.AsQueryable()
                                        .Where(modelFilter);
                            Count = modelQuery.Count();
                            Models = modelQuery.Skip(skip).Take(PageSize).ToArray();
                        }
                        // I:
                        else if (accessFilter.HasContent() == false
                             && modelFilter.HasContent()
                             && orderBy.HasContent()
                             && IsModelOrder(orderBy) == false)
                        {
                            var query = (await DataAccess.GetAllAsync()
                                            .ConfigureAwait(false))
                                            .Select(e => ToModel(e))
                                            .ToArray();
                            query = await QueriedDataAsync(query).ConfigureAwait(false);
                            LoadModelDataHandler?.Invoke(this, query);
                            var modelQuery = query.AsQueryable()
                                        .Where(modelFilter)
                                        .OrderBy(orderBy);
                            Count = modelQuery.Count();
                            Models = modelQuery.Skip(skip).Take(PageSize).ToArray();
                        }
                        // J:
                        else if (accessFilter.HasContent() == false
                             && modelFilter.HasContent()
                             && orderBy.HasContent()
                             && IsModelOrder(orderBy))
                        {
                            var query = (await DataAccess.GetAllAsync()
                                            .ConfigureAwait(false))
                                            .Select(e => ToModel(e))
                                            .ToArray();
                            query = await QueriedDataAsync(query).ConfigureAwait(false);
                            LoadModelDataHandler?.Invoke(this, query);
                            var modelQuery = query.AsQueryable()
                                        .Where(modelFilter)
                                        .OrderBy(orderBy);
                            Count = modelQuery.Count();
                            Models = modelQuery.Skip(skip).Take(PageSize).ToArray();
                        }
                        // K:
                        else if (accessFilter.HasContent() == false
                             && modelFilter.HasContent() == false
                             && orderBy.HasContent()
                             && IsModelOrder(orderBy) == false)
                        {
                            var query = (await DataAccess.GetAllAsync()
                                             .ConfigureAwait(false))
                                             .Select(e => ToModel(e))
                                             .ToArray();
                            query = await QueriedDataAsync(query).ConfigureAwait(false);
                            LoadModelDataHandler?.Invoke(this, query);
                            var modelQuery = query.AsQueryable()
                                        .OrderBy(orderBy);
                            Count = modelQuery.Count();
                            Models = modelQuery.Skip(skip).Take(PageSize).ToArray();
                        }
                        // L:
                        else if (accessFilter.HasContent() == false
                             && modelFilter.HasContent() == false
                             && orderBy.HasContent()
                             && IsModelOrder(orderBy))
                        {
                            var query = (await DataAccess.GetAllAsync()
                                            .ConfigureAwait(false))
                                            .Select(e => ToModel(e))
                                            .ToArray();
                            query = await QueriedDataAsync(query).ConfigureAwait(false);
                            LoadModelDataHandler?.Invoke(this, query);
                            var modelQuery = query.AsQueryable()
                                        .OrderBy(orderBy);
                            Count = modelQuery.Count();
                            Models = modelQuery.Skip(skip).Take(PageSize).ToArray();
                        }

                        if (Count > 0)
                        {
                            From = pageIndex.Value * PageSize + 1;
                            To = (From + PageSize) > Count ? Count : (From + PageSize);
                        }
                        else
                        {
                            From = 0;
                            To = 0;
                        }
                    }
                    await AfterLoadDataAsync(args).ConfigureAwait(false);
                    Models.ForeachAction(m => m.BeforeDisplay());
                }
                catch (System.Exception ex)
                {
                    ShowException($"Error {nameof(LoadDataAsync)}", ex);
                }
                finally
                {
                    loadDataActive = false;
                }
            }
        }
        protected virtual void PrepareLoadDataArgs(LoadDataArgs args)
        {
        }
        protected virtual Task<bool> BeforeLoadDataAsync(LoadDataArgs args)
        {
            return Task.FromResult(false);
        }
        protected virtual Task<TModel[]> QueriedDataAsync(TModel[] models)
        {
            return Task.FromResult(models);
        }
        protected virtual Task AfterLoadDataAsync(LoadDataArgs args)
        {
            return Task.FromResult(0);
        }
        #endregion Model operations

        public virtual void ValueChanged(object item)
        {
            var handled = false;

            BeforeValueChanged(item as TModel, ref handled);
            if (handled == false)
            {
            }
            AfterValueChanged(item as TModel);
        }
        partial void BeforeValueChanged(TModel item, ref bool handled);
        partial void AfterValueChanged(TModel item);

        public virtual void RowRender(RowRenderEventArgs<TModel> args)
        {
            var handled = false;

            BeforeRowRender(args, ref handled);
            if (handled == false)
            {
                args.Expandable = HasRowDetail;
            }
            AfterRowRender(args);
        }
        partial void BeforeRowRender(RowRenderEventArgs<TModel> args, ref bool handled);
        partial void AfterRowRender(RowRenderEventArgs<TModel> args);

        public virtual void RowCollapse(TModel item)
        {
            bool handled = false;

            BeforeRowCollapse(item, ref handled);
            if (handled == false)
            {
                BeforeRowCollapseHandler?.Invoke(this, item);
                ExpandModel = null;
                AfterRowCollapseHandler?.Invoke(this, item);
            }
            AfterRowCollapse(item);
        }
        partial void BeforeRowCollapse(TModel item, ref bool handled);
        partial void AfterRowCollapse(TModel item);

        public virtual void RowExpand(TModel item)
        {
            var handled = false;

            BeforeRowExpand(item, ref handled);
            if (handled == false)
            {
                BeforeRowExpandHandler?.Invoke(this, item);
                ExpandModel = item;
                AfterRowExpandHandler?.Invoke(this, item);
            }
            AfterRowExpand(item);
        }
        partial void BeforeRowExpand(TModel item, ref bool handled);
        partial void AfterRowExpand(TModel item);

        public virtual Task RowSelectedAsync(TModel item)
        {
            return InvokePageAsync(() =>
            {
                var handled = false;

                BeforeRowSelected(item, ref handled);
                if (handled == false)
                {
                    BeforeRowSelectedHandler?.Invoke(this, item);
                    SelectedModel ??= new TModel();
                    SelectedModel.CopyProperties(item);
                }
                AfterRowSelectedHandler?.Invoke(this, SelectedModel);
                AfterRowSelected(item);
            });
        }
        partial void BeforeRowSelected(TModel item, ref bool handled);
        partial void AfterRowSelected(TModel item);

        public virtual async Task RowDoubleClickAsync(TModel item)
        {
            var handled = false;

            BeforeRowDoubleClick(item, ref handled);
            if (handled == false && AllowEdit && EditModel == null)
            {
                await LoadAndShowEditModelAsync(item).ConfigureAwait(false);
            }
            AfterRowDoubleClick(item);
        }
        partial void BeforeRowDoubleClick(TModel item, ref bool handled);
        partial void AfterRowDoubleClick(TModel item);

        #region Dialog operations
        public bool IsEditModal { get; private set; }
        public bool HasFieldChanged
        {
            get => hasFieldChanged;
            set
            {
                hasFieldChanged = value;
                HasQueryChanged = HasQueryChanged && value;
            }
        }
        public bool HasQueryChanged { get; private set; }
        public bool InSubmitChanges { get; private set; }
        public bool InCancelChanges { get; private set; }
        public bool InReloadModel { get; private set; }

        protected virtual async Task CreateAndShowEditModelAsync()
        {
            try
            {
                EditModel = await CreateModelAsync().ConfigureAwait(false);

                await ShowEditModelAsync(EditModel).ConfigureAwait(false);
            }
            catch (System.Exception ex)
            {
                ShowException(Translate("Error create and show"), ex);
            }
        }
        protected virtual async Task CreateAndShowEditModelAsync(DialogService dialogService)
        {
            try
            {
                dialogService?.Close();
                EditModel = await CreateModelAsync().ConfigureAwait(false);
                await ShowEditModelAsync(EditModel).ConfigureAwait(false);
            }
            catch (System.Exception ex)
            {
                ShowException(Translate("Error create and show"), ex);
            }
        }
        protected virtual async Task LoadAndShowEditModelAsync(DialogService dialogService, int id)
        {
            try
            {
                var entity = await DataAccess.GetByIdAsync(id).ConfigureAwait(false);

                dialogService?.Close();
                await ShowEditModelAsync(entity).ConfigureAwait(false);
            }
            catch (System.Exception ex)
            {
                ShowException(Translate("Error load and show"), ex);
            }
        }
        protected virtual async Task LoadAndShowEditModelAsync(TModel item)
        {
            item.CheckArgument(nameof(item));

            try
            {
                var entity = default(TContract);

                if (item.Id > 0)
                {
                    entity = await DataAccess.GetByIdAsync(item.Id).ConfigureAwait(false);
                }
                else
                {
                    entity = await CreateModelAsync().ConfigureAwait(false);
                    entity.CopyProperties(item);
                }
                await ShowEditModelAsync(entity).ConfigureAwait(false);
            }
            catch (System.Exception ex)
            {
                ShowException(Translate($"Error {(item.Id == 0 ? "create" : "update")}"), ex);
            }
        }
        protected virtual async Task ShowEditModelAsync(TContract entity)
        {
            entity.CheckArgument(nameof(entity));

            EditModel = new TModel();

            EditModel.CopyProperties(entity);
            await ShowEditModelAsync(EditModel).ConfigureAwait(false);
        }
        protected virtual async Task ShowEditModelAsync(TModel editModel)
        {
            editModel.CheckArgument(nameof(editModel));

            BeforeEditModelHandler?.Invoke(this, editModel);
            LoadModelDataHandler?.Invoke(this, new[] { editModel });
            if (ShowEditItemDialogAsync != null)
            {
                BeforeShowEditItem(editModel);
                IsEditModal = true;
                HasFieldChanged = false;
                InSubmitChanges = false;
                InCancelChanges = false;
                InReloadModel = false;
                EditContext = new EditContext(editModel);
                await ShowEditItemDialogAsync().ConfigureAwait(false);
            }
        }

        public virtual void NavigateTo(int id)
		{
            var modelName = typeof(TModel).Name;
            var pageRoot = $"{modelName.CreatePluralWord()}";
            var navigateUri = $"{pageRoot}/{id}";

            ModelPage.NavigationManager.NavigateTo(navigateUri);
		}

        public virtual async Task AddItemAsync()
        {
            var handled = false;

            BeforeAddItem(ref handled);
            if (handled == false && AllowAdd && EditModel == null)
            {
                await CreateAndShowEditModelAsync().ConfigureAwait(false);
            }
            AfterEditModelHandler?.Invoke(this, EditModel);
            AfterAddItem(EditModel);
        }
        protected virtual void BeforeAddItem(ref bool handled)
        {
        }
        protected virtual void BeforeShowEditItem(TModel item)
        {
            item.BeforeEdit();
        }
        protected virtual void AfterAddItem(TModel item)
        {
        }

        public virtual async Task SubmitDialogChangesAsync(DialogService dialogService)
        {
            if (InSubmitChanges == false)
            {
                var handled = false;
                var saveModel = EditModel;

                InSubmitChanges = true;
                BeforeSubmitChanges(EditModel, ref handled);
                if (handled == false)
                {
                    var result = false;
                    try
                    {
                        var entity = default(TModel);

                        if (EditModel.CloneData || EditModel.Id == 0)
                        {
                            entity = await CreateModelAsync().ConfigureAwait(false);
                            entity.CopyFrom(EditModel, p => p.Equals(nameof(EditModel.Id)) == false);
                            result = await InsertModelAsync(entity).ConfigureAwait(false);
                        }
                        else
                        {
                            entity = new TModel();
                            entity.CopyFrom(EditModel);
                            result = await UpdateModelAsync(entity).ConfigureAwait(false);
                        }
                        if (result)
                        {
                            dialogService.Close();
                            AfterSubmitChanges(saveModel);

                            EditModel = new TModel();
                            EditModel.CopyFrom(entity);
                            await ShowEditModelAsync(EditModel).ConfigureAwait(false);
                        }
                    }
                    catch (System.Exception ex)
                    {
                        ShowException(EditModel?.Id == 0 ? "Error create" : "Error update", ex);
                    }
                    finally
                    {
                        InSubmitChanges = false;
                    }
                }
                else
                {
                    AfterSubmitChanges(saveModel);
                    InSubmitChanges = false;
                }
            }
        }
        public virtual async Task SubmitDialogChangesAndCloseAsync(DialogService dialogService)
        {
            var handled = false;
            var saveModel = EditModel;

            BeforeSubmitChanges(EditModel, ref handled);
            if (handled == false)
            {
                var result = false;
                try
                {
                    var entity = default(TModel);

                    if (EditModel.CloneData || EditModel.Id == 0)
                    {
                        entity = await CreateModelAsync().ConfigureAwait(false);
                        entity.CopyFrom(EditModel, p => p.Equals(nameof(EditModel.Id)) == false);
                        result = await InsertModelAsync(entity).ConfigureAwait(false);
                    }
                    else
                    {
                        entity = new TModel();
                        entity.CopyFrom(EditModel);
                        result = await UpdateModelAsync(entity).ConfigureAwait(false);
                    }
                    if (result)
                    {
                        dialogService.Close();
                        AfterSubmitChanges(saveModel);
                    }
                }
                catch (System.Exception ex)
                {
                    ShowException(EditModel.Id == 0 ? "Error create" : "Error update", ex);
                }
            }
            else
            {
                AfterSubmitChanges(saveModel);
            }
        }
        protected virtual void BeforeSubmitChanges(TModel item, ref bool handled)
        {
            item?.BeforeSave();
        }
        protected virtual void AfterSubmitChanges(TModel item)
        {
            item?.AfterSave();
        }

        public virtual async Task MovePrevDialogModelAsync(DialogService dialogService)
        {
            if (InReloadModel == false)
            {
                InReloadModel = true;

                try
                {
                    if (HasFieldChanged && HasQueryChanged == false)
                    {
                        HasQueryChanged = true;
                        ShowWarning("Data changed", "If you want to discard the changes, activate the action again!");
                    }
                    else
                    {
                        var id = EditModel.Id;
                        var idx = Models.FindIndex(e => e.Id == id);

                        if (idx > 0)
                        {
                            id = Models[idx - 1].Id;
                            await RadzenGrid.SelectRow(Models[idx - 1]).ConfigureAwait(false);
                        }
                        EditModel?.CancelEdit();
                        EditModel = null;

                        if (id > 0)
                        {
                            await LoadAndShowEditModelAsync(dialogService, id).ConfigureAwait(false);
                        }
                        else
                        {
                            await CreateAndShowEditModelAsync(dialogService).ConfigureAwait(false);
                        }
                    }
                }
                catch (System.Exception ex)
                {
                    ShowException(Translate("Error reload"), ex);
                }
                finally
                {
                    InReloadModel = false;
                }
            }
        }
        public virtual async Task ReloadDialogModelAsync(DialogService dialogService)
        {
            if (InReloadModel == false)
            {
                InReloadModel = true;

                try
                {
                    if (HasFieldChanged && HasQueryChanged == false)
                    {
                        HasQueryChanged = true;
                        ShowWarning("Data changed", "If you want to discard the changes, activate the action again!");
                    }
                    else
                    {
                        var id = EditModel.Id;

                        EditModel?.CancelEdit();
                        EditModel = null;

                        if (id > 0)
                        {
                            await LoadAndShowEditModelAsync(dialogService, id).ConfigureAwait(false);
                        }
                        else
                        {
                            await CreateAndShowEditModelAsync(dialogService).ConfigureAwait(false);
                        }
                    }
                }
                catch (System.Exception ex)
                {
                    ShowException(Translate("Error reload dialog"), ex);
                }
                finally
                {
                    InReloadModel = false;
                }
            }
        }
        public virtual async Task MoveNextDialogModelAsync(DialogService dialogService)
        {
            if (InReloadModel == false)
            {
                InReloadModel = true;

                try
                {
                    if (HasFieldChanged && HasQueryChanged == false)
                    {
                        HasQueryChanged = true;
                        ShowWarning("Data changed", "If you want to discard the changes, activate the action again!");
                    }
                    else
                    {
                        var id = EditModel.Id;
                        var idx = Models.FindIndex(e => e.Id == id);

                        if (idx < Models.Length - 1)
                        {
                            id = Models[idx + 1].Id;
                            await RadzenGrid.SelectRow(Models[idx + 1]).ConfigureAwait(false);
                        }
                        EditModel?.CancelEdit();
                        EditModel = null;

                        if (id > 0)
                        {
                            await LoadAndShowEditModelAsync(dialogService, id).ConfigureAwait(false);
                        }
                        else
                        {
                            await CreateAndShowEditModelAsync(dialogService).ConfigureAwait(false);
                        }
                    }
                }
                catch (System.Exception ex)
                {
                    ShowException(Translate("Error move next"), ex);
                }
                finally
                {
                    InReloadModel = false;
                }
            }
        }

        public virtual Task CancelDialogChangesAndCloseAsync(DialogService dialogService)
        {
            return Task.Factory.StartNew(() =>
            {
                if (HasFieldChanged && HasQueryChanged == false)
                {
                    HasQueryChanged = true;
                    ShowWarning("Data changed", "If you want to discard the changes, activate the action again!");
                }
                else
                {
                    dialogService.Close();
                    EditModel?.CancelEdit();
                    EditModel = null;
                }
            });
        }

        public virtual async Task ConfirmDialogDeleteAsync(DialogService dialogService)
        {
            var handled = false;
            var saveModel = DeleteModel;

            BeforeConfirmDelete(DeleteModel, ref handled);
            if (handled == false)
            {
                try
                {
                    await DeleteModelAsync(DeleteModel).ConfigureAwait(false);
                    dialogService.Close();
                    AfterConfirmDelete(saveModel);
                }
                catch (System.Exception ex)
                {
                    ShowException("Error delete", ex);
                }
            }
            else
            {
                AfterConfirmDelete(saveModel);
            }
        }
        protected virtual void BeforeConfirmDelete(TModel item, ref bool handled)
        {
            item?.ConfirmedDelete();
        }
        protected virtual void AfterConfirmDelete(TModel item)
        {
            item?.AfterDelete();
        }

        public virtual void CancelDialogDelete(DialogService dialogService)
        {
            dialogService.Close();
            DeleteModel?.CancelDelete();
            DeleteModel = null;
        }

#pragma warning disable IDE0060 // Remove unused parameter
        public void OnCloseDialog(dynamic result)
#pragma warning restore IDE0060 // Remove unused parameter
        {
            EditModel?.CancelEdit();
            EditModel = null;
            DeleteModel?.CancelDelete();
            DeleteModel = null;
            EditContext = null;
            IsEditModal = InSubmitChanges;
        }
        #endregion Dialog operations

        #region Model operations
        protected virtual async Task<TModel> CreateModelAsync()
        {
            var result = new TModel();
            var entity = await DataAccess.CreateAsync().ConfigureAwait(false);

            result.CopyProperties(entity);
            AfterCreateModelHandler?.Invoke(this, result);
            return result;
        }
        public virtual async Task<bool> InsertModelAsync(TModel model)
        {
            var handled = false;
            var result = ValidateModel(model);

            if (result)
            {
                BeforeInsertModel(model, ref handled);
                if (handled == false)
                {
                    BeforeInsertModelHandler?.Invoke(this, model);
                    var curItem = await DataAccess.InsertAsync(model).ConfigureAwait(false);

                    model.CopyProperties(curItem);
                }
                AfterInsertModelHandler?.Invoke(this, model);
                AfterInsertModel(model);
                await AfterModelActionAsync(model, inserted: true).ConfigureAwait(false);
            }
            return result;
        }
        protected virtual void BeforeInsertModel(TModel model, ref bool handled)
        {
        }
        protected virtual void AfterInsertModel(TModel model)
        {
        }

        public virtual async Task<bool> UpdateModelAsync(TModel model)
        {
            var handled = false;
            var result = ValidateModel(model);

            if (result)
            {
                BeforeUpdateModel(model, ref handled);
                if (handled == false)
                {
                    BeforeUpdateModelHandler?.Invoke(this, model);
                    var curItem = await DataAccess.UpdateAsync(model).ConfigureAwait(false);

                    model.CopyProperties(curItem);
                    LoadModelDataHandler?.Invoke(this, new[] { model });
                }
                AfterUpdateModelHandler?.Invoke(this, model);
                AfterUpdateModel(model);
                await AfterModelActionAsync(model, updated: true).ConfigureAwait(false);
            }
            return result;
        }
        protected virtual void BeforeUpdateModel(TModel model, ref bool handled)
        {
        }
        protected virtual void AfterUpdateModel(TModel model)
        {
        }

        public virtual async Task DeleteModelAsync(TModel model)
        {
            var handeld = false;

            BeforeDeleteModel(model, ref handeld);
            if (handeld == false)
            {
                BeforeDeleteModelHandler?.Invoke(this, model);
                await DataAccess.DeleteAsync(model.Id).ConfigureAwait(false);
            }
            AfterDeleteModelHandler?.Invoke(this, model);
            AfterDelteModel(model);
            await AfterModelActionAsync(model, deleted: true).ConfigureAwait(false);
        }
        protected virtual void BeforeDeleteModel(TModel model, ref bool handled)
        {
        }
        protected virtual void AfterDelteModel(TModel model)
        {
        }
        protected async Task AfterModelActionAsync(TModel model, bool inserted = false, bool updated = false, bool deleted = false)
        {
            if (inserted)
            {
                await InvokePageAsync(async () => await ReloadDataAsync(model).ConfigureAwait(false)).ConfigureAwait(false);
            }
            else if (updated)
            {
                await InvokePageAsync(() => ReloadModel(model)).ConfigureAwait(false);
            }
            else if (deleted)
            {
                await InvokePageAsync(() => RadzenGrid.Reload()).ConfigureAwait(false);
            }
        }
        #endregion Model operations

        #region DataGridColumns operations
        public virtual async Task EditRowAsync(TModel item)
        {
            var handled = false;
            BeforeEditRow(item, ref handled);
            if (handled == false && AllowEdit && EditModel == null)
            {
                EditModel = new TModel();
                EditModel.CopyProperties(item);

                if (AllowInlineEdit)
                {
                    await InvokePageAsync(() => RadzenGrid.EditRow(item)).ConfigureAwait(false);
                }
                else
                {
                    await ShowEditModelAsync(EditModel).ConfigureAwait(false);
                }
            }
            AfterEditRow(item);
        }
        protected virtual void BeforeEditRow(TModel item, ref bool handled)
        {
        }
        protected virtual void AfterEditRow(TModel item)
        {
        }

        public virtual async Task UpdateRowAsync(TModel item)
        {
            var handled = false;

            BeforeUpdateRow(item, ref handled);
            if (handled == false)
            {
                try
                {
                    if (EditModel.Id == 0)
                    {
                        await InsertModelAsync(item).ConfigureAwait(false);
                    }
                    else
                    {
                        await UpdateModelAsync(item).ConfigureAwait(false);
                    }
                }
                catch (System.Exception ex)
                {
                    ShowException("Error update", ex);
                }
                EditModel = null;
            }
            AfterUpdateRow(item);
        }
        protected virtual void BeforeUpdateRow(TModel item, ref bool handled)
        {
        }
        protected virtual void AfterUpdateRow(TModel item)
        {
        }

        public virtual async Task DeleteRowAsync(TModel model)
        {
            var handeld = false;

            BeforeDeleteRow(model, ref handeld);
            if (handeld == false)
            {
                DeleteModel = await CreateModelAsync().ConfigureAwait(false);
                DeleteModel.CopyFrom(model);
                DeleteModel.BeforeDelete();
                if (ShowConfirmDeleteDialogAsync != null)
                {
                    await ShowConfirmDeleteDialogAsync().ConfigureAwait(false);
                }
            }
            AfterDelteRow(model);
        }
        protected virtual void BeforeDeleteRow(TModel model, ref bool handled)
        {
        }
        protected virtual void AfterDelteRow(TModel model)
        {
        }

        public virtual void CommitEditRow(TModel item)
        {
            var handled = false;

            BeforeCommitEditRow(item, ref handled);
            if (handled == false)
            {
                RadzenGrid.UpdateRow(item);
            }
            AfterCommitEditRow(item);
        }
        protected virtual void BeforeCommitEditRow(TModel item, ref bool handled)
        {
        }
        protected virtual void AfterCommitEditRow(TModel item)
        {
        }

        public virtual void CancelEditRow(TModel item)
        {
            var handled = false;

            BeforeCancelEditRow(item, ref handled);
            if (handled == false)
            {
                if (EditModel != null)
                {
                    item.CopyProperties(EditModel);
                }
                RadzenGrid.CancelEditRow(item);
                EditModel = null;
            }
            AfterCancelEditRow(item);
        }
        protected virtual void BeforeCancelEditRow(TModel item, ref bool handled)
        {
        }
        protected virtual void AfterCancelEditRow(TModel item)
        {
        }
        #endregion DataGridColumns operations

        private void ShowException(string title, System.Exception exception)
        {
            if (ShowError(title, GetExceptionError(exception)) == false)
                throw exception;
        }
        private bool ShowError(string title, string message)
        {
            var result = ShowNotification != null;

            ShowNotification?.Invoke(new NotificationMessage()
            {
                Severity = NotificationSeverity.Error,
                Summary = Translate(title),
                Detail = Translate(message),
                Duration = 4000
            });
            return result;
        }
        private bool ShowWarning(string title, string message)
        {
            var result = ShowNotification != null;

            ShowNotification?.Invoke(new NotificationMessage()
            {
                Severity = NotificationSeverity.Warning,
                Summary = Translate(title),
                Detail = Translate(message),
                Duration = 4000
            });
            return result;
        }

        #region Dispose pattern
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                    if (dataAccess != null)
                    {
                        dataAccess.Dispose();
                    }
                    dataAccess = null;
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~DataGridHandler()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
        #endregion Dispose pattern
    }
}
//MdEnd
