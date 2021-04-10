//@QnSCodeCopy
//MdStart
using CommonBase.Extensions;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using TMenuItem = QnSProjectAward.BlazorApp.Models.Modules.Menu.MenuItem;

namespace QnSProjectAward.BlazorApp.Pages
{
    public abstract partial class MasterDetailsPage<TMasterContract, TMaster> : ModelPage
        where TMasterContract : Contracts.IIdentifiable, Contracts.ICopyable<TMasterContract>
        where TMaster : Models.ModelObject, TMasterContract, new()
    {
        [Parameter]
        public string Mode { get; set; }
        [Parameter]
        public int Id { get; set; }
        [Parameter]
        public string Detail { get; set; }
        [Parameter]
        public int Index { get; set; }

        public string CreateRef() => PageRoot;
        public string CreateRef(string mode) => $"{PageRoot}/{mode}{(Detail.HasContent() ? $"/{Detail}/{Index}" : string.Empty)}";
        public string CreateRef(string mode, int id) => $"{PageRoot}/{mode}/{id}{(Detail.HasContent() ? $"/{Detail}/{Index}" : string.Empty)}";

        protected virtual string PageRoot => $"{typeof(TMaster).Name}s";
        protected virtual string NewRef => CreateRef("New");
        protected virtual string ViewRef => CreateRef("View" ,Id);
        protected virtual string EditRef => CreateRef("Edit", Id);
        protected virtual string DeleteRef => CreateRef("Delete", Id);            
        protected List<TMenuItem> MenuItems { get; } = new();
    }
}
//MdEnd
