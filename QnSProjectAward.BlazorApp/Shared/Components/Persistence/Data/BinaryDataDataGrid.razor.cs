//@QnSGeneratedCode
using Microsoft.AspNetCore.Components;
using Radzen;
using System.Linq;
using System.Threading.Tasks;
using TContract = QnSProjectAward.Contracts.Persistence.Data.IBinaryData;
using TModel = QnSProjectAward.BlazorApp.Models.Persistence.Data.BinaryData;
namespace QnSProjectAward.BlazorApp.Shared.Components.Persistence.Data
{
    partial class BinaryDataDataGrid
    {
        [Parameter]
        public BinaryDataDataGridHandler DataGridHandler
        {
            get;
            set;
        }
        public override string ForPrefix => "BinaryData";
    }
}
