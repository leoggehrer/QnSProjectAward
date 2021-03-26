//@QnSCodeCopy
//MdStart
using CommonBase.Extensions;
using QnSProjectAward.BlazorApp.Modules.DataGrid;
using System.Collections.Generic;
using System.Text.Json;
using TDataGridPageSetting = QnSProjectAward.BlazorApp.Models.Modules.Configuration.DataGridPageSetting;
using TMenuItem = QnSProjectAward.BlazorApp.Models.Modules.Menu.MenuItem;

namespace QnSProjectAward.BlazorApp.Pages
{
    public partial class DataGridPage : ModelPage
    {
        private TDataGridPageSetting dataGridPageSetting;

        protected List<TMenuItem> MenuItems { get; } = new ();

        protected void InitDataGridHandler(IDataGridBase dataGridBase)
        {
            dataGridBase.CheckArgument(nameof(dataGridBase));

            var modelName = ComponentName.Replace("Page", string.Empty);
            var jsonValue = Settings.GetValue($"{modelName}DataGrid.PageSetting", string.Empty);

            if (jsonValue.HasContent())
            {
                DataGridPageSetting = JsonSerializer.Deserialize<TDataGridPageSetting>(jsonValue);
            }

            dataGridBase.PageSize = DataGridPageSetting.PageSize;
            dataGridBase.AllowPaging = DataGridPageSetting.AllowPaging;
            dataGridBase.AllowSorting = DataGridPageSetting.AllowSorting;
            dataGridBase.AllowFiltering = DataGridPageSetting.AllowFiltering;
            dataGridBase.AllowAdd = DataGridPageSetting.AllowAdd;
            dataGridBase.AllowEdit = DataGridPageSetting.AllowEdit;
            dataGridBase.AllowDelete = DataGridPageSetting.AllowDelete;
            dataGridBase.AllowInlineEdit = DataGridPageSetting.AllowInlineEdit;
            dataGridBase.HasRowDetail = DataGridPageSetting.HasRowDetail;

        }
        protected TDataGridPageSetting DataGridPageSetting
        {
            get => dataGridPageSetting ??= new TDataGridPageSetting();
            private set => dataGridPageSetting = value;
        }
    }
}
//MdEnd
