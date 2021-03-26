//@QnSCodeCopy
//MdStart

using QnSProjectAward.BlazorApp.Models.Modules.Common;
using System.Text.Json.Serialization;

namespace QnSProjectAward.BlazorApp.Models.Modules.Configuration
{
    public partial class DisplaySetting : ConfigurationModel
    {
        public bool ScaffoldItem { get; set; }
        public bool IsModelItem { get; set; }
        public ReadonlyMode ReadonlyMode { get; set; } = ReadonlyMode.None;
        public VisibilityMode VisibilityMode { get; set; } = VisibilityMode.Visible;

        public override void BeforeEdit()
        {
            base.BeforeEdit();

            FromReadonly();
            FromVisibility();
        }
        public override void BeforeSave()
        {
            ToReadonly();
            ToVisibility();

            base.BeforeSave();
        }
        private void FromReadonly()
        {
            ReadonlyCreate = (ReadonlyMode & ReadonlyMode.Create) > 0;
            ReadonlyUpdate = (ReadonlyMode & ReadonlyMode.Update) > 0;
        }
        private void ToReadonly()
        {
            ReadonlyMode = ReadonlyMode.None;

            if (ReadonlyCreate)
                ReadonlyMode |= ReadonlyMode.Create;

            if (ReadonlyUpdate)
                ReadonlyMode |= ReadonlyMode.Update;
        }
        private void FromVisibility()
        {
            ListView = (VisibilityMode & VisibilityMode.ListView) > 0;
            DetailView = (VisibilityMode & VisibilityMode.DetailView) > 0;
            CreateView = (VisibilityMode & VisibilityMode.CreateView) > 0;
            UpdateView = (VisibilityMode & VisibilityMode.UpdateView) > 0;
            DeleteView = (VisibilityMode & VisibilityMode.DeleteView) > 0;
        }
        private void ToVisibility()
        {
            VisibilityMode = VisibilityMode.Hidden;

            if (ListView)
                VisibilityMode |= VisibilityMode.ListView;

            if (DetailView)
                VisibilityMode |= VisibilityMode.DetailView;

            if (CreateView)
                VisibilityMode |= VisibilityMode.CreateView;

            if (UpdateView)
                VisibilityMode |= VisibilityMode.UpdateView;

            if (DeleteView)
                VisibilityMode |= VisibilityMode.DeleteView;
        }

        [JsonIgnore]
        public bool ReadonlyCreate { get; set; }
        [JsonIgnore]
        public bool ReadonlyUpdate { get; set; }


        [JsonIgnore]
        public bool ListView { get; set; }
        [JsonIgnore]
        public bool DetailView { get; set; }
        [JsonIgnore]
        public bool CreateView { get; set; }
        [JsonIgnore]
        public bool UpdateView { get; set; }
        [JsonIgnore]
        public bool DeleteView { get; set; }

        public bool ListSortable { get; set; }
        public bool ListFilterable { get; set; }
        public string FormatValue { get; set; }
        public string ListWidth { get; set; }
        public int Order { get; set; }
    }
}
