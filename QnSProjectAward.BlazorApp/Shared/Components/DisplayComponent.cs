//@QnSCodeCopy
//MdStart

using CommonBase.Extensions;
using Microsoft.AspNetCore.Components;
using QnSProjectAward.BlazorApp.Models;
using QnSProjectAward.BlazorApp.Models.Modules.Form;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text.Json;

namespace QnSProjectAward.BlazorApp.Shared.Components
{
    public partial class DisplayComponent : CommonComponent
    {
        [Parameter]
        public DisplayComponent ParentComponent { get; set; }
        protected DisplayInfoContainer DisplayInfos { get; } = new DisplayInfoContainer();

        #region EventHandler
        public event EventHandler<DisplayInfoContainer> InitDisplayPropertiesHandler;

        public event EventHandler<DisplayModelMemberInfo> CreateDisplayModelMemberHandler;
        public event EventHandler<DisplayModelMember> CreatedDisplayModelMemberHandler;

        public event EventHandler<EditModelMemberInfo> CreateEditModelMemberHandler;
        public event EventHandler<EditModelMember> CreatedEditModelMemberHandler;

        public event EventHandler<DisplayInfo> EvaluateDisplayPropertyHandler;
        public event EventHandler<ModelDisplayProperty> ShowModelDisplayPropertyHandler;
        #endregion EventHandler

        public DisplayComponent()
        {
            Constructing();
            Constructed();
        }
        partial void Constructing();
        partial void Constructed();

