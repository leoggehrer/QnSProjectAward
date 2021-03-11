using CommonBase.Attributes;

namespace QnSProjectAward.Contracts.Persistence.App
{
    [ContractInfo]
    public partial interface IJuror : IVersionable, ICopyable<IJuror>
    {
        int AwardId { get; set; }
        [ContractPropertyInfo(Required = true, MaxLength = 256)]
        string Name { get; set; }
        [ContractPropertyInfo(Required = true, MaxLength = 256)]
        string Institution { get; set; }
        [ContractPropertyInfo(Required = false, MaxLength = 128)]
        string Position { get; set; }
        [ContractPropertyInfo(Required = true, MaxLength = 128)]
        string Email { get; set; }
        [ContractPropertyInfo(ContentType = ContentType.Upload)]
        byte[] Logo { get; set; }
    }
}




