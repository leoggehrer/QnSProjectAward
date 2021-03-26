//@QnSCodeCopy
//MdStart

using QnSProjectAward.BlazorApp.Models.Modules.Common;
using System;

namespace QnSProjectAward.BlazorApp.Models.Modules.Form
{
    public partial class DisplayProperty
    {
        public string Key => $"{ModelName}{OriginName}";
        public string ModelName { get; set; }
        public string OriginName { get; set; }
        public string MappingName { get; set; } = string.Empty;
        public string PropertyName => string.IsNullOrEmpty(MappingName) ? OriginName : MappingName;

        public bool ScaffoldItem { get; set; } = true;
        public bool IsModelItem { get; set; }
        public ReadonlyMode ReadonlyMode { get; set; } = ReadonlyMode.None;
        public VisibilityMode VisibilityMode { get; set; } = VisibilityMode.Visible;
        public bool ListSortable { get; set; } = true;
        public bool ListFilterable { get; set; } = true;
        public string ListWidth { get; set; } = "100%";

        public string FormatValue { get; set; } = string.Empty;
        public int Order { get; set; } = 10_000;
        public Func<object, object, string> ToDisplay { get; set; }
        public Func<string, string> GetFooterText { get; set; }

        public DisplayProperty()
            : this(string.Empty, string.Empty)
        {
        }
        public DisplayProperty(string originName)
            : this(string.Empty, originName)
        {
        }
        public DisplayProperty(string modelName, string originName)
        {
            ModelName = modelName;
            OriginName = originName;
            ToDisplay = (m, v) => v?.ToString();
            GetFooterText = n => string.Empty;
        }

        public override string ToString() => OriginName;
    }
}
//MdEnd
