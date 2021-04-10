//@QnSCodeCopy
//MdStart

using CommonBase.Extensions;
using Microsoft.AspNetCore.Components;
using QnSProjectAward.BlazorApp.Models;
using QnSProjectAward.BlazorApp.Models.Modules.Form;
using QnSProjectAward.BlazorApp.Pages;
using Radzen;
using System;
using System.Threading.Tasks;

namespace QnSProjectAward.BlazorApp.Shared.Components
{
    public partial class MasterComponent<TMasterContract, TMaster> : DisplayComponent
        where TMasterContract : Contracts.IIdentifiable, Contracts.ICopyable<TMasterContract>
        where TMaster : Models.ModelObject, TMasterContract, new()
    {
        private TMaster model;
        private bool hasFieldChanged;

        [Parameter]
        public MasterDetailsPage<TMasterContract, TMaster> MasterDetailsPage { get; set; }
        protected int Id => MasterDetailsPage.Id;
        protected string Mode => MasterDetailsPage.Mode;
        protected TMaster Model
        {
            get => model ??= new TMaster();
            set => model = value;
        }
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
        public bool InReloadModel { get; private set; }

        protected override void InitDisplayInfoContainer(DisplayInfoContainer displayProperties)
        {
            base.InitDisplayInfoContainer(displayProperties);

            displayProperties.AddOrSet(nameof(IdentityModel.Cloneable), dp => { dp.VisibilityMode = Models.Modules.Common.VisibilityMode.Hidden; });
            displayProperties.AddOrSet(nameof(IdentityModel.CloneData), dp => { dp.VisibilityMode = Models.Modules.Common.VisibilityMode.Hidden; });
        }

        public MasterComponent()
        {
            Constructing();
            Constructed();
        }
        partial void Constructing();
        partial void Constructed();

        protected virtual async Task InitializeDataAsync()
        {
            using var adapter = MasterDetailsPage.ServiceAdapter.Create<TMasterContract>();

            if (AuthorizationSession != null)
            {
                adapter.SessionToken = AuthorizationSession.Token;

                if (Mode.AreEquals("new", StringComparison.CurrentCultureIgnoreCase))
                {
                    var entity = await adapter.CreateAsync().ConfigureAwait(false);

                    Model = ToModel(entity);
                }
                else if (Mode.AreEquals("view", StringComparison.CurrentCultureIgnoreCase))
                {
                    var entity = await adapter.GetByIdAsync(Id).ConfigureAwait(false);

                    Model = ToModel(entity);
                }
                else if (Mode.AreEquals("edit", StringComparison.CurrentCultureIgnoreCase))
                {
                    var entity = await adapter.GetByIdAsync(Id).ConfigureAwait(false);

                    Model = ToModel(entity);
                }
                else if (Mode.AreEquals("delete", StringComparison.CurrentCultureIgnoreCase))
                {
                    var entity = await adapter.GetByIdAsync(Id).ConfigureAwait(false);

                    Model = ToModel(entity);
                }
                else
                {
                    Model = new TMaster();
                }
            }
            else
            {
                Model = new TMaster();
            }
        }
        protected override async Task OnParametersSetAsync()
        {
            await base.OnParametersSetAsync().ConfigureAwait(false);

            bool handled = false;
            BeforeParametersSet(ref handled);
            if (handled == false)
            {
                await InitializeDataAsync().ConfigureAwait(false);
            }
            AfterParametersSet();
        }
        partial void BeforeParametersSet(ref bool handled);
        partial void AfterParametersSet();
        protected override async Task OnFirstRenderAsync()
        {
            bool handled = false;
            BeforeFirstRender(ref handled);
            if (handled == false)
            {
                await InitializeDataAsync().ConfigureAwait(false);
            }
            AfterFirstRender();
            await base.OnFirstRenderAsync().ConfigureAwait(false);
        }
        partial void BeforeFirstRender(ref bool handled);
        partial void AfterFirstRender();

        public virtual async void SubmitChangesAsync()
        {
            if (InSubmitChanges == false)
            {
                var error = false;
                var handled = false;

                InSubmitChanges = true;
                BeforeSubmitChanges(Model, ref handled);
                if (handled == false)
                {
                    Model?.BeforeSave();
                    try
                    {
                        using var adapter = MasterDetailsPage.ServiceAdapter.Create<TMasterContract>(AuthorizationSession.Token);

                        if (Model.Id == 0)
                        {
                            var entity = await adapter.InsertAsync(Model).ConfigureAwait(false);

                            Model.CopyProperties(entity);
                        }
                        else
                        {
                            var entity = await adapter.UpdateAsync(Model).ConfigureAwait(false);

                            Model.CopyProperties(entity);
                        }
                    }
                    catch (Exception ex)
                    {
                        error = true;
                        ShowException(Model.Id == 0 ? "Error create" : "Error update", ex);
                    }
                    finally
                    {
                        InSubmitChanges = false;
                    }
                }
                else
                {
                    InSubmitChanges = false;
                }
                Model?.AfterSave();
                AfterSubmitChanges(Model);

                if (error == false)
                {
                    NavigationManager.NavigateTo(MasterDetailsPage.CreateRef("Edit", Model.Id));
                }
                else
                {
                    await InvokeAsync(() => StateHasChanged()).ConfigureAwait(false);
                }
            }
        }
        partial void BeforeSubmitChanges(TMaster model, ref bool handled);
        partial void AfterSubmitChanges(TMaster model);

        public virtual async Task ConfirmDeleteAsync()
        {
            var deleted = false;
            var handled = false;
            var saveModel = Model;

            BeforeConfirmDelete(Model, ref handled);
            if (handled == false)
            {
                try
                {
                    if (HasQueryChanged == false)
                    {
                        HasQueryChanged = true;
                        ShowWarning("Item delete", "If you want to delete the item, activate the action again!");
                    }
                    else
                    {
                        using var adapter = MasterDetailsPage.ServiceAdapter.Create<TMasterContract>(AuthorizationSession.Token);

                        await adapter.DeleteAsync(Model.Id).ConfigureAwait(false);
                        AfterConfirmDelete(saveModel);
                        deleted = true;
                    }
                }
                catch (Exception ex)
                {
                    ShowException("Error delete", ex);
                }
            }
            else
            {
                AfterConfirmDelete(saveModel);
            }
            if (deleted)
            {
                NavigationManager.NavigateTo(MasterDetailsPage.CreateRef());
            }
        }
        protected virtual void BeforeConfirmDelete(TMaster model, ref bool handled)
        {
            model?.ConfirmedDelete();
        }
        protected virtual void AfterConfirmDelete(TMaster model)
        {
            model?.AfterDelete();
        }

        public void ReloadPage()
        {
            if (InReloadModel == false)
            {
                InReloadModel = true;

                if (HasFieldChanged && HasQueryChanged == false)
                {
                    HasQueryChanged = true;
                    ShowWarning("Data changed", "If you want to discard the changes, activate the action again!");
                }
                else
                {
                    string navigateTo;

                    if (Model.Id == 0)
                    {
                        navigateTo = MasterDetailsPage.CreateRef("New");
                    }
                    else
                    {
                        navigateTo = MasterDetailsPage.CreateRef(Mode, Id);
                    }
                    NavigationManager.NavigateTo(navigateTo, true);
                }
                InReloadModel = false;
            }
        }

        protected void ShowException(string title, System.Exception exception)
        {
            ShowError(title, GetExceptionError(exception));
        }
        protected void ShowError(string title, string message)
        {
            NotificationService.Notify(new NotificationMessage()
            {
                Severity = NotificationSeverity.Error,
                Summary = Translate(title),
                Detail = message,
                Duration = 4000
            });
        }
        protected void ShowWarning(string title, string message)
        {
            NotificationService.Notify(new NotificationMessage()
            {
                Severity = NotificationSeverity.Warning,
                Summary = Translate(title),
                Detail = Translate(message),
                Duration = 4000
            });
        }

        protected virtual TMaster ToModel(TMasterContract entity)
        {
            var handled = false;
            var model = new TMaster();

            BeforeToModel(entity, model, ref handled);
            if (handled == false)
            {
                model.CopyProperties(entity);
            }
            AfterToModel(model);
            return model;
        }
        partial void BeforeToModel(TMasterContract entity, TMaster model, ref bool handled);
        partial void AfterToModel(TMaster model);
    }
}
//MdEnd
