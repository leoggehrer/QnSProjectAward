//@QnSGeneratedCode
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Radzen;
using QnSProjectAward.BlazorApp.Shared.Components.Persistence.Configuration;
using TMasterContract = QnSProjectAward.Contracts.Persistence.Configuration.ISetting;
using TMaster = QnSProjectAward.BlazorApp.Models.Persistence.Configuration.Setting;
namespace QnSProjectAward.BlazorApp.Pages.Persistence.Configuration
{
    partial class SettingPage
    {
        [Inject]
        protected DialogService DialogService
        {
            get;
            private set;
        }
        protected override string PageRoot => "Settings";
        private string[] detailNames;
        protected override string[] DetailNames
        {
            get
            {
                return detailNames ??= new string[]
                {
                }
                ;
            }
        }
    }
}
