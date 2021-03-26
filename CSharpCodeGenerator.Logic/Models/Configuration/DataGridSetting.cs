//@QnSCodeCopy
//MdStart

namespace CSharpCodeGenerator.Logic.Models.Configuration
{
	internal record DataGridSetting
    {
#pragma warning disable CA1822 // Mark members as static
        public string Type => nameof(DataGridSetting);
#pragma warning restore CA1822 // Mark members as static
        public bool HasDataGridProgress { get; set; } = true;
        public bool HasEditDialogHeader { get; set; } = false;
        public bool HasEditDialogFooter { get; set; } = true;
        public bool HasDeleteDialogHeader { get; set; } = false;
        public bool HasDeleteDialogFooter { get; set; } = true;
    }
}
//MdEnd
