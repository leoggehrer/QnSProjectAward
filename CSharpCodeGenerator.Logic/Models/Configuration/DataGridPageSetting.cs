//@QnSCodeCopy
//MdStart

namespace CSharpCodeGenerator.Logic.Models.Configuration
{
    internal record DataGridPageSetting
	{
#pragma warning disable CA1822 // Mark members as static
		public string Type => nameof(DataGridPageSetting);
#pragma warning restore CA1822 // Mark members as static
		public int PageSize { get; set; } = 50;
		public bool AllowPaging { get; set; } = true;
		public bool AllowSorting { get; set; } = true;
		public bool AllowFiltering { get; set; } = true;
		public bool AllowAdd { get; set; } = true;
		public bool AllowEdit { get; set; } = true;
		public bool AllowDelete { get; set; } = true;
		public bool AllowInlineEdit { get; set; } = true;
		public bool HasRowDetail { get; set; } = true;
	}
}
//MdEnd
