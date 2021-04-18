//@QnSCodeCopy
//MdStart

namespace QnSProjectAward.Logic.Entities.Persistence.Account
{
    partial class Identity
    {
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }

        public void CopyProperties(Identity identity)
        {
            CopyProperties(identity as Contracts.Persistence.Account.IIdentity);

            PasswordHash = identity.PasswordHash;
            PasswordSalt = identity.PasswordSalt;
        }
        public override string ToString()
        {
            return $"{Name}";
        }
    }
}
//MdEnd
