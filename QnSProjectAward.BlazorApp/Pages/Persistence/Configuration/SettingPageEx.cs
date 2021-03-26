//@QnSCodeCopy
//MdStart
using QnSProjectAward.BlazorApp.Shared.Components.Persistence.Configuration;
using TContract = QnSProjectAward.Contracts.Persistence.Configuration.ISetting;
using TModel = QnSProjectAward.BlazorApp.Models.Persistence.Configuration.Setting;

namespace QnSProjectAward.BlazorApp.Pages.Persistence.Configuration
{
	partial class SettingPage
	{
		partial void BeforeFirstRender(ref bool handled)
		{
			handled = true;

			AdapterAccess = ServiceAdapter.Create<TContract>();
			DataGridHandler = new SettingDataGridHandler(this, new SettingAdapterAccess(AdapterAccess, Settings));
			DataGridHandler.PageSize = Settings.GetValueTyped<int>($"{ComponentName}.{nameof(DataGridHandler.PageSize)}", DataGridHandler.PageSize);
		}
	}
}
//MdEnd
