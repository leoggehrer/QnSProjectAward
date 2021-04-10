//@QnSCodeCopy
//MdStart
using Microsoft.AspNetCore.Components;
using QnSProjectAward.BlazorApp.Services;
using Radzen;

namespace QnSProjectAward.BlazorApp.Pages
{
    public abstract partial class ModelPage : CommonPage
    {
        [Inject]
        public IServiceAdapter ServiceAdapter { get; private set; }

        public virtual Contracts.Client.IAdapterAccess<T> CreateService<T>()
            where T : Contracts.IIdentifiable
        {
            return ServiceAdapter.Create<T>(AuthorizationSession.Token);
        }

        public virtual void OnMenuItemClick(MenuItemEventArgs args)
        {
        }
    }
}
//MdEnd
