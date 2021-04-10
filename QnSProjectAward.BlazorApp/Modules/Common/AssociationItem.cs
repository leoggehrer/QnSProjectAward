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

namespace QnSProjectAward.BlazorApp.Modules.Common
{
    public class AssociationItem<TModel, TItem> : IDisposable
        where TModel : ModelObject, Contracts.IIdentifiable, new()
        where TItem : Contracts.IIdentifiable
    {
        public ModelPage ModelPage { get; init; }
        public DisplayComponent DisplayComponent { get; private set; }
        public string ItemRefIdName { get; init; }
        public Func<int, TModel, bool> Compare { get; init; }
        public Func<TItem, string> ItemToText { get; init; }
        public Action<TModel, TItem> ModelAssignment { get; init; }
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
        public AssociationItem(ModelPage modelPage, DisplayComponent displayComponent, string itemRefIdName, Func<TItem, string> itemToText, Action<TModel, TItem> modelAssignment)
        {
            modelPage.CheckArgument(nameof(modelPage));
            displayComponent.CheckArgument(nameof(displayComponent));
            itemToText.CheckArgument(nameof(itemToText));
            modelAssignment.CheckArgument(nameof(modelAssignment));

            ModelPage = modelPage;
            DisplayComponent = displayComponent;
            ItemRefIdName = itemRefIdName;
            ItemToText = itemToText;
            ModelAssignment = modelAssignment;

            DisplayComponent.InitDisplayPropertiesHandler += InitDisplayPropertiesHandler;
            DisplayComponent.CreatedDisplayModelMemberHandler += CreatedDisplayModelMemberHandler;
            DisplayComponent.CreateEditModelMemberHandler += CreateEditModelMemberHandler;
        }

        protected virtual void InitDisplayPropertiesHandler(object sender, DisplayInfoContainer e)
        {
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

        #region Dispose-pattern
        private bool disposedValue;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                    DisplayComponent.InitDisplayPropertiesHandler -= InitDisplayPropertiesHandler;
                    DisplayComponent.CreatedDisplayModelMemberHandler -= CreatedDisplayModelMemberHandler;
                    DisplayComponent.CreateEditModelMemberHandler -= CreateEditModelMemberHandler;
                    DisplayComponent = null;
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
