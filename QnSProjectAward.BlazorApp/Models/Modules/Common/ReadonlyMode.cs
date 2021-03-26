//@QnSCodeCopy
//MdStart

namespace QnSProjectAward.BlazorApp.Models.Modules.Common
{
	[System.Flags]
    public enum ReadonlyMode : byte
    {
        None = 0,
        Create = 1,
        Update = 2,

        Readonly = Create + Update,
    }
}
//MdEnd
