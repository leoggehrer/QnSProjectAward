//@QnSCodeCopy
//MdStart

namespace QnSProjectAward.Transfer
{
    public abstract partial class VersionModel : IdentityModel, Contracts.IVersionable
    {
        public virtual byte[] RowVersion { get; set; }
    }
}
//MdEnd
