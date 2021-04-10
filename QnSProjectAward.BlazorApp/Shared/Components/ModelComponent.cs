//@QnSCodeCopy
//MdStart

using Microsoft.AspNetCore.Components;
using QnSProjectAward.BlazorApp.Models;
using QnSProjectAward.BlazorApp.Models.Modules.Form;

namespace QnSProjectAward.BlazorApp.Shared.Components
{
    public partial class ModelComponent<TContract, TModel> : DisplayComponent
        where TContract : Contracts.IIdentifiable, Contracts.ICopyable<TContract>
        where TModel : Models.ModelObject, TContract, new()
    {
        [Parameter]
        public string Mode { get; set; }
        [Parameter]
        public IdentityModel Model { get; set; }

        protected override void InitDisplayInfoContainer(DisplayInfoContainer displayProperties)
        {
            base.InitDisplayInfoContainer(displayProperties);

            displayProperties.AddOrSet(nameof(IdentityModel.Cloneable), dp => { dp.VisibilityMode = Models.Modules.Common.VisibilityMode.Hidden; });
            displayProperties.AddOrSet(nameof(IdentityModel.CloneData), dp => { dp.VisibilityMode = Models.Modules.Common.VisibilityMode.Hidden; });
        }

        public ModelComponent()
        {
            Constructing();
            Constructed();
        }
        partial void Constructing();
        partial void Constructed();

    }
}
//MdEnd
