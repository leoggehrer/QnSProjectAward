//@QnSCodeCopy
//MdStart

using QnSProjectAward.BlazorApp.Models.Modules.Common;
using QnSProjectAward.BlazorApp.Models.Modules.Configuration;
using QnSProjectAward.BlazorApp.Models.Modules.Form;
using System.Text.Json;

namespace QnSProjectAward.BlazorApp.Models.Persistence.Configuration
{
	partial class Setting
	{
		public string State => Id > 0 ? "Stored" : "Unstored";

		public override void BeforeEdit()
		{
			SubObjects.Clear();
			try
			{
				if (Value != null && Value.Contains($"\"Type\":\"{nameof(MenuItem)}\""))
				{
					SubObjects.Add(JsonSerializer.Deserialize<MenuItem>(Value));
				}
				else if (Value != null && Value.Contains($"\"Type\":\"{nameof(DisplaySetting)}\""))
				{
					SubObjects.Add(JsonSerializer.Deserialize<DisplaySetting>(Value));
				}
				else if (Value != null && Value.Contains($"\"Type\":\"{nameof(DialogOptions)}\""))
				{
					SubObjects.Add(JsonSerializer.Deserialize<DialogOptions>(Value));
				}
				else if (Value != null && Value.Contains($"\"Type\":\"{nameof(DataGridSetting)}\""))
				{
					SubObjects.Add(JsonSerializer.Deserialize<DataGridSetting>(Value));
				}
				else if (Value != null && Value.Contains($"\"Type\":\"{nameof(DataGridHandlerSetting)}\""))
				{
					SubObjects.Add(JsonSerializer.Deserialize<DataGridHandlerSetting>(Value));
				}
			}
			catch (System.Exception ex)
			{
				System.Diagnostics.Debug.WriteLine($"Error in {System.Reflection.MethodBase.GetCurrentMethod().Name}: {ex.Message}");
			}

			base.BeforeEdit();
		}
		public override void BeforeSave()
		{
			base.BeforeSave();

			if (SubObjects.Count == 1)
			{
				var serializerOptions = new JsonSerializerOptions { IgnoreReadOnlyProperties = true };

				if (SubObjects[0] is MenuItem mim)
				{
					Value = JsonSerializer.Serialize(mim, serializerOptions);
				}
				else if (SubObjects[0] is DisplaySetting dsm)
				{
					Value = JsonSerializer.Serialize(dsm, serializerOptions);
				}
				else if (SubObjects[0] is DialogOptions dom)
				{
					Value = JsonSerializer.Serialize(dom, serializerOptions);
				}
				else if (SubObjects[0] is DataGridSetting dgsm)
				{
					Value = JsonSerializer.Serialize(dgsm, serializerOptions);
				}
				else if (SubObjects[0] is DataGridHandlerSetting dghsm)
				{
					Value = JsonSerializer.Serialize(dghsm, serializerOptions);
				}
			}
		}
		public override void EvaluateDisplayInfo(DisplayInfo displayInfo)
		{
			base.EvaluateDisplayInfo(displayInfo);

			if (displayInfo.OriginName.Equals(nameof(State)))
			{
				displayInfo.VisibilityMode = VisibilityMode.ListDetailView;
			}
			else if (displayInfo.OriginName.Equals(nameof(Value)))
			{
				if (SubObjects.Count == 1)
				{
					displayInfo.VisibilityMode = VisibilityMode.ListDetailView;
				}
				else
				{
					displayInfo.VisibilityMode = VisibilityMode.DetailCreateUpdateDeleteView;
				}
			}
			else if (displayInfo.OriginName.Equals(nameof(ConfigurationModel.Type)))
			{
				if (SubObjects.Count == 1)
				{
					displayInfo.VisibilityMode = VisibilityMode.ListDetailView;
				}
				else
				{
					displayInfo.VisibilityMode = VisibilityMode.DetailCreateUpdateDeleteView;
				}
			}
			else if (displayInfo.OriginName.Equals(nameof(ReadonlyMode)))
			{
				displayInfo.VisibilityMode = VisibilityMode.Hidden;
			}
			else if (displayInfo.OriginName.Equals(nameof(VisibilityMode)))
			{
				displayInfo.VisibilityMode = VisibilityMode.Hidden;
			}
		}
	}
}
//MdEnd
