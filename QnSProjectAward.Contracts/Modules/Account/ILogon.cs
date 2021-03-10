//@QnSCodeCopy
//MdStart

namespace QnSProjectAward.Contracts.Modules.Account
{
    public partial interface ILogon
    {
        string Email { get; set; }
        string Password { get; set; }
        string OptionalInfo { get; set; }
    }
}
//MdEnd
