//@QnSGeneratedCode
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Radzen;
using QnSProjectAward.BlazorApp.Modules.DataGrid;
using QnSProjectAward.BlazorApp.Shared.Components.Persistence.Data;
using TContract = QnSProjectAward.Contracts.Persistence.Data.IBinaryData;
using TModel = QnSProjectAward.BlazorApp.Models.Persistence.Data.BinaryData;
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
        protected BinaryDataDataGridHandler DataGridHandler
        {
            get;
            private set;
        }
        protected Contracts.Client.IAdapterAccess<TContract> AdapterAccess
        {
            get;
            private set;
        }
        protected override Task OnFirstRenderAsync()
        {
            bool handled = false;
            BeforeFirstRender(ref handled);
            if (handled == false)
            {
                AdapterAccess = ServiceAdapter.Create<TContract>();
                DataGridHandler = new BinaryDataDataGridHandler(this, new DataAdapterAccess<TContract>(AdapterAccess));
                InitDataGridHandler(DataGridHandler);
            }
            AfterFirstRender();
            return base.OnFirstRenderAsync();
        }
        partial void BeforeFirstRender(ref bool handled);
        partial void AfterFirstRender();
    }
}
