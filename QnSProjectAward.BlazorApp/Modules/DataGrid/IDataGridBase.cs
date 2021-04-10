//@QnSCodeCopy
//MdStart
using QnSProjectAward.BlazorApp.Pages;
using System.Threading.Tasks;

namespace QnSProjectAward.BlazorApp.Modules.DataGrid
{
	public interface IDataGridBase
    {
        ModelPage ModelPage { get; }

        int Count { get; }
        string AccessFilter { get; set; }
        bool IsLoadDataActive { get; }

        int PageSize { get; set; }
        bool Editable { get; set; }
        bool AllowAdd { get; set; }
        bool AllowDelete { get; set; }
        bool AllowEdit { get; set; }
        bool AllowFiltering { get; set; }
        bool AllowInlineEdit { get; set; }
        bool AllowPaging { get; set; }
        bool AllowSorting { get; set; }
        bool HasRowDetail { get; set; }
        bool HasNavigation { get; set; }

        Task ReloadDataAsync();
    }
}
//MdEnd
