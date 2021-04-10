//@QnSCodeCopy
//MdStart
using CommonBase.Extensions;
using QnSProjectAward.BlazorApp.Modules.DataGrid;
using System.Collections.Generic;
using System.Text.Json;
using TDataGridHandlerSetting = QnSProjectAward.BlazorApp.Models.Modules.Configuration.DataGridHandlerSetting;
using TMenuItem = QnSProjectAward.BlazorApp.Models.Modules.Menu.MenuItem;

namespace QnSProjectAward.BlazorApp.Pages
{
	public abstract partial class DataGridPage : ModelPage
    {
        private TDataGridHandlerSetting dataGridPageSetting;
        protected abstract string PageRoot { get; }

        public override string PageName => base.PageName.Replace("DataGrid", string.Empty);
        protected virtual string NewRef => $"{PageRoot}/New/Tabs/0";

        protected List<TMenuItem> MenuItems { get; } = new ();

        protected void InitDataGridHandler(IDataGridBase dataGridBase)
        {
            dataGridBase.CheckArgument(nameof(dataGridBase));

            var modelName = ComponentName.Replace("Page", string.Empty);
            var jsonValue = Settings.GetValue($"{modelName}.HandlerSetting", string.Empty);

            if (jsonValue.HasContent())
            {
                DataGridHandlerSetting = JsonSerializer.Deserialize<TDataGridHandlerSetting>(jsonValue);
            }

            dataGridBase.PageSize = DataGridHandlerSetting.PageSize;

            dataGridBase.Editable = DataGridHandlerSetting.Editable;
            dataGridBase.AllowAdd = DataGridHandlerSetting.AllowAdd;
            dataGridBase.AllowEdit = DataGridHandlerSetting.AllowEdit;
            dataGridBase.AllowDelete = DataGridHandlerSetting.AllowDelete;
            dataGridBase.AllowInlineEdit = DataGridHandlerSetting.AllowInlineEdit;

            dataGridBase.AllowPaging = DataGridHandlerSetting.AllowPaging;
            dataGridBase.AllowSorting = DataGridHandlerSetting.AllowSorting;
            dataGridBase.AllowFiltering = DataGridHandlerSetting.AllowFiltering;
            dataGridBase.HasRowDetail = DataGridHandlerSetting.HasRowDetail;
            dataGridBase.HasNavigation = DataGridHandlerSetting.HasNavigation;
        }
        protected TDataGridHandlerSetting DataGridHandlerSetting
        {
            get => dataGridPageSetting ??= new TDataGridHandlerSetting();
            private set => dataGridPageSetting = value;
        }
    }
}
//MdEnd
