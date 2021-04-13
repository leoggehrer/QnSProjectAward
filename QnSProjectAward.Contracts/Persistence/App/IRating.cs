using QnSProjectAward.Contracts.Modules.Common;

namespace QnSProjectAward.Contracts.Persistence.App
{
    public partial interface IRating : IVersionable, ICopyable<IRating>
    {
        int JurorId { get; set; }
        int ProjectId { get; set; }
        RateCategory Category { get; set; }
        Rate Rate { get; set; }
    }
}
