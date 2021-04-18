//@QnSCodeCopy
//MdStart

using CommonBase.Extensions;
using QnSProjectAward.BlazorApp.Models;
using QnSProjectAward.BlazorApp.Models.Modules.Form;
using QnSProjectAward.BlazorApp.Modules.Helpers;
using QnSProjectAward.BlazorApp.Pages;
using QnSProjectAward.BlazorApp.Shared.Components;
using System;
using System.Collections.Generic;
using System.Linq;

namespace QnSProjectAward.BlazorApp.Modules.DataGrid
{
    public class DataGridAssociationItem<TModel, TItem> : IDisposable
        where TModel : ModelObject, Contracts.IIdentifiable, new()
        where TItem : Contracts.IIdentifiable
    {
        public ModelPage ModelPage => DataGridHandler.ModelPage;
        public DisplayComponent DisplayComponent { get; private set; }
        public IDataGridHandler<TModel> DataGridHandler { get; private set; }
        public string ItemRefIdName { get; init; }
        public Func<TItem, string> ItemToText { get; set; }
        public Action<TModel, TItem> ModelAssignment { get; set; }
        private ItemContainer<TItem> items = null;

        public IEnumerable<TItem> Items
        {
            get
            {
                if (items == null)
                {
                    items = new ItemContainer<TItem>(ModelPage);
                }
                return items.Items;
            }
        }
        public DataGridAssociationItem(DisplayComponent displayComponent, IDataGridHandler<TModel> dataGridHandler, string itemRefIdName, Func<TItem, string> itemToText)
        {
            displayComponent.CheckArgument(nameof(displayComponent));
            dataGridHandler.CheckArgument(nameof(dataGridHandler));
            itemToText.CheckArgument(nameof(itemToText));

            DisplayComponent = displayComponent;
            DataGridHandler = dataGridHandler;
            ItemRefIdName = itemRefIdName;
            ItemToText = itemToText;

            DisplayComponent.CreatedDisplayModelMemberHandler += CreatedDisplayModelMemberHandler;
            DisplayComponent.CreateEditModelMemberHandler += CreateEditModelMemberHandler;
            DisplayComponent.ShowModelDisplayPropertyHandler += ShowModelDisplayPropertyhandler;
        }
        public DataGridAssociationItem(DisplayComponent displayComponent, IDataGridHandler<TModel> dataGridHandler, string itemRefIdName, Func<TItem, string> itemToText, Action<TModel, TItem> modelAssignment)
        {
            displayComponent.CheckArgument(nameof(displayComponent));
            dataGridHandler.CheckArgument(nameof(dataGridHandler));
            itemToText.CheckArgument(nameof(itemToText));
            modelAssignment.CheckArgument(nameof(modelAssignment));

            DisplayComponent = displayComponent;
            DataGridHandler = dataGridHandler;
            ItemRefIdName = itemRefIdName;
            ItemToText = itemToText;
            ModelAssignment = modelAssignment;

            DisplayComponent.InitDisplayInfosHandler += InitDisplayInfosHandler;
            DisplayComponent.CreatedDisplayModelMemberHandler += CreatedDisplayModelMemberHandler;
            DisplayComponent.CreateEditModelMemberHandler += CreateEditModelMemberHandler;
            DataGridHandler.LoadModelDataHandler += LoadModelDataHandler;
        }

        protected virtual void InitDisplayInfosHandler(object sender, DisplayInfoContainer e)
        {
            if (e.ContainsKey($"{typeof(TModel).Name}{ItemRefIdName}") == false)
            {
                e.AddOrSet(new DisplayInfo(typeof(TModel).Name, ItemRefIdName)
                {
                    VisibilityMode = Models.Modules.Common.VisibilityMode.CreateUpdateDeleteView,
                    Order = 1,
                });
            }
        }
        protected void LoadModelDataHandler(object sender, TModel[] models)
        {
            models.CheckArgument(nameof(models));

            var property = models.Length > 0 ? models[0].GetType().GetProperty(ItemRefIdName) : null;

            if (property != null)
            {
                foreach (var model in models)
                {
                    var refId = (int?)property.GetValue(model);
                    var refItem = Items.FirstOrDefault(i => i.Id == refId.GetValueOrDefault());

                    if (refItem != null)
                    {
                        ModelAssignment?.Invoke(model, refItem);
                    }
                }
            }
        }
        protected void CreatedDisplayModelMemberHandler(object sender, DisplayModelMember modelMember)
        {
            if (modelMember.Name.Equals(ItemRefIdName))
            {
                modelMember.ToDisplayValue = v =>
                {
                    var result = string.Empty;
                    var refId = (int?)v;
                    var refItem = Items.FirstOrDefault(i => i.Id == refId.GetValueOrDefault());

                    if (refItem != null)
                    {
                        result = ItemToText(refItem);
                    }
                    return result;
                };
            }
        }
        protected void CreateEditModelMemberHandler(object sender, EditModelMemberInfo memberInfo)
        {
            if (memberInfo.Property.Name.Equals(ItemRefIdName))
            {
                var refId = (int?)memberInfo.Property.GetValue(memberInfo.Model);
                var displayInfo = DisplayComponent.GetOrCreateDisplayInfo(memberInfo.Model.GetType(), memberInfo.Property);

                memberInfo.Created = true;
                memberInfo.ModelMember = new SelectEditMember<TItem>(ModelPage, memberInfo.Model, memberInfo.Property, displayInfo, Items, a => ItemToText(a), a => a.Id == refId.GetValueOrDefault());
            }
        }
        protected void ShowModelDisplayPropertyhandler(object sender, ModelDisplayProperty modelDisplayProperty)
        {
            if (modelDisplayProperty.DisplayInfo.OriginName.Equals(ItemRefIdName))
            {
                modelDisplayProperty.DisplayInfo.ToDisplay = (m, v) =>
                {
                    var result = default(string);

                    if (v is int refId)
                    {
                        var refItem = Items.FirstOrDefault(i => i.Id == refId);

                        if (refItem != null)
                        {
                            result = ItemToText(refItem);
                        }
                    }
                    return result;
                };
            }
        }

        #region Dispose-pattern
        private bool disposedValue;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                    DisplayComponent.InitDisplayInfosHandler -= InitDisplayInfosHandler;
                    DisplayComponent.CreatedDisplayModelMemberHandler -= CreatedDisplayModelMemberHandler;
                    DisplayComponent.CreateEditModelMemberHandler -= CreateEditModelMemberHandler;
                    DisplayComponent = null;

                    DataGridHandler.LoadModelDataHandler -= LoadModelDataHandler;
                    DataGridHandler = null;
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~AssociationItem()
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
        #endregion Dispose-pattern
    }
}
//MdEnd
