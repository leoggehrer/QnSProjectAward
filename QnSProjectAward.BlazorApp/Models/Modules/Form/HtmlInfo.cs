//@QnSCodeCopy
//MdStart

namespace QnSProjectAward.BlazorApp.Models.Modules.Form
{
    public partial class HtmlInfo
    {
        public bool Required { get; set; }
        public bool Readonly { get; set; }
        public bool Enabled { get; set; }
        public string CssClass { get; set; } = string.Empty;
        public string AttrStyle { get; set; } = string.Empty;
        public string Placeholder { get; set; } = string.Empty;
        public string Tooltip { get; set; } = string.Empty;
    }
}
//MdEnd
