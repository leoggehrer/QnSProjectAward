//@QnSCodeCopy
//MdStart

using CommonBase.Extensions;
using Microsoft.AspNetCore.Components;
using Radzen;
using System.Text.Json;
using DataGridSetting = QnSProjectAward.BlazorApp.Models.Modules.Configuration.DataGridSetting;

namespace QnSProjectAward.BlazorApp.Shared.Components
{
    public partial class DataGridComponent : DataGridCommonComponent
    {
        private DialogOptions editOptions;
        private DialogOptions deleteOptions;
        private DataGridSetting dataGridSetting;

        [Inject]
        protected DialogService DialogService { get; init; }

        protected override void OnAfterRender(bool firstRender)
        {
            if (firstRender)
            {
                var jsonValue = Settings.GetValue($"{ComponentName}.Setting", string.Empty);

                if (jsonValue.HasContent())
                {
                    DataGridSetting = JsonSerializer.Deserialize<DataGridSetting>(jsonValue);
                }

                jsonValue = Settings.GetValue($"{ComponentName}.EditOptions", string.Empty);
                if (jsonValue.HasContent())
                {
                    EditOptions = JsonSerializer.Deserialize<DialogOptions>(jsonValue);
                }

                jsonValue = Settings.GetValue($"{ComponentName}.DeleteOptions", string.Empty);
                if (jsonValue.HasContent())
                {
                    DeleteOptions = JsonSerializer.Deserialize<DialogOptions>(jsonValue);
                }
            }
            base.OnAfterRender(firstRender);
        }

        public DialogOptions EditOptions 
        {
            get => editOptions ??= new DialogOptions { ShowTitle = true, ShowClose = true, Width = "800px" }; 
            private set => editOptions = value; 
        }
        public DialogOptions DeleteOptions 
        {
            get => deleteOptions ??= new DialogOptions { ShowTitle = true, ShowClose = true, Width = "800px" }; 
            private set => deleteOptions = value; 
        }
        public DataGridSetting DataGridSetting 
        {
            get => dataGridSetting ??= new DataGridSetting(); 
            private set => dataGridSetting = value; 
        }

        public DataGridComponent()
        {
            Constructing();
            Constructed();
        }
        partial void Constructing();
        partial void Constructed();

    }
}
//MdEnd
