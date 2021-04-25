//@QnSCodeCopy
//MdStart
using CommonBase.Extensions;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using TMenuItem = QnSProjectAward.BlazorApp.Models.Modules.Menu.MenuItem;
using TModelSetting = QnSProjectAward.BlazorApp.Models.Modules.Configuration.ModelSetting;

namespace QnSProjectAward.BlazorApp.Pages
{
    public abstract partial class MasterDetailsPage<TMasterContract, TMaster> : ModelPage
        where TMasterContract : Contracts.IIdentifiable, Contracts.ICopyable<TMasterContract>
        where TMaster : Models.ModelObject, TMasterContract, new()
    {
        private TMaster master = null;
        private int detailIndex = 0;
        private TModelSetting modelSetting;

        [Parameter]
        public string Mode { get; set; }
        [Parameter]
        public int Id { get; set; }
        [Parameter]
        public string Detail { get; set; }
        [Parameter]
        public int Index
        {
            get => detailIndex;
            set
            {
                if (value > -1)
                {
                    detailIndex = value;
                }
            }
        }

        public TMaster Master
        {
            get => master;
            set
            {
                if ((master == null && value != null)
                    || (master != null && value != null && master.Id != value.Id))
                {
                    master = value;
                    InvokeAsync(() => StateHasChanged());
                }
                else
                {
                    master = value;
                }
            }
        }
        public int DetailIndex
        {
            get => detailIndex;
            set
            {
                if (value != detailIndex)
                {
                    detailIndex = value;
                    InvokeAsync(() => StateHasChanged());
                }
            }
        }
        protected virtual string MasterName => Master?.ToString();
        protected virtual string DetailName => DetailNames.Length > Index ? DetailNames[DetailIndex] : string.Empty;
        public string CurrentRef() => Id > 0 ? CreateRef(Mode, Id) : CreateRef(Mode);
        public string CreateRef() => PageRoot;
        public string CreateRef(string mode) => $"{PageRoot}/{mode}{(Detail.HasContent() ? $"/{Detail}/{Index}" : $"/Tabs/{Index}")}";
        public string CreateRef(string mode, int id) => $"{PageRoot}/{mode}/{id}{(Detail.HasContent() ? $"/{Detail}/{Index}" : string.Empty)}";

        protected abstract string PageRoot { get; }
        protected abstract string[] DetailNames { get; }
        protected virtual string NewRef => CreateRef("New");
        protected virtual string ViewRef => CreateRef("View", Id);
        protected virtual string EditRef => CreateRef("Edit", Id);
        protected virtual string DeleteRef => CreateRef("Delete", Id);
        protected List<TMenuItem> MenuItems { get; } = new();
        protected TModelSetting ModelSetting
        {
            get => modelSetting ??= new TModelSetting();
            set => modelSetting = value;
        }

        protected override Task OnFirstRenderAsync()
        {
            bool handled = false;
            BeforeFirstRender(ref handled);
            if (handled == false)
            {
                InitPageData();
            }
            AfterFirstRender();
            return base.OnFirstRenderAsync();
        }
        partial void BeforeFirstRender(ref bool handled);
        partial void AfterFirstRender();

        protected virtual void InitPageData()
        {
            var modelName = ComponentName.Replace("Page", string.Empty);
            var jsonValue = Settings.GetValue($"{modelName}.Setting", string.Empty);

            if (jsonValue.HasContent())
            {
                ModelSetting = JsonSerializer.Deserialize<TModelSetting>(jsonValue);
            }
        }
    }
}
//MdEnd
