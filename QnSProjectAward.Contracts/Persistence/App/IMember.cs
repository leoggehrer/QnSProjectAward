using CommonBase.Attributes;

namespace QnSProjectAward.Contracts.Persistence.App
{
    [ContractInfo]
    public partial interface IMember : IVersionable, ICopyable<IMember>
    {
        int ProjectId { get; set; }
        [ContractPropertyInfo(Required = true, MaxLength = 256)]
        string Name { get; set; }
        [ContractPropertyInfo(Required = true, MaxLength = 20)]
        string Course { get; set; }
        [ContractPropertyInfo(Required = true, MaxLength = 128)]
        string Email { get; set; }
        [ContractPropertyInfo(Required = false, MaxLength = 64)]
        string Phone { get; set; }
        [ContractPropertyInfo(Required = true, MaxLength = 128)]
        string Role { get; set; }
    }
}




