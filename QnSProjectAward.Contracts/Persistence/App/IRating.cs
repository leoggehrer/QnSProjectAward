using QnSProjectAward.Contracts.Modules.Common;

namespace QnSProjectAward.Contracts.Persistence.App
{
    public partial interface IRating : IVersionable, ICopyable<IRating>
    {
        int ProjectId { get; set; }
        int JurorId { get; set; }
        Rate Rate { get; set; }
    }
}
