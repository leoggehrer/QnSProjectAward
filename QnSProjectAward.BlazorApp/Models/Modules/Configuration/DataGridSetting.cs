//@QnSCodeCopy
//MdStart

namespace QnSProjectAward.BlazorApp.Models.Modules.Configuration
{
    public partial class DataGridSetting : ConfigurationModel
    {
        public bool HasDataGridProgress { get; set; } = true;
        public bool HasEditDialogHeader { get; set; } = false;
        public bool HasApplyButton { get; set; } = true;
        public bool HasRefreshButton { get; set; } = true;
        public bool HasEditDialogFooter { get; set; } = true;
        public bool HasDeleteDialogHeader { get; set; } = false;
        public bool HasDeleteDialogFooter { get; set; } = true;
    }
}
//MdEnd