        protected virtual void InitDisplayInfoContainer(DisplayInfoContainer displayProperties)
        {
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

        protected override void OnInitialized()
        {
            base.OnInitialized();

            BeforeInitialized();
            InitDisplayInfoContainer(DisplayInfos);
            InitDisplayPropertiesHandler?.Invoke(this, DisplayInfos);
            AfterInitialized();
        }
        protected virtual void BeforeInitialized()
        {
        }
        protected virtual void AfterInitialized()
        {
        }

        public virtual IEnumerable<DisplayInfo> GetAllDisplayProperties()
        {
            var handled = false;
            var result = new List<DisplayInfo>();

            BeforeGetAllDisplayProperties(result, ref handled);
            if (handled == false)
            {
                foreach (var item in DisplayInfos)
                {
                    result.Add(item.Value);
                }
                if (ParentComponent != null)
                {
                    result.AddRange(ParentComponent.GetAllDisplayProperties());
                }
            }
            AfterGetAllDisplayProperties(result);
            return result;
        }
        partial void BeforeGetAllDisplayProperties(List<DisplayInfo> result, ref bool handled);
        partial void AfterGetAllDisplayProperties(List<DisplayInfo> result);

        public virtual DisplayInfo GetDisplayProperty(PropertyInfo propertyInfo)
        {
            propertyInfo.CheckArgument(nameof(propertyInfo));

            var handled = false;
            var result = default(DisplayInfo);
            var originName = propertyInfo.Name;

            BeforeGetDisplayInfo(originName, ref result, ref handled);
            if (handled == false)
            {
                result = ParentComponent?.GetDisplayProperty(propertyInfo);
                if (result == default)
                {
                    DisplayInfos.TryGetValue(originName, out result);
                }
            }
            AfterGetDisplayInfo(originName, result);
            return result;
        }
        partial void BeforeGetDisplayInfo(string originName, ref DisplayInfo result, ref bool handled);
        partial void AfterGetDisplayInfo(string originName, DisplayInfo result);

        public virtual DisplayInfo GetDisplayInfo(Type modelType, PropertyInfo propertyInfo)
        {
            modelType.CheckArgument(nameof(modelType));
            propertyInfo.CheckArgument(nameof(propertyInfo));

            var handled = false;
            var result = default(DisplayInfo);
            var modelName = modelType.Name;
            var originName = propertyInfo.Name;

            BeforeGetDisplayInfo(modelName, originName, ref result, ref handled);
            if (handled == false)
            {
                result = ParentComponent?.GetDisplayInfo(modelType, propertyInfo);
                if (result == default)
                {
                    if (DisplayInfos.TryGetValue($"{modelName}{originName}", out result) == false)
                    {
                        DisplayInfos.TryGetValue($"{originName}", out result);
                    }
                }
            }
            AfterGetDisplayInfo(modelName, originName, result);
            return result;
        }
        partial void BeforeGetDisplayInfo(string modelName, string originName, ref DisplayInfo result, ref bool handled);
        partial void AfterGetDisplayInfo(string modelName, string originName, DisplayInfo result);

        private record DisplayItem(string FormatValue, bool ScaffoldItem, bool Readonly, bool Visible, bool DisplayVisible, bool EditVisible, bool ListSortable, bool ListFilterable, string ListWidth, int Order);
        public virtual DisplayInfo GetOrCreateDisplayInfo(Type modelType, PropertyInfo propertyInfo)
        {
            modelType.CheckArgument(nameof(modelType));

            var result = GetDisplayInfo(modelType, propertyInfo);

            if (result == null)
            {
                var jsonValue = Settings.GetValue($"{modelType.Name}.{propertyInfo.Name}", string.Empty);

                if (jsonValue.HasContent())
                {
                    result = JsonSerializer.Deserialize<DisplayInfo>(jsonValue);
                    result.ModelName = modelType.Name;
                    result.OriginName = propertyInfo.Name;
                }
                else
                {
                    result = GetDisplayProperty(propertyInfo);
                    if (result == null)
                    {
                        jsonValue = Settings.GetValue($"{propertyInfo.Name}", string.Empty);

                        if (jsonValue.HasContent())
                        {
                            result = JsonSerializer.Deserialize<DisplayInfo>(jsonValue);
                            result.ModelName = modelType.Name;
                            result.OriginName = propertyInfo.Name;
                        }
                        else
                        {
                            result = new DisplayInfo(modelType.Name, propertyInfo.Name);
                        }
                    }
                }
            }
            return result;
        }

        public virtual bool IsScaffoldItem(PropertyInfo propertyInfo)
        {
            propertyInfo.CheckArgument(nameof(propertyInfo));

            var result = ParentComponent == null || ParentComponent.IsScaffoldItem(propertyInfo);

            if (result && DisplayInfos.TryGetValue(propertyInfo.Name, out DisplayInfo dp))
            {
                result = dp.ScaffoldItem;
            }
            return result;
        }
        public virtual void CreateDisplayModelMember(ModelObject model, PropertyInfo propertyInfo, ref DisplayModelMember modelMember, ref bool handled)
        {
            ParentComponent?.CreateDisplayModelMember(model, propertyInfo, ref modelMember, ref handled);
            if (handled == false)
            {
                var memberInfo = new DisplayModelMemberInfo()
                {
                    Model = model,
                    Property = propertyInfo,
                    Created = false,
                };
                CreateDisplayModelMemberHandler?.Invoke(this, memberInfo);
                handled = memberInfo.Created;
                if (handled)
                {
                    modelMember = memberInfo.ModelMember;
                }
            }
        }
        public virtual void CreatedDisplayModelMember(DisplayModelMember modelMember)
        {
            modelMember.CheckArgument(nameof(modelMember));
            ParentComponent?.CreatedDisplayModelMember(modelMember);
            CreatedDisplayModelMemberHandler?.Invoke(this, modelMember);
        }
        public virtual void CreateEditModelMember(ModelObject model, PropertyInfo propertyInfo, ref EditModelMember modelMember, ref bool handled)
        {
            ParentComponent?.CreateEditModelMember(model, propertyInfo, ref modelMember, ref handled);
            if (handled == false)
            {
                var memberInfo = new EditModelMemberInfo()
                {
                    Model = model,
                    Property = propertyInfo,
                    Created = false,
                };
                CreateEditModelMemberHandler?.Invoke(this, memberInfo);
                handled = memberInfo.Created;
                if (handled)
                {
                    modelMember = memberInfo.ModelMember;
                }
            }
        }
        public virtual void CreatedEditModelMember(EditModelMember modelMember)
        {
            modelMember.CheckArgument(nameof(modelMember));

            ParentComponent?.CreatedEditModelMember(modelMember);
            CreatedEditModelMemberHandler?.Invoke(this, modelMember);
        }

        public virtual void EvaluateDisplayInfo(DisplayInfo displayInfo)
        {
            displayInfo.CheckArgument(nameof(displayInfo));

            var handled = false;

            BeforeEvaluateDisplayInfo(displayInfo, ref handled);
            if (handled == false)
            {
                ParentComponent?.EvaluateDisplayInfo(displayInfo);
                EvaluateDisplayPropertyHandler?.Invoke(this, displayInfo);
            }
            AfterEvaluteDisplayInfo(displayInfo);
        }
        partial void BeforeEvaluateDisplayInfo(DisplayInfo displayInfo, ref bool handled);
        partial void AfterEvaluteDisplayInfo(DisplayInfo displayInfo);

        public virtual void ShowModelDisplayProperty(ModelDisplayProperty modelDisplayProperty)
        {
            modelDisplayProperty.CheckArgument(nameof(modelDisplayProperty));

            var handled = false;

            BeforeShowModelDisplayProperty(modelDisplayProperty, ref handled);
            if (handled == false)
            {
                ParentComponent?.ShowModelDisplayProperty(modelDisplayProperty);
                ShowModelDisplayPropertyHandler?.Invoke(this, modelDisplayProperty);
            }
            AfterShowModelDisplayProperty(modelDisplayProperty);
        }
        partial void BeforeShowModelDisplayProperty(ModelDisplayProperty modelProperty, ref bool handled);
        partial void AfterShowModelDisplayProperty(ModelDisplayProperty modelProperty);
    }
}
//MdEnd
