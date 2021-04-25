//@QnSCodeCopy
//MdStart

namespace QnSProjectAward.BlazorApp.Models.Modules.Configuration
{
    public partial class ModelSetting : ConfigurationModel
    {
        private bool allowAdd = true;
        private bool allowEdit = true;
        private bool allowDelete = true;

        public bool Editable { get; set; } = true;
        public bool AllowAdd
        {
            get => Editable && allowAdd;
            protected set => allowAdd = value;
        }
        public bool AllowEdit
        {
            get => Editable && allowEdit;
            protected set => allowEdit = value;
        }
        public bool AllowDelete
        {
            get => Editable && allowDelete;
            protected set => allowDelete = value;
        }
    }
}
//MdEnd
