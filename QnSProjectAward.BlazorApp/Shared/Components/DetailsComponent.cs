//@QnSCodeCopy
//MdStart

using CommonBase.Extensions;
using Microsoft.AspNetCore.Components;
using QnSProjectAward.BlazorApp.Modules.DataGrid;
using QnSProjectAward.BlazorApp.Pages;
using Radzen.Blazor;
using System;
using System.Text.Json;
using System.Threading.Tasks;
using TDataGridHandlerSetting = QnSProjectAward.BlazorApp.Models.Modules.Configuration.DataGridHandlerSetting;

namespace QnSProjectAward.BlazorApp.Shared.Components
{
	public partial class DetailsComponent<TMasterContract, TMaster> : DisplayComponent
        where TMasterContract : Contracts.IIdentifiable, Contracts.ICopyable<TMasterContract>
        where TMaster : Models.ModelObject, TMasterContract, new()
    {
        [Parameter]
        public MasterDetailsPage<TMasterContract, TMaster> MasterDetailsPage { get; set; }

        protected RadzenTabs RadzenTabs { get; set; }
        protected int SelectedIndex { get; set; }
        protected string Detail => MasterDetailsPage.Detail;
        protected int Index => MasterDetailsPage.Index;

        public DetailsComponent()
        {
            Constructing();
            Constructed();
        }
        partial void Constructing();
        partial void Constructed();

        protected virtual Task InitializeParametersAsync()
        {
            if (Detail.AreEquals("tabs", StringComparison.CurrentCultureIgnoreCase))
            {
                SelectedIndex = Index;
            }
            return Task.FromResult(0);
        }
        protected override Task OnParametersSetAsync()
        {
            bool handled = false;
            BeforeParametersSet(ref handled);
            if (handled == false)
            {
                InitializeParametersAsync();
            }
            AfterParametersSet();
            return base.OnParametersSetAsync();
        }
        partial void BeforeParametersSet(ref bool handled);
        partial void AfterParametersSet();
        protected override Task OnFirstRenderAsync()
        {
            return base.OnFirstRenderAsync();
        }
        protected void InitDataGridHandler(IDataGridBase dataGridBase, string modelName)
        {
            dataGridBase.CheckArgument(nameof(dataGridBase));

            TDataGridHandlerSetting dataGridHandlerSetting;
            var jsonValue = Settings.GetValue($"{modelName}DataGrid.HandlerSetting", string.Empty);

            if (jsonValue.HasContent())
            {
                dataGridHandlerSetting = JsonSerializer.Deserialize<TDataGridHandlerSetting>(jsonValue);
            }
            else
            {
                dataGridHandlerSetting = new TDataGridHandlerSetting();
            }

            dataGridBase.PageSize = dataGridHandlerSetting.PageSize;

            dataGridBase.Editable = dataGridHandlerSetting.Editable;
            dataGridBase.AllowAdd = dataGridHandlerSetting.AllowAdd;
            dataGridBase.AllowEdit = dataGridHandlerSetting.AllowEdit;
            dataGridBase.AllowDelete = dataGridHandlerSetting.AllowDelete;
            dataGridBase.AllowInlineEdit = dataGridHandlerSetting.AllowInlineEdit;

            dataGridBase.AllowPaging = dataGridHandlerSetting.AllowPaging;
            dataGridBase.AllowSorting = dataGridHandlerSetting.AllowSorting;
            dataGridBase.AllowFiltering = dataGridHandlerSetting.AllowFiltering;
            dataGridBase.HasRowDetail = dataGridHandlerSetting.HasRowDetail;
            dataGridBase.HasNavigation = dataGridHandlerSetting.HasNavigation;
        }
    }
}
//MdEnd
