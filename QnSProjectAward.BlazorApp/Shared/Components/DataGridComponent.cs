//@QnSCodeCopy
//MdStart

using CommonBase.Extensions;
using Microsoft.AspNetCore.Components;
using QnSProjectAward.BlazorApp.Models;
using QnSProjectAward.BlazorApp.Models.Modules.Form;
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

        protected override void InitDisplayProperties(DisplayPropertyContainer displayProperties)
        {
            base.InitDisplayProperties(displayProperties);

            displayProperties.AddOrSet(nameof(IdentityModel.Id), dp => 
            {
                dp.ReadonlyMode = Models.Modules.Common.ReadonlyMode.Readonly;
                dp.VisibilityMode = Models.Modules.Common.VisibilityMode.Hidden;
                dp.IsModelItem = false;
                dp.ListWidth = "100px";
                dp.Order = 100;
            });
            displayProperties.AddOrSet(nameof(IdentityModel.Cloneable), dp => { dp.ScaffoldItem = false; });
            displayProperties.AddOrSet(nameof(IdentityModel.CloneData), dp => { dp.ScaffoldItem = false; });
            displayProperties.AddOrSet(nameof(VersionModel.RowVersion), dp => { dp.ScaffoldItem = false; });

            displayProperties.AddOrSet("OneItem", dp => { dp.ScaffoldItem = false; });
            displayProperties.AddOrSet("OneModel", dp => { dp.ScaffoldItem = false; });
            displayProperties.AddOrSet("ManyItems", dp => { dp.ScaffoldItem = false; });
            displayProperties.AddOrSet("ManyModels", dp => { dp.ScaffoldItem = false; });
        }
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
