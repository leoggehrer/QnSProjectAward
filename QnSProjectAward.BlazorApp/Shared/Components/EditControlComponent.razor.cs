//@QnSCodeCopy
//MdStart

using Microsoft.AspNetCore.Components;
using QnSProjectAward.BlazorApp.Models.Modules.Form;
using TMember = QnSProjectAward.BlazorApp.Models.Modules.Form.EditModelMember;

namespace QnSProjectAward.BlazorApp.Shared.Components
{
    public partial class EditControlComponent
    {
        [Parameter]
        public TMember ModelMember { get; set; }
        [Parameter]
        public HtmlInfo HtmlInfo { get; set; }

        public EditControlComponent()
        {
            Constructing();
            Constructed();
        }
        partial void Constructing();
        partial void Constructed();
    }
}
//MdEnd
