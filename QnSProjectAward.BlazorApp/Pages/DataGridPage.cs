//@QnSCodeCopy
//MdStart
using QnSProjectAward.BlazorApp.Models.Modules.Menu;
using System.Collections.Generic;

namespace QnSProjectAward.BlazorApp.Pages
{
	public partial class DataGridPage : ModelPage
    {
        protected List<MenuItem> MenuItems { get; } = new List<MenuItem>();
    }
}
//MdEnd
