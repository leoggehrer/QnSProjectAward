//@QnSCodeCopy
//MdStart
using QnSProjectAward.Contracts;
using QnSProjectAward.Contracts.Client;

namespace QnSProjectAward.BlazorApp.Services
{
	public interface IServiceAdapter
    {
        IAdapterAccess<I> Create<I>() where I : IIdentifiable;
        IAdapterAccess<I> Create<I>(string sessionToken) where I : IIdentifiable;
    }
}
//MdEnd
