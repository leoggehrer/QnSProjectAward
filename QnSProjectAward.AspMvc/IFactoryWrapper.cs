//@QnSCodeCopy
//MdStart
using QnSProjectAward.Contracts;
using QnSProjectAward.Contracts.Client;

namespace QnSProjectAward.AspMvc
{
    public interface IFactoryWrapper
    {
        IAdapterAccess<I> Create<I>() where I : IIdentifiable;
        IAdapterAccess<I> Create<I>(string sessionToken) where I : IIdentifiable;
    }
}
//MdEnd
