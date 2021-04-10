//@QnSCodeCopy
//MdStart

namespace QnSProjectAward.BlazorApp.Models.Modules.Configuration
{
	public partial class DataGridHandlerSetting : ConfigurationModel
    {
        public int PageSize { get; set; } = 50;
        public bool Editable { get; set; } = true;
        public bool AllowPaging { get; set; } = true;
        public bool AllowSorting { get; set; } = true;
        public bool AllowFiltering { get; set; } = true;
        public bool AllowAdd { get; set; } = true;
        public bool AllowEdit { get; set; } = true;
        public bool AllowDelete { get; set; } = true;
        public bool AllowInlineEdit { get; set; } = true;
        public bool HasRowDetail { get; set; } = true;
        public bool HasNavigation { get; set; } = true;
    }
}
//MdEnd
