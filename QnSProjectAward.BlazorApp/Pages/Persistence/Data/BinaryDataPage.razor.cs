//@QnSGeneratedCode
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Radzen;
using QnSProjectAward.BlazorApp.Shared.Components.Persistence.Data;
using TMasterContract = QnSProjectAward.Contracts.Persistence.Data.IBinaryData;
using TMaster = QnSProjectAward.BlazorApp.Models.Persistence.Data.BinaryData;
namespace QnSProjectAward.BlazorApp.Pages.Persistence.Data
{
    partial class BinaryDataPage
    {
        [Inject]
        protected DialogService DialogService
        {
            get;
            private set;
        }
        protected override string PageRoot => "BinaryDatas";
    }
}
