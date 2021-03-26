//@QnSCodeCopy
//MdStart

namespace QnSProjectAward.BlazorApp.Modules.DataGrid
{
    public interface IDataGridBase
    {
        int PageSize { get; set; }
        bool AllowAdd { get; set; }
        bool AllowDelete { get; set; }
        bool AllowEdit { get; set; }
        bool AllowFiltering { get; set; }
        bool AllowInlineEdit { get; set; }
        bool AllowPaging { get; set; }
        bool AllowSorting { get; set; }
        bool HasRowDetail { get; set; }
    }
}
//MdEnd
