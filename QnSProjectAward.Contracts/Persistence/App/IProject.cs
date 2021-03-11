using CommonBase.Attributes;

namespace QnSProjectAward.Contracts.Persistence.App
{
    [ContractInfo]
    public partial interface IProject : IVersionable, ICopyable<IProject>
    {
        int AwardId { get; set; }
        [ContractPropertyInfo(Required = true, MaxLength = 128)]
        string School { get; set; }
        [ContractPropertyInfo(Required = true, MaxLength = 256)]
        string Title { get; set; }
        [ContractPropertyInfo(Required = true, MaxLength = 1024)]
        string Description { get; set; }
        [ContractPropertyInfo(ContentType = ContentType.Upload)]
        byte[] Logo { get; set; }
    }
}




