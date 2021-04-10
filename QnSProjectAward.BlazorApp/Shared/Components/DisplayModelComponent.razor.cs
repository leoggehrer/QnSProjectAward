//@QnSCodeCopy
//MdStart

using CommonBase.Extensions;
using Microsoft.AspNetCore.Components;
using QnSProjectAward.BlazorApp.Models;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using TModelMember = QnSProjectAward.BlazorApp.Models.Modules.Form.DisplayModelMember;

namespace QnSProjectAward.BlazorApp.Shared.Components
{
    public partial class DisplayModelComponent
    {
        [Parameter]
        public ModelObject Model
        {
            get => model;
            set
            {
                model = value;
                CreateModelMembers();
            }
        }

        private ModelObject model;
        private IEnumerable<TModelMember> modelMembers;

        public override string ForPrefix => Model != null ? Model.GetType().Name : base.ForPrefix;
        public IEnumerable<TModelMember> ModelMembers
        {
            get => modelMembers ?? System.Array.Empty<TModelMember>();
            private set => modelMembers = value;
        }

        public DisplayModelComponent()
        {
            Constructing();
            Constructed();
        }
        partial void Constructing();
        partial void Constructed();

        private void CreateModelMembers()
        {
            bool handled = false;

            BeforeLoadContainer(ref handled);
            if (handled == false)
            {
                if (Model != null)
                {
                    var items = new List<TModelMember>();

                    foreach (var item in Model.GetType().GetAllTypeProperties())
                    {
                        var isScaffoldItem = ParentComponent.IsScaffoldItem(item.Value.PropertyInfo);

                        if (isScaffoldItem)
                        {
                            var modelMember = CreateModelMember(ParentComponent, Model, item.Value.PropertyInfo);

                            if (modelMember != null)
                            {
                                items.Add(modelMember);
                            }
                        }
                    }
                    ModelMembers = items.OrderBy(e => e.Order);
                }
            }
            AfterLoadContainer();
        }
        private TModelMember CreateModelMember(DisplayComponent displayComponent, ModelObject modelObject, PropertyInfo propertyInfo)
        {
            var handled = false;
            var modelMember = default(TModelMember);

            displayComponent?.CreateDisplayModelMember(modelObject, propertyInfo, ref modelMember, ref handled);
            if (handled == false)
            {
                CreateModelMember(Model, propertyInfo, ref modelMember, ref handled);
            }
            if (handled == false && propertyInfo.CanRead)
            {
                var displayInfo = GetOrCreateDisplayInfo(modelObject.GetType(), propertyInfo);

                modelMember = new TModelMember(modelObject, propertyInfo, displayInfo);
            }
            if (modelMember != null)
            {
                displayComponent?.CreatedDisplayModelMember(modelMember);
            }
            return modelMember;
        }
        partial void CreateModelMember(object model, PropertyInfo propertyInfo, ref TModelMember modelMember, ref bool handled);
        partial void BeforeLoadContainer(ref bool handled);
        partial void AfterLoadContainer();
    }
}
//MdEnd
