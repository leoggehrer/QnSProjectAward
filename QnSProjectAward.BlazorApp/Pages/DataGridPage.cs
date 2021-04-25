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
        protected abstract string PageRoot { get; }

        public override string PageName => base.PageName.Replace("DataGrid", string.Empty);

        protected List<TMenuItem> MenuItems { get; } = new ();

        protected virtual void InitDataGridHandler(IDataGridBase dataGridBase)
        {
            dataGridBase.CheckArgument(nameof(dataGridBase));

            var modelName = ComponentName.Replace("Page", string.Empty);
            var jsonValue = Settings.GetValue($"{modelName}.HandlerSetting", string.Empty);
            var dataGridHandlerSetting = new TDataGridHandlerSetting();

            if (jsonValue.HasContent())
            {
                try
                {
                    dataGridHandlerSetting = JsonSerializer.Deserialize<TDataGridHandlerSetting>(jsonValue);
                }
                catch (System.Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine($"Error in {System.Reflection.MethodBase.GetCurrentMethod().Name}: {ex.Message}");
                }
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
        public virtual void AddItem()
        {
            var navigateUri = $"{PageRoot}/New";

            NavigationManager.NavigateTo(navigateUri);
        }
    }
}
//MdEnd
