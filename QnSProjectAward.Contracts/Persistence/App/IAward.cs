using CommonBase.Attributes;
using QnSProjectAward.Contracts.Modules.Common;
using System;

namespace QnSProjectAward.Contracts.Persistence.App
{
    [ContractInfo]
    public partial interface IAward : IVersionable, ICopyable<IAward>
    {
        [ContractPropertyInfo(Required = true, MaxLength = 256)]
        string Title { get; set; }
        [ContractPropertyInfo(Required = true, MaxLength = 256)]
        string Location { get; set; }
        [ContractPropertyInfo(ContentType = ContentType.DateTime, DefaultValue = "System.DateTime.Now")]
        DateTime From { get; set; }
        [ContractPropertyInfo(ContentType = ContentType.DateTime)]
        DateTime? To { get; set; }
        [ContractPropertyInfo(DefaultValue = "Contracts.Modules.Common.AwardState.RegistrationOpen")]
        AwardState State { get; set; }
    }
}
