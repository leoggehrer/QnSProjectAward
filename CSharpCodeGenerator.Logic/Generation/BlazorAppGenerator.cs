//@QnSCodeCopy
//MdStart

using CommonBase.Extensions;
using CSharpCodeGenerator.Logic.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace CSharpCodeGenerator.Logic.Generation
{
    internal partial class BlazorAppGenerator : ModelGenerator, Contracts.IBlazorAppGenerator
    {
        #region Pages-Definitions
        public string ProjectName => $"{SolutionProperties.SolutionName}{SolutionProperties.BlazorAppPostfix}";
        public static string PageExtension => ".razor";
        public static string CodeExtension => ".cs";
        public static string UsingsLabel => "Usings";
        public static string NamespaceCodeLabel => "NamespaceCode";
        public static string ClassCodeLabel => "ClassCode";
        public static string DataGridPagePostfix => "DataGridPage";
        public static string PagePostfix => "Page";
        public static string ComponentePostfix => "Component";

        public static string PagesFolder => "Pages";
        public static string SharedFolder => "Shared";
        public static string ComponentsFolder => "Components";
        public static string TemplatesSubPath => Path.Combine("Templates", "Blazor");

        #endregion Pages-Definitions

        protected BlazorAppGenerator(SolutionProperties solutionProperties)
            : base(solutionProperties)
        {
        }
        public new static BlazorAppGenerator Create(SolutionProperties solutionProperties)
        {
            return new BlazorAppGenerator(solutionProperties);
        }

        public override Common.UnitType UnitType => Common.UnitType.BlazorApp;
        public override string AppPostfix => SolutionProperties.BlazorAppPostfix;
        public override string AppModelsNameSpace => $"{SolutionProperties.BlazorAppProjectName}.{StaticLiterals.ModelsFolder}";
        public override string ModelsFolder => "Models";

        public string CreatePagesNameSpace(Type type)
        {
            type.CheckArgument(nameof(type));

            return $"{SolutionProperties.BlazorAppProjectName}.{PagesFolder}.{CreateSubNamespaceFromType(type)}";
        }
        public string CreateComponentsNameSpace(Type type)
        {
            type.CheckArgument(nameof(type));

            return $"{SolutionProperties.BlazorAppProjectName}.{SharedFolder}.{ComponentsFolder}.{CreateSubNamespaceFromType(type)}";
        }

        private bool CanCreateIndexPage(Type type)
        {
            bool create = true;

            CanCreateIndexPage(type, ref create);
            return create;
        }
        partial void CanCreateIndexPage(Type type, ref bool create);
        private bool CanCreateMasterPage(Type type)
        {
            bool create = true;

            CanCreateMasterPage(type, ref create);
            return create;
        }
        partial void CanCreateMasterPage(Type type, ref bool create);

        protected override void CreateModelPropertyAttributes(Type type, PropertyInfo propertyInfo, List<string> codeLines)
        {
            base.CreateModelPropertyAttributes(type, propertyInfo, codeLines);

            var handled = false;

            BeforeCreateModelPropertyAttributes(type, propertyInfo, codeLines, ref handled);
            if (handled == false)
            {
                var propertyHelper = new ContractPropertyHelper(propertyInfo);

                if (propertyHelper.IsRequired)
                {
                    codeLines.Add("[System.ComponentModel.DataAnnotations.Required]");
                }
                if (propertyInfo.PropertyType.Equals(typeof(string)) && propertyHelper.MaxLength > 0)
                {
                    codeLines.Add($"[System.ComponentModel.DataAnnotations.StringLength({propertyHelper.MaxLength})]");
                }
                if (propertyHelper.RegularExpression.HasContent())
                {
                    codeLines.Add($"[System.ComponentModel.DataAnnotations.RegularExpression(@\"{propertyHelper.RegularExpression}\")]");
                }
                if (propertyHelper.ContentType != CommonBase.Attributes.ContentType.Undefined)
                {
                    codeLines.Add($"[System.ComponentModel.DataAnnotations.DataType(System.ComponentModel.DataAnnotations.DataType.{propertyHelper.ContentType})]");
                }
            }
            AfterCreateModelPropertyAttributes(type, propertyInfo, codeLines);
        }
        partial void BeforeCreateModelPropertyAttributes(Type type, PropertyInfo propertyInfo, List<string> codeLines, ref bool handled);
        partial void AfterCreateModelPropertyAttributes(Type type, PropertyInfo propertyInfo, List<string> codeLines);

        public IEnumerable<Contracts.IGeneratedItem> CreateBusinessIndexPages()
        {
            var result = new List<Contracts.IGeneratedItem>();
            var contractsProject = ContractsProject.Create(SolutionProperties);

            foreach (var type in contractsProject.BusinessTypes)
            {
                if (CanCreateIndexPage(type))
                {
                    result.AddRange(CreateDataGridPage(type, StaticLiterals.BusinessLabel));
                    result.AddRange(CreateDisplayComponents(type, StaticLiterals.BusinessLabel));
                }
            }
            return result;
        }
        public IEnumerable<Contracts.IGeneratedItem> CreatePersistenceIndexPages()
        {
            var result = new List<Contracts.IGeneratedItem>();
            var contractsProject = ContractsProject.Create(SolutionProperties);

            foreach (var type in contractsProject.PersistenceTypes)
            {
                if (CanCreateIndexPage(type))
                {
                    result.AddRange(CreateDataGridPage(type, StaticLiterals.PersistenceLabel));
                    result.AddRange(CreateDisplayComponents(type, StaticLiterals.PersistenceLabel));
                }
                if (CanCreateMasterPage(type))
                {
                    var contractHelper = new ContractHelper(type);
                    var persistenceAndBusinessTypes = contractsProject.PersistenceTypes
                                                                      .Union(contractsProject.BusinessTypes);
                    var details = contractHelper.GetDetailTypes(persistenceAndBusinessTypes);

                    result.Add(CreateMasterDetailsPageRazor(type, details));
                    result.Add(CreateMasterDetailsPageCode(type, details));
                }
            }
            return result;
        }
        public IEnumerable<Contracts.IGeneratedItem> CreateShadowIndexPages()
        {
            var result = new List<Contracts.IGeneratedItem>();
            var contractsProject = ContractsProject.Create(SolutionProperties);

            foreach (var type in contractsProject.ShadowTypes)
            {
                if (CanCreateIndexPage(type))
                {
                    result.AddRange(CreateDataGridPage(type, StaticLiterals.ShadowLabel));
                    result.AddRange(CreateDisplayComponents(type, StaticLiterals.ShadowLabel));
                }
            }
            return result;
        }
        public IEnumerable<Contracts.IGeneratedItem> CreateDataGridPage(Type type, string typeLabel)
        {
            type.CheckArgument(nameof(type));
            typeLabel.CheckArgument(nameof(typeLabel));

            var result = new List<Contracts.IGeneratedItem>();

            StartCreateDataGridPage(type, typeLabel);

            result.Add(CreateDataGridPageRazor(type));
            result.Add(CreateDataGridPageCode(type));

            FinishCreateIndexPage(type, typeLabel);
            return result;
        }
        partial void StartCreateDataGridPage(Type type, string typeLabel);
        partial void FinishCreateIndexPage(Type type, string typeLabel);

        private Contracts.IGeneratedItem CreateDataGridPageRazor(Type type)
        {
            type.CheckArgument(nameof(type));

            var subPath = CreateSubPathFromType(type);
            var projectPagePath = Path.Combine(ProjectName, PagesFolder, subPath);
            var entityName = CreateEntityNameFromInterface(type);
            var entityFullName = $"{CreateModelsNamespace(type)}.{entityName}";
            var pluralPageName = CreatePluralWord(entityName);
            var fileNameRazor = $"{entityName}{DataGridPagePostfix}{PageExtension}";
            var result = new Models.GeneratedItem(Common.UnitType.BlazorApp, Common.ItemType.DataGridRazorPage)
            {
                FullName = CreateEntityFullNameFromInterface(type),
                FileExtension = PageExtension,
            };
            result.SubFilePath = Path.Combine(projectPagePath, fileNameRazor);
            StartCreateDataGridPageRazor(type, result.Source);

            result.Add($"@page \"/{pluralPageName}\"");
            result.Add($"@using TContract = {type.FullName};");
            result.Add($"@using TModel = {entityFullName};");
            result.Add("@using Radzen;");
            result.Add("@inherits Pages.DataGridPage");
            result.Add(string.Empty);

            result.Add("@*EmbeddedBegin:File=_DataGridPage.template:Label=DefaultPage*@");
            result.Add("@*EmbeddedEnd:Label=DefaultPage*@");

            result.AddRange(EmbeddedTagReplacer.ReplaceEmbeddedTags(result.Source.Eject(), TemplatesSubPath, "@*", "*@", (st, et, rt, p) => EmbeddedTagManager.Handle(type, st, et, rt, p))
                                            .Select(l => l.Replace("File=TModel", $"File=_{entityName}.template"))
                                            .Select(l => l.Replace("Type=TModel", $"Type={entityFullName}"))
                                            );
            result.AddRange(EmbeddedTagReplacer.ReplaceEmbeddedTags(result.Source.Eject(), TemplatesSubPath, "@*", "*@", (st, et, rt, p) => EmbeddedTagManager.Handle(type, st, et, rt, p)));

            result.Add("@if (CanRender)");
            result.Add("{");
            result.Add($"\t<{CreateComponentsNameSpace(type)}.{entityName}DataGrid DataGridHandler=\"DataGridHandler\" />");
            result.Add("}");
            result.Add("else");
            result.Add("{");
            result.Add("\t<QnSProjectAward.BlazorApp.Shared.Components.LoadingIndicator />");
            result.Add("}");

            FinishCreateDataGridPageRazor(type, result.Source);
            return result;
        }
        partial void StartCreateDataGridPageRazor(Type type, List<string> lines);
        partial void FinishCreateDataGridPageRazor(Type type, List<string> lines);

        private Contracts.IGeneratedItem CreateDataGridPageCode(Type type)
        {
            type.CheckArgument(nameof(type));

            var customUsings = new List<string>();
            var customNamespaceCode = new List<string>();
            var customClassCode = new List<string>();
            var subPath = CreateSubPathFromType(type);
            var projectPagePath = Path.Combine(ProjectName, PagesFolder, subPath);
            var entityName = CreateEntityNameFromInterface(type);
            var entityFullName = $"{CreateModelsNamespace(type)}.{entityName}";
            var pluralPageName = CreatePluralWord(entityName);
            var fileNameRazor = $"{entityName}{DataGridPagePostfix}{PageExtension}";
            var fileNameRazorCode = $"{fileNameRazor}{CodeExtension}";
            var filePathRazorCode = Path.Combine(ProjectName, subPath, fileNameRazorCode);
            var result = new Models.GeneratedItem(Common.UnitType.BlazorApp, Common.ItemType.DataGridRazorPageCode)
            {
                FullName = CreateEntityFullNameFromInterface(type),
                FileExtension = CodeExtension,
            };
            result.SubFilePath = Path.Combine(projectPagePath, fileNameRazorCode);

            StartCreateDataGridPageCode(type, result.Source);
            if (File.Exists(filePathRazorCode))
            {
                var fileCode = File.ReadAllText(filePathRazorCode, Encoding.Default);

                foreach (var item in fileCode.GetAllTags(new string[] { $"/*{UsingsLabel}Begin*/", $"/*{UsingsLabel}nd*/" })
                                             .OrderBy(e => e.StartTagIndex))
                {
                    customUsings.Add(item.FullText);
                }
                foreach (var item in fileCode.GetAllTags(new string[] { $"/*{NamespaceCodeLabel}Begin*/", $"/*{NamespaceCodeLabel}End*/" })
                                             .OrderBy(e => e.StartTagIndex))
                {
                    customNamespaceCode.Add(item.FullText);
                }
                foreach (var item in fileCode.GetAllTags(new string[] { $"/*{ClassCodeLabel}Begin*/", $"/*{ClassCodeLabel}End*/" })
                                             .OrderBy(e => e.StartTagIndex))
                {
                    customClassCode.Add(item.FullText);
                }
            }

            result.Add($"using TContract = {type.FullName};");
            result.Add($"using TModel = {entityFullName};");
            result.Add("using System.Threading.Tasks;");
            result.Add("using Microsoft.AspNetCore.Components;");
            result.Add("using Radzen;");
            result.Add($"using {ProjectName}.Modules.DataGrid;");
            result.Add($"using {CreateComponentsNameSpace(type)};");

            result.AddRange(customUsings);

            result.Add($"namespace {CreatePagesNameSpace(type)}");
            result.Add("{");

            result.AddRange(customNamespaceCode);

            result.Add($"partial class {entityName}{DataGridPagePostfix}");
            result.Add("{");

            result.AddRange(customClassCode);

            result.Add("[Inject]");
            result.Add("protected DialogService DialogService { get; private set; }");

            result.Add(string.Empty);
            result.Add($"protected override string PageRoot => \"{pluralPageName}\";");
            result.Add($"protected {entityName}DataGridHandler DataGridHandler" + " { get; private set; }");

            result.Add("protected override Task OnFirstRenderAsync()");
            result.Add("{");
            result.Add("bool handled = false;");
            result.Add("BeforeFirstRender(ref handled);");
            result.Add("if (handled == false)");
            result.Add("{");
            result.Add("var adapterAccess = ServiceAdapter.Create<TContract>();");
            result.Add($"DataGridHandler = new {entityName}DataGridHandler(this, new DataAdapterAccess<TContract>(adapterAccess));");
            result.Add("InitDataGridHandler(DataGridHandler);");
            result.Add("}");
            result.Add("AfterFirstRender();");
            result.Add("return base.OnFirstRenderAsync();");
            result.Add("}");

            result.Add("partial void BeforeFirstRender(ref bool handled);");
            result.Add("partial void AfterFirstRender();");

            result.Add("protected override void Dispose(bool disposing)");
            result.Add("{");
            result.Add("if (disposing && DataGridHandler != null)");
            result.Add("{");
            result.Add("DataGridHandler.Dispose();");
            result.Add("}");
            result.Add("DataGridHandler = null;");
            result.Add("base.Dispose(disposing);");
            result.Add("}");

            result.Add("}");
            result.Add("}");

            FinishCreateDataGridPageCode(type, result.Source);
            result.FormatCSharpCode();
            return result;
        }
        partial void StartCreateDataGridPageCode(Type type, List<string> lines);
        partial void FinishCreateDataGridPageCode(Type type, List<string> lines);

        public IEnumerable<Contracts.IGeneratedItem> CreateDisplayComponents(Type type, string typeLabel)
        {
            type.CheckArgument(nameof(type));
            typeLabel.CheckArgument(nameof(typeLabel));

            var result = new List<Contracts.IGeneratedItem>();
            var contractsProject = ContractsProject.Create(SolutionProperties);
            var contractHelper = new ContractHelper(type);
            var persistenceAndBusinessTypes = contractsProject.PersistenceTypes
                                                              .Union(contractsProject.BusinessTypes);
            var masters = contractHelper.GetMasterTypes(persistenceAndBusinessTypes);
            var details = contractHelper.GetDetailTypes(persistenceAndBusinessTypes);

            StartCreateDisplayComponent(type, typeLabel);

            result.Add(CreateDataGridHandlerCode(type));
            result.Add(CreateDataGridComponentRazor(type, masters));
            result.Add(CreateDataGridComponentCode(type, masters));

            result.Add(CreateDataGridColumnsComponentRazor(type));
            result.Add(CreateDataGridColumnsComponentCode(type));

            result.Add(CreateDataGridDetailComponentRazor(type));
            result.Add(CreateDataGridDetailComponentCode(type));

            //result.Add(CreateFieldSetHandlerCode(type));
            //result.Add(CreateEditFieldSetComponentRazor(type));
            //result.Add(CreateEditFieldSetComponentCode(type));

            //result.Add(CreateEditFieldSetDetailComponentRazor(type));
            //result.Add(CreateEditFieldSetDetailComponentCode(type));

            result.Add(CreateMasterComponentRazor(type, masters));
            result.Add(CreateMasterComponentCode(type, masters));


            result.Add(CreateDetailsComponentRazor(type, details));
            result.Add(CreateDetailsComponentCode(type, details));

            FinishCreateDisplayComponent(type, typeLabel);
            return result;
        }
        partial void StartCreateDisplayComponent(Type type, string typeLabel);
        partial void FinishCreateDisplayComponent(Type type, string typeLabel);

        #region DataGrid component generation
        private Contracts.IGeneratedItem CreateDataGridHandlerCode(Type type)
        {
            type.CheckArgument(nameof(type));

            var subPath = CreateSubPathFromType(type);
            var projectSharedComponentsPath = Path.Combine(ProjectName, SharedFolder, ComponentsFolder, subPath);
            var entityName = CreateEntityNameFromInterface(type);
            var entityFullName = $"{CreateModelsNamespace(type)}.{entityName}";
            var fileNameCode = $"{entityName}DataGridHandler{CodeExtension}";
            var result = new Models.GeneratedItem(Common.UnitType.BlazorApp, Common.ItemType.DataGridHandlerCode)
            {
                FullName = CreateEntityFullNameFromInterface(type),
                FileExtension = CodeExtension,
            };
            result.SubFilePath = Path.Combine(projectSharedComponentsPath, fileNameCode);

            StartCreateDataGridHandlerCode(type, result.Source);
            result.Add($"using {ProjectName}.Modules.DataGrid;");
            result.Add($"using TContract = {type.FullName};");
            result.Add($"using TModel = {entityFullName};");

            result.Add($"namespace {CreateComponentsNameSpace(type)}");
            result.Add("{");

            result.Add($"public partial class {entityName}DataGridHandler : Modules.DataGrid.DataGridHandler<TContract, TModel>");
            result.Add("{");

            result.Add($"public {entityName}DataGridHandler(Pages.ModelPage modelPage)");
            result.Add(" : base(modelPage)");
            result.Add("{");
            result.Add("}");

            result.Add($"public {entityName}DataGridHandler(Pages.ModelPage modelPage, DataAccess<TContract> dataAccess)");
            result.Add(" : base(modelPage, dataAccess)");
            result.Add("{");
            result.Add("}");

            result.Add("}");
            result.Add("}");

            FinishCreateDataGridHandlerCode(type, result.Source);
            result.FormatCSharpCode();
            return result;
        }
        partial void StartCreateDataGridHandlerCode(Type type, List<string> lines);
        partial void FinishCreateDataGridHandlerCode(Type type, List<string> lines);

        private Contracts.IGeneratedItem CreateDataGridComponentRazor(Type type, IEnumerable<Models.Relation> masters)
        {
            type.CheckArgument(nameof(type));
            masters.CheckArgument(nameof(masters));

            var subPath = CreateSubPathFromType(type);
            var projectSharedComponentsPath = Path.Combine(ProjectName, SharedFolder, ComponentsFolder, subPath);
            var entityName = CreateEntityNameFromInterface(type);
            var entityFullName = $"{CreateModelsNamespace(type)}.{entityName}";
            var fileNameRazor = $"{entityName}DataGrid{PageExtension}";
            var filePathRazor = Path.Combine(projectSharedComponentsPath, subPath, fileNameRazor);
            var result = new Models.GeneratedItem(Common.UnitType.BlazorApp, Common.ItemType.DataGridComponentRazor)
            {
                FullName = CreateEntityFullNameFromInterface(type),
                FileExtension = PageExtension,
            };
            result.SubFilePath = Path.Combine(projectSharedComponentsPath, fileNameRazor);

            StartCreateDataGridComponentRazor(type, result.Source);
            result.Add("@inherits DataGridComponent");
            result.Add("@using Radzen;");
            result.Add($"@using TModel = {entityFullName};");
            result.Add(string.Empty);

            result.Add("@*EmbeddedBegin:File=_DataGridComponent.template:Label=DefaultPage*@");
            result.Add("@*EmbeddedEnd:Label=DefaultPage*@");

            result.AddRange(EmbeddedTagReplacer.ReplaceEmbeddedTags(result.Source.Eject(), TemplatesSubPath, "@*", "*@", (st, et, rt, p) => EmbeddedTagManager.Handle(type, st, et, rt, p))
                                            .Select(l => l.Replace("File=TModel", $"File=_{entityName}.template"))
                                            .Select(l => l.Replace("Type=TModel", $"Type={entityFullName}"))
                                            .Select(l => l.Replace("<DataGridDetail ", $"<{entityName}DataGridDetail "))
                                            .Select(l => l.Replace("<DataGridColumns ", $"<{entityName}DataGridColumns "))
                                            .Select(l => l.Replace("<EditFieldSetDetail ", $"<{entityName}EditFieldSetDetail "))
                                            );

            FinishCreateDataGridComponentRazor(type, result.Source);
            return result;
        }
        partial void StartCreateDataGridComponentRazor(Type type, List<string> lines);
        partial void FinishCreateDataGridComponentRazor(Type type, List<string> lines);

        private Contracts.IGeneratedItem CreateDataGridComponentCode(Type type, IEnumerable<Models.Relation> masters)
        {
            type.CheckArgument(nameof(type));
            masters.CheckArgument(nameof(type));

            var listMasters = new List<Models.Relation>(masters);
            var subPath = CreateSubPathFromType(type);
            var projectSharedComponentsPath = Path.Combine(ProjectName, SharedFolder, ComponentsFolder, subPath);
            var entityName = CreateEntityNameFromInterface(type);
            var entityFullName = $"{CreateModelsNamespace(type)}.{entityName}";
            var fileNameRazor = $"{entityName}DataGrid{PageExtension}";
            var fileNameRazorCode = $"{fileNameRazor}{CodeExtension}";
            var result = new Models.GeneratedItem(Common.UnitType.BlazorApp, Common.ItemType.DataGridComponentCode)
            {
                FullName = CreateEntityFullNameFromInterface(type),
                FileExtension = PageExtension,
            };
            result.SubFilePath = Path.Combine(projectSharedComponentsPath, fileNameRazorCode);

            StartCreateDataGridComponentCode(type, listMasters, result.Source);
            result.Add("using CommonBase.Attributes;");
            result.Add("using Microsoft.AspNetCore.Components;");
            result.Add("using Radzen;");
            result.Add("using System.Linq;");
            result.Add("using System.Threading.Tasks;");
            result.Add($"using TContract = {type.FullName};");
            result.Add($"using TModel = {entityFullName};");

            result.Add($"namespace {CreateComponentsNameSpace(type)}");
            result.Add("{");    // open namespace
            result.Add($"partial class {entityName}DataGrid");
            result.Add("{");    // open class

            result.Add("[Parameter]");
            result.Add($"public {entityName}DataGridHandler DataGridHandler" + " { get; set; }");
            result.Add(string.Empty);
            result.Add($"public override string ForPrefix => \"{entityName}\";");
            result.Add(string.Empty);

            if (listMasters.Any())
            {
                foreach (var item in listMasters)
                {
                    var referenceEntityName = CreateEntityNameFromInterface(item.From);

                    result.Add("[DisposeField]");
                    result.Add($"protected Modules.DataGrid.DataGridAssociationItem<TModel, {item.From.FullName}> association{referenceEntityName};");
                }

				result.Add(string.Empty);
				result.Add("protected override void BeforeInitialized()");
				result.Add("{");
				result.Add("base.BeforeInitialized();");
				result.Add("bool handled = false;");
				result.Add("BeforeInitAssociations(ref handled);");
				result.Add("if (handled == false)");
				result.Add("{");
				foreach (var item in listMasters)
				{
					var detailEntityName = CreateEntityNameFromInterface(item.From);

					result.Add($"association{detailEntityName} = new Modules.DataGrid.DataGridAssociationItem<TModel, {item.From.FullName}>(this, DataGridHandler, \"{item.Name}\", i =>i.ToString());");
				}
				result.Add("}");
				result.Add("AfterInitAssosiations();");
				result.Add("}");
				result.Add(string.Empty);
				result.Add("partial void BeforeInitAssociations(ref bool handled);");
                result.Add("partial void AfterInitAssosiations();");
            }

            result.Add("}");    // close class
            result.Add("}");    // close namespace

            FinishCreateDataGridComponentCode(type, listMasters, result.Source);
            result.FormatCSharpCode();
            return result;
        }
        partial void StartCreateDataGridComponentCode(Type type, IEnumerable<Models.Relation> masterTypes, List<string> lines);
        partial void FinishCreateDataGridComponentCode(Type type, IEnumerable<Models.Relation> masterTypes, List<string> lines);

        private Contracts.IGeneratedItem CreateDataGridDetailComponentRazor(Type type)
        {
            type.CheckArgument(nameof(type));

            var subPath = CreateSubPathFromType(type);
            var projectSharedComponentsPath = Path.Combine(ProjectName, SharedFolder, ComponentsFolder, subPath);
            var entityName = CreateEntityNameFromInterface(type);
            var entityFullName = $"{CreateModelsNamespace(type)}.{entityName}";
            var fileNameRazor = $"{entityName}DataGridDetail{PageExtension}";
            var filePathRazor = Path.Combine(projectSharedComponentsPath, subPath, fileNameRazor);
            var result = new Models.GeneratedItem(Common.UnitType.BlazorApp, Common.ItemType.DataGridDetailComponentRazor)
            {
                FullName = CreateEntityFullNameFromInterface(type),
                FileExtension = PageExtension,
            };
            result.SubFilePath = Path.Combine(projectSharedComponentsPath, fileNameRazor);

            StartCreateDataGridDetailComponentRazor(type, result.Source);
            result.Add("@inherits DataGridDetailComponent");
            result.Add("@using Radzen;");
            result.Add($"@using TModel = {entityFullName};");
            result.Add(string.Empty);

            result.Add("@*EmbeddedBegin:File=_DataGridDetailComponent.template:Label=DefaultPage*@");
            result.Add("@*EmbeddedEnd:Label=DefaultPage*@");

            result.AddRange(EmbeddedTagReplacer.ReplaceEmbeddedTags(result.Source.Eject(), TemplatesSubPath, "@*", "*@", (st, et, rt, p) => EmbeddedTagManager.Handle(type, st, et, rt, p))
                                            .Select(l => l.Replace("File=TModel", $"File=_{entityName}.template"))
                                            .Select(l => l.Replace("Type=TModel", $"Type={entityFullName}")));

            FinishCreateDataGridDetailComponentRazor(type, result.Source);
            return result;
        }
        partial void StartCreateDataGridDetailComponentRazor(Type type, List<string> lines);
        partial void FinishCreateDataGridDetailComponentRazor(Type type, List<string> lines);

        private Contracts.IGeneratedItem CreateDataGridDetailComponentCode(Type type)
        {
            type.CheckArgument(nameof(type));

            var subPath = CreateSubPathFromType(type);
            var projectSharedComponentsPath = Path.Combine(ProjectName, SharedFolder, ComponentsFolder, subPath);
            var entityName = CreateEntityNameFromInterface(type);
            var entityFullName = $"{CreateModelsNamespace(type)}.{entityName}";
            var fileNameRazor = $"{entityName}DataGridDetail{PageExtension}";
            var fileNameRazorCode = $"{fileNameRazor}{CodeExtension}";
            var result = new Models.GeneratedItem(Common.UnitType.BlazorApp, Common.ItemType.DataGridDetailComponentCode)
            {
                FullName = CreateEntityFullNameFromInterface(type),
                FileExtension = PageExtension,
            };
            result.SubFilePath = Path.Combine(projectSharedComponentsPath, fileNameRazorCode);

            StartCreateDataGridDetailComponentCode(type, result.Source);
            result.Add("using Microsoft.AspNetCore.Components;");
            result.Add($"using TModel = {entityFullName};");

            result.Add($"namespace {CreateComponentsNameSpace(type)}");
            result.Add("{");
            result.Add($"partial class {entityName}DataGridDetail");
            result.Add("{");

            result.Add("[Parameter]");
            result.Add($"public {entityName}DataGridHandler MasterDataGridHandler" + " { get; set; }");

            result.Add($"public override string ForPrefix => \"{entityName}\";");
            result.Add("protected Pages.ModelPage ModelPage => MasterDataGridHandler.ModelPage;");
            result.Add("private TModel parentModel;");
            result.Add("protected TModel ParentModel");
            result.Add("{");
            result.Add("get");
            result.Add("{");
            result.Add("if (parentModel == null)");
            result.Add("{");
            result.Add("parentModel = MasterDataGridHandler.ExpandModel;");
            result.Add("}");
            result.Add("return parentModel;");
            result.Add("}");
            result.Add("}");

            result.Add("}");
            result.Add("}");

            FinishCreateDataGridDetailComponentCode(type, result.Source);
            result.FormatCSharpCode();
            return result;
        }
        partial void StartCreateDataGridDetailComponentCode(Type type, List<string> lines);
        partial void FinishCreateDataGridDetailComponentCode(Type type, List<string> lines);

        private Contracts.IGeneratedItem CreateDataGridColumnsComponentRazor(Type type)
        {
            type.CheckArgument(nameof(type));

            var subPath = CreateSubPathFromType(type);
            var projectSharedComponentsPath = Path.Combine(ProjectName, SharedFolder, ComponentsFolder, subPath);
            var entityName = CreateEntityNameFromInterface(type);
            var entityFullName = $"{CreateModelsNamespace(type)}.{entityName}";
            var fileNameRazor = $"{entityName}DataGridColumns{PageExtension}";
            var result = new Models.GeneratedItem(Common.UnitType.BlazorApp, Common.ItemType.DataGridColumnsComponentRazor)
            {
                FullName = CreateEntityFullNameFromInterface(type),
                FileExtension = PageExtension,
            };
            result.SubFilePath = Path.Combine(projectSharedComponentsPath, fileNameRazor);

            StartCreateDataGridColumnsComponentRazor(type, result.Source);
            result.Add("@inherits DataGridColumnsComponent");
            result.Add("@using Radzen;");
            result.Add("@using CommonBase.Extensions;");
            result.Add($"@using TContract = {type.FullName};");
            result.Add($"@using TModel = {entityFullName};");
            result.Add(string.Empty);

            result.Add("@*EmbeddedBegin:File=_DataGridColumnsComponent.template:Label=DefaultPage*@");
            result.Add("@*EmbeddedEnd:Label=DefaultPage*@");

            result.AddRange(EmbeddedTagReplacer.ReplaceEmbeddedTags(result.Source.Eject(), TemplatesSubPath, "@*", "*@", (st, et, rt, p) => EmbeddedTagManager.Handle(type, st, et, rt, p)));

            FinishCreateDataGridColumnsComponentRazor(type, result.Source);
            return result;
        }
        partial void StartCreateDataGridColumnsComponentRazor(Type type, List<string> lines);
        partial void FinishCreateDataGridColumnsComponentRazor(Type type, List<string> lines);

        private Contracts.IGeneratedItem CreateDataGridColumnsComponentCode(Type type)
        {
            type.CheckArgument(nameof(type));

            var subPath = CreateSubPathFromType(type);
            var projectSharedComponentsPath = Path.Combine(ProjectName, SharedFolder, ComponentsFolder, subPath);
            var entityName = CreateEntityNameFromInterface(type);
            var entityFullName = $"{CreateModelsNamespace(type)}.{entityName}";
            var fileNameRazor = $"{entityName}DataGridColumns{PageExtension}";
            var fileNameRazorCode = $"{fileNameRazor}{CodeExtension}";
            var result = new Models.GeneratedItem(Common.UnitType.BlazorApp, Common.ItemType.DataGridColumnsComponentCode)
            {
                FullName = CreateEntityFullNameFromInterface(type),
                FileExtension = PageExtension,
            };
            result.SubFilePath = Path.Combine(projectSharedComponentsPath, fileNameRazorCode);

            StartCreateDataGridColumnsComponentCode(type, result.Source);
            result.Add("using Microsoft.AspNetCore.Components;");
            result.Add("using Radzen;");
            result.Add("using System;");
            result.Add("using System.Linq;");
            result.Add("using System.Threading.Tasks;");
            result.Add($"using TContract = {type.FullName};");
            result.Add($"using TModel = {entityFullName};");

            result.Add($"namespace {CreateComponentsNameSpace(type)}");
            result.Add("{");
            result.Add($"partial class {entityName}DataGridColumns");
            result.Add("{");

            result.Add("[Parameter]");
            result.Add($"public {entityName}DataGridHandler DataGridHandler" + " { get; set; }");

            result.Add($"public override string ForPrefix => \"{entityName}\";");

            result.Add("protected override Task OnFirstRenderAsync()");
            result.Add("{");
            result.Add("DataGridHandler.ModelItems = DataGridHandler.ModelItems.Union(GetAllDisplayInfos().Where(e => e.ScaffoldItem && (e.VisibilityMode & Models.Modules.Common.VisibilityMode.ListView) > 0 && e.IsModelItem).Select(e => e.PropertyName)).Distinct().ToArray();");
            result.Add("return base.OnFirstRenderAsync();");
            result.Add("}");

            result.Add("protected override Type GetModelType()");
            result.Add("{");
            result.Add("var handled = false;");
            result.Add("var result = default(Type);");
            result.Add("BeforeGetModelType(ref result, ref handled);");
            result.Add("if (handled == false)");
            result.Add("{");
            result.Add("result = typeof(TModel);");
            result.Add("}");
            result.Add("AfterGetModelType(result);");
            result.Add("return result;");
            result.Add("}");
            result.Add("static partial void BeforeGetModelType(ref Type modelType, ref bool handled);");
            result.Add("static partial void AfterGetModelType(Type modelType);");

            result.Add("}");
            result.Add("}");

            FinishCreateDataGridColumnsComponentCode(type, result.Source);
            result.FormatCSharpCode();
            return result;
        }
        partial void StartCreateDataGridColumnsComponentCode(Type type, List<string> lines);
        partial void FinishCreateDataGridColumnsComponentCode(Type type, List<string> lines);
        #endregion DataGrid component generation

        #region FieldSet component generation
        //private Contracts.IGeneratedItem CreateFieldSetHandlerCode(Type type)
        //{
        //    type.CheckArgument(nameof(type));

        //    var subPath = CreateSubPathFromType(type);
        //    var projectSharedComponentsPath = Path.Combine(ProjectName, SharedFolder, ComponentsFolder, subPath);
        //    var entityName = CreateEntityNameFromInterface(type);
        //    var entityFullName = $"{CreateModelsNameSpace(type)}.{entityName}";
        //    var fileNameRazorCode = $"{entityName}FieldSetHandler{CodeExtension}";
        //    var result = new Models.GeneratedItem(Common.UnitType.BlazorApp, Common.ItemType.FieldSetHandlerCode)
        //    {
        //        FullName = CreateEntityFullNameFromInterface(type),
        //        FileExtension = PageExtension,
        //    };
        //    result.SubFilePath = Path.Combine(projectSharedComponentsPath, fileNameRazorCode);

        //    StartCreateFieldSetHandlerCode(type, result.Source);
        //    result.Add($"using TContract = {type.FullName};");
        //    result.Add($"using TModel = {entityFullName};");

        //    result.Add($"namespace {CreateComponentsNameSpace(type)}");
        //    result.Add("{");

        //    result.Add($"public partial class {entityName}FieldSetHandler : FieldSetHandler<TContract, TModel>");
        //    result.Add("{");

        //    result.Add($"public {entityName}FieldSetHandler(Pages.ModelPage modelPage, Contracts.Client.IAdapterAccess<TContract> adapterAccess)");
        //    result.Add(" : base(modelPage, adapterAccess)");
        //    result.Add("{");
        //    result.Add("}");

        //    result.Add("}");
        //    result.Add("}");

        //    FinishCreateFieldSetHandlerCode(type, result.Source);
        //    result.FormatCSharpCode();
        //    return result;
        //}
        //partial void StartCreateFieldSetHandlerCode(Type type, List<string> lines);
        //partial void FinishCreateFieldSetHandlerCode(Type type, List<string> lines);

        //private Contracts.IGeneratedItem CreateEditFieldSetComponentRazor(Type type)
        //{
        //    type.CheckArgument(nameof(type));

        //    var subPath = CreateSubPathFromType(type);
        //    var projectSharedComponentsPath = Path.Combine(ProjectName, SharedFolder, ComponentsFolder, subPath);
        //    var entityName = CreateEntityNameFromInterface(type);
        //    var entityFullName = $"{CreateModelsNameSpace(type)}.{entityName}";
        //    var fileNameRazor = $"{entityName}EditFieldSet{PageExtension}";
        //    var filePathRazor = Path.Combine(projectSharedComponentsPath, subPath, fileNameRazor);
        //    var result = new Models.GeneratedItem(Common.UnitType.BlazorApp, Common.ItemType.FieldSetComponentRazor)
        //    {
        //        FullName = CreateEntityFullNameFromInterface(type),
        //        FileExtension = PageExtension,
        //    };
        //    result.SubFilePath = Path.Combine(projectSharedComponentsPath, fileNameRazor);

        //    StartCreateEditFieldSetComponentRazor(type, result.Source);
        //    result.Add("@inherits FieldSetComponent");
        //    result.Add("@using Radzen;");
        //    result.Add($"@using TModel = {entityFullName};");
        //    result.Add(string.Empty);

        //    result.Add("@*EmbeddedBegin:File=_EditFieldSetComponent.template:Label=DefaultPage*@");
        //    result.Add("@*EmbeddedEnd:Label=DefaultPage*@");

        //    result.AddRange(EmbeddedTagReplacer.ReplaceEmbeddedTags(result.Source.Eject(), TemplatesSubPath, "@*", "*@", (st, et, rt, p) => EmbeddedTagManager.Handle(type, st, et, rt, p))
        //                                       .Select(l => l.Replace("File=TModel", $"File=_{entityName}.template"))
        //                                       .Select(l => l.Replace("Type=TModel", $"Type={entityFullName}"))
        //                                       .Select(l => l.Replace("<EditFieldSetDetail ", $"<{entityName}EditFieldSetDetail "))
        //                                       );

        //    FinishCreateEditFieldSetComponentRazor(type, result.Source);
        //    return result;
        //}
        //partial void StartCreateEditFieldSetComponentRazor(Type type, List<string> lines);
        //partial void FinishCreateEditFieldSetComponentRazor(Type type, List<string> lines);

        //private Contracts.IGeneratedItem CreateEditFieldSetComponentCode(Type type)
        //{
        //    type.CheckArgument(nameof(type));

        //    var subPath = CreateSubPathFromType(type);
        //    var projectSharedComponentsPath = Path.Combine(ProjectName, SharedFolder, ComponentsFolder, subPath);
        //    var entityName = CreateEntityNameFromInterface(type);
        //    var fileNameRazor = $"{entityName}EditFieldSet{PageExtension}";
        //    var fileNameRazorCode = $"{fileNameRazor}{CodeExtension}";
        //    var result = new Models.GeneratedItem(Common.UnitType.BlazorApp, Common.ItemType.FieldSetComponentCode)
        //    {
        //        FullName = CreateEntityFullNameFromInterface(type),
        //        FileExtension = PageExtension,
        //    };
        //    result.SubFilePath = Path.Combine(projectSharedComponentsPath, fileNameRazorCode);

        //    StartCreateEditFieldSetComponentCode(type, result.Source);
        //    result.Add("using Microsoft.AspNetCore.Components;");
        //    result.Add("using Radzen;");

        //    result.Add($"namespace {CreateComponentsNameSpace(type)}");
        //    result.Add("{");
        //    result.Add($"partial class {entityName}EditFieldSet");
        //    result.Add("{");

        //    result.Add("[Parameter]");
        //    result.Add("public int Id" + " { get; set; }");

        //    result.Add("[Parameter]");
        //    result.Add($"public {entityName}FieldSetHandler FieldSetHandler" + " { get; set; }");

        //    result.Add("[Inject]");
        //    result.Add($"protected DialogService DialogService" + " { get; private set; }");

        //    result.Add("}");
        //    result.Add("}");

        //    FinishCreateEditFieldSetComponentCode(type, result.Source);
        //    result.FormatCSharpCode();
        //    return result;
        //}
        //partial void StartCreateEditFieldSetComponentCode(Type type, List<string> lines);
        //partial void FinishCreateEditFieldSetComponentCode(Type type, List<string> lines);

        //private Contracts.IGeneratedItem CreateEditFieldSetDetailComponentRazor(Type type)
        //{
        //    type.CheckArgument(nameof(type));

        //    var subPath = CreateSubPathFromType(type);
        //    var projectSharedComponentsPath = Path.Combine(ProjectName, SharedFolder, ComponentsFolder, subPath);
        //    var entityName = CreateEntityNameFromInterface(type);
        //    var entityFullName = $"{CreateModelsNameSpace(type)}.{entityName}";
        //    var fileNameRazor = $"{entityName}EditFieldSetDetail{PageExtension}";
        //    var filePathRazor = Path.Combine(projectSharedComponentsPath, subPath, fileNameRazor);
        //    var result = new Models.GeneratedItem(Common.UnitType.BlazorApp, Common.ItemType.FieldSetDetailComponentRazor)
        //    {
        //        FullName = CreateEntityFullNameFromInterface(type),
        //        FileExtension = PageExtension,
        //    };
        //    result.SubFilePath = Path.Combine(projectSharedComponentsPath, fileNameRazor);

        //    StartCreateEditFieldSetDetailComponentRazor(type, result.Source);
        //    result.Add("@inherits FieldSetComponent");
        //    result.Add("@using Radzen;");
        //    result.Add($"@using TModel = {entityFullName};");
        //    result.Add(string.Empty);
        //    result.AddRange(BlazorUIGenerator.CreateAddFieldSet(type).Select(rb => rb.ToString()));

        //    result.Add("@*EmbeddedBegin:File=_EditFieldSetDetailComponent.template:Label=DefaultPage*@");
        //    result.Add("@*EmbeddedEnd:Label=DefaultPage*@");

        //    result.AddRange(EmbeddedTagReplacer.ReplaceEmbeddedTags(result.Source.Eject(), TemplatesSubPath, "@*", "*@", (st, et, rt, p) => EmbeddedTagManager.Handle(type, st, et, rt, p))
        //                                    .Select(l => l.Replace("File=TModel", $"File=_{entityName}.template"))
        //                                    .Select(l => l.Replace("Type=TModel", $"Type={entityFullName}")));

        //    FinishCreateEditFieldSetDetailComponentRazor(type, result.Source);
        //    return result;
        //}
        //partial void StartCreateEditFieldSetDetailComponentRazor(Type type, List<string> lines);
        //partial void FinishCreateEditFieldSetDetailComponentRazor(Type type, List<string> lines);

        //private Contracts.IGeneratedItem CreateEditFieldSetDetailComponentCode(Type type)
        //{
        //    type.CheckArgument(nameof(type));

        //    var subPath = CreateSubPathFromType(type);
        //    var projectSharedComponentsPath = Path.Combine(ProjectName, SharedFolder, ComponentsFolder, subPath);
        //    var entityName = CreateEntityNameFromInterface(type);
        //    var entityFullName = $"{CreateModelsNameSpace(type)}.{entityName}";
        //    var fileNameRazor = $"{entityName}EditFieldSetDetail{PageExtension}";
        //    var fileNameRazorCode = $"{fileNameRazor}{CodeExtension}";
        //    var result = new Models.GeneratedItem(Common.UnitType.BlazorApp, Common.ItemType.FieldSetDetailComponentCode)
        //    {
        //        FullName = CreateEntityFullNameFromInterface(type),
        //        FileExtension = PageExtension,
        //    };
        //    result.SubFilePath = Path.Combine(projectSharedComponentsPath, fileNameRazorCode);

        //    StartCreateEditFieldSetDetailComponentCode(type, result.Source);
        //    result.Add("using Microsoft.AspNetCore.Components;");
        //    result.Add("using Radzen;");
        //    result.Add("using System;");

        //    result.Add($"namespace {CreateComponentsNameSpace(type)}");
        //    result.Add("{");
        //    result.Add($"partial class {entityName}EditFieldSetDetail");
        //    result.Add("{");

        //    result.Add("[Parameter]");
        //    result.Add($"public {entityFullName} EditModel" + " { get; set; }");

        //    result.Add("[Parameter]");
        //    result.Add("public Func<string, string> LocalTranslate { get; set; }");

        //    result.Add("[Parameter]");
        //    result.Add("public Func<string, string> LocalTranslateFor { get; set; }");

        //    result.Add("}");
        //    result.Add("}");

        //    FinishCreateEditFieldSetDetailComponentCode(type, result.Source);
        //    result.FormatCSharpCode();
        //    return result;
        //}
        //partial void StartCreateEditFieldSetDetailComponentCode(Type type, List<string> lines);
        //partial void FinishCreateEditFieldSetDetailComponentCode(Type type, List<string> lines);
        #endregion FieldSet component generation

        #region Master details generation
        private static string CreatePluralWord(string wordInSingular)
        {
            string result;

            if (wordInSingular.EndsWith("y"))
            {
                result = $"{wordInSingular[0..^1]}ies";
            }
            else if (wordInSingular.EndsWith("s"))
            {
                result = $"{wordInSingular}es";
            }
            else
            {
                result = $"{wordInSingular}s";
            }
            return result;
        }
        private Contracts.IGeneratedItem CreateMasterDetailsPageRazor(Type type, IEnumerable<Models.Relation> details)
        {
            type.CheckArgument(nameof(type));
            details.CheckArgument(nameof(details));

            var subPath = CreateSubPathFromType(type);
            var subNamespace = CreateSubNamespaceFromType(type);
            var componentNamespace = $"{SolutionProperties.BlazorAppProjectName}.Shared.Components.{subNamespace}";
            var projectPagePath = Path.Combine(ProjectName, PagesFolder, subPath);
            var entityName = CreateEntityNameFromInterface(type);
            var entityFullName = $"{CreateModelsNamespace(type)}.{entityName}";
            var pluralPageName = CreatePluralWord(entityName);
            var fileNameRazor = $"{entityName}{PagePostfix}{PageExtension}";
            var result = new Models.GeneratedItem(Common.UnitType.BlazorApp, Common.ItemType.MasterDetailsRazorPage)
            {
                FullName = CreateEntityFullNameFromInterface(type),
                FileExtension = PageExtension,
            };
            result.SubFilePath = Path.Combine(projectPagePath, fileNameRazor);
            StartCreateMasterPageRazor(type, details, result.Source);

            result.Add($"@page \"/{pluralPageName}" + "/{Mode}\"");
            result.Add($"@page \"/{pluralPageName}" + "/{Mode}/{Detail}/{Index:int}\"");
            result.Add($"@page \"/{pluralPageName}" + "/{Mode}" + "/{Id:int}\"");
            result.Add($"@page \"/{pluralPageName}" + "/{Mode}" + "/{Id:int}" + "/{Detail}/{Index:int}\"");
            result.Add($"@using {componentNamespace};");
            result.Add($"@using TMasterContract = {type.FullName};");
            result.Add($"@using TMaster = {entityFullName};");
            result.Add("@inherits Pages.MasterDetailsPage<TMasterContract, TMaster>");
            result.Add(string.Empty);

            result.Add("@*EmbeddedBegin:File=_MasterDetailsPage.template:Label=DefaultPage*@");
            result.Add("@*EmbeddedEnd:Label=DefaultPage*@");

            result.AddRange(EmbeddedTagReplacer.ReplaceEmbeddedTags(result.Source.Eject(), TemplatesSubPath, "@*", "*@", (st, et, rt, p) => EmbeddedTagManager.Handle(type, st, et, rt, p))
                                            .Select(l => l.Replace("TMasterComponent", $"{entityName}Master{ComponentePostfix}"))
                                            .Select(l => l.Replace("TDetailsComponent", $"{componentNamespace}.{entityName}DetailsComponent")));
            result.AddRange(EmbeddedTagReplacer.ReplaceEmbeddedTags(result.Source.Eject(), TemplatesSubPath, "@*", "*@", (st, et, rt, p) => EmbeddedTagManager.Handle(type, st, et, rt, p)));

            FinishCreateMasterPageRazor(type, details, result.Source);
            return result;
        }
        partial void StartCreateMasterPageRazor(Type type, IEnumerable<Models.Relation> detailTypes, List<string> lines);
        partial void FinishCreateMasterPageRazor(Type type, IEnumerable<Models.Relation> detailTypes, List<string> lines);

        private Contracts.IGeneratedItem CreateMasterDetailsPageCode(Type type, IEnumerable<Models.Relation> details)
        {
            type.CheckArgument(nameof(type));
            details.CheckArgument(nameof(details));

            var customUsings = new List<string>();
            var customNamespaceCode = new List<string>();
            var customClassCode = new List<string>();
            var subPath = CreateSubPathFromType(type);
            var projectPagePath = Path.Combine(ProjectName, PagesFolder, subPath);
            var entityName = CreateEntityNameFromInterface(type);
            var entityFullName = $"{CreateModelsNamespace(type)}.{entityName}";
            var pluralPageName = CreatePluralWord(entityName);
            var fileNameRazor = $"{entityName}{PagePostfix}{PageExtension}";
            var fileNameRazorCode = $"{fileNameRazor}{CodeExtension}";
            var filePathRazorCode = Path.Combine(ProjectName, subPath, fileNameRazorCode);
            var result = new Models.GeneratedItem(Common.UnitType.BlazorApp, Common.ItemType.MasterDetailsRazorPageCode)
            {
                FullName = CreateEntityFullNameFromInterface(type),
                FileExtension = CodeExtension,
            };
            result.SubFilePath = Path.Combine(projectPagePath, fileNameRazorCode);

            StartCreateMasterPageCode(type, details, result.Source);
            if (File.Exists(filePathRazorCode))
            {
                var fileCode = File.ReadAllText(filePathRazorCode, Encoding.Default);

                foreach (var item in fileCode.GetAllTags(new string[] { $"/*{UsingsLabel}Begin*/", $"/*{UsingsLabel}nd*/" })
                                             .OrderBy(e => e.StartTagIndex))
                {
                    customUsings.Add(item.FullText);
                }
                foreach (var item in fileCode.GetAllTags(new string[] { $"/*{NamespaceCodeLabel}Begin*/", $"/*{NamespaceCodeLabel}End*/" })
                                             .OrderBy(e => e.StartTagIndex))
                {
                    customNamespaceCode.Add(item.FullText);
                }
                foreach (var item in fileCode.GetAllTags(new string[] { $"/*{ClassCodeLabel}Begin*/", $"/*{ClassCodeLabel}End*/" })
                                             .OrderBy(e => e.StartTagIndex))
                {
                    customClassCode.Add(item.FullText);
                }
            }

            result.Add("using System.Threading.Tasks;");
            result.Add("using Microsoft.AspNetCore.Components;");
            result.Add("using Radzen;");
            result.Add($"using {CreateComponentsNameSpace(type)};");
            result.Add($"using TMasterContract = {type.FullName};");
            result.Add($"using TMaster = {entityFullName};");

            result.AddRange(customUsings);

            result.Add($"namespace {CreatePagesNameSpace(type)}");
            result.Add("{");

            result.AddRange(customNamespaceCode);

            result.Add($"partial class {entityName}{PagePostfix}");
            result.Add("{");

            result.AddRange(customClassCode);

            result.Add("[Inject]");
            result.Add("protected DialogService DialogService { get; private set; }");
            result.Add(string.Empty);
            result.Add($"protected override string PageRoot => \"{pluralPageName}\";");

            result.Add("}");
            result.Add("}");

            FinishCreateMasterPageCode(type, details, result.Source);
            result.FormatCSharpCode();
            return result;
        }
        partial void StartCreateMasterPageCode(Type type, IEnumerable<Models.Relation> relations, List<string> lines);
        partial void FinishCreateMasterPageCode(Type type, IEnumerable<Models.Relation> relations, List<string> lines);

        private Contracts.IGeneratedItem CreateMasterComponentRazor(Type type, IEnumerable<Models.Relation> masters)
        {
            type.CheckArgument(nameof(type));
            masters.CheckArgument(nameof(masters));

            var listMasters = new List<Models.Relation>(masters);
            var subPath = CreateSubPathFromType(type);
            var projectSharedComponentsPath = Path.Combine(ProjectName, SharedFolder, ComponentsFolder, subPath);
            var entityName = CreateEntityNameFromInterface(type);
            var entityFullName = $"{CreateModelsNamespace(type)}.{entityName}";
            var fileNameRazor = $"{entityName}Master{ComponentePostfix}{PageExtension}";
            var filePathRazor = Path.Combine(projectSharedComponentsPath, subPath, fileNameRazor);
            var result = new Models.GeneratedItem(Common.UnitType.BlazorApp, Common.ItemType.MasterComponentRazor)
            {
                FullName = CreateEntityFullNameFromInterface(type),
                FileExtension = PageExtension,
            };
            result.SubFilePath = Path.Combine(projectSharedComponentsPath, fileNameRazor);

            StartCreateMasterComponentRazor(type, listMasters, result.Source);
            result.Add($"@using TMasterContract = {type.FullName};");
            result.Add($"@using TMaster = {entityFullName};");
            result.Add("@using CommonBase.Extensions;");
            result.Add("@inherits MasterComponent<TMasterContract, TMaster>");
            result.Add(string.Empty);

            result.Add("@*EmbeddedBegin:File=_MasterComponent.template:Label=DefaultPage*@");
            result.Add("@*EmbeddedEnd:Label=DefaultPage*@");

            result.AddRange(EmbeddedTagReplacer.ReplaceEmbeddedTags(result.Source.Eject(), TemplatesSubPath, "@*", "*@", (st, et, rt, p) => EmbeddedTagManager.Handle(type, st, et, rt, p)));
            FinishCreateMasterComponentRazor(type, listMasters, result.Source);
            return result;
        }
        partial void StartCreateMasterComponentRazor(Type type, List<Models.Relation> masters, List<string> lines);
        partial void FinishCreateMasterComponentRazor(Type type, List<Models.Relation> masters, List<string> lines);

        private Contracts.IGeneratedItem CreateMasterComponentCode(Type type, IEnumerable<Models.Relation> masters)
        {
            type.CheckArgument(nameof(type));
            masters.CheckArgument(nameof(masters));

            var contractHelper = new ContractHelper(type);
            var listMasters = new List<Models.Relation>(masters);
            var subPath = CreateSubPathFromType(type);
            var projectSharedComponentsPath = Path.Combine(ProjectName, SharedFolder, ComponentsFolder, subPath);
            var entityName = CreateEntityNameFromInterface(type);
            var entityFullName = $"{CreateModelsNamespace(type)}.{entityName}";
            var fileNameRazor = $"{entityName}Master{ComponentePostfix}{PageExtension}";
            var fileNameRazorCode = $"{fileNameRazor}{CodeExtension}";
            var result = new Models.GeneratedItem(Common.UnitType.BlazorApp, Common.ItemType.MasterComponentCode)
            {
                FullName = CreateEntityFullNameFromInterface(type),
                FileExtension = PageExtension,
            };
            result.SubFilePath = Path.Combine(projectSharedComponentsPath, fileNameRazorCode);

            StartCreateMasterComponentCode(type, listMasters, result.Source);
            result.Add("using CommonBase.Attributes;");
            result.Add("using Microsoft.AspNetCore.Components;");
            result.Add("using Radzen;");
            result.Add("using System.Linq;");
            result.Add("using System.Threading.Tasks;");
            result.Add($"using TMasterContract = {type.FullName};");
            result.Add($"using TMaster = {entityFullName};");

            result.Add($"namespace {CreateComponentsNameSpace(type)}");
            result.Add("{");
            result.Add($"partial class {entityName}MasterComponent");
            result.Add("{");

            result.Add("@*EmbeddedBegin:File=_MasterComponent.code:Label=DefaultPage*@");
            result.Add("@*EmbeddedEnd:Label=DefaultPage*@");

            result.AddRange(EmbeddedTagReplacer.ReplaceEmbeddedTags(result.Source.Eject(), TemplatesSubPath, "@*", "*@", (st, et, rt, p) => EmbeddedTagManager.Handle(type, st, et, rt, p)));

            if (listMasters.Any())
            {
                foreach (var item in listMasters)
                {
                    var referenceEntityName = CreateEntityNameFromInterface(item.From);

                    result.Add("[DisposeField]");
                    result.Add($"protected Modules.Common.AssociationItem<TMaster, {item.From.FullName}> association{referenceEntityName};");
                }

                result.Add("protected override void BeforeInitialized()");
                result.Add("{");
                result.Add("base.BeforeInitialized();");
                result.Add("bool handled = false;");
                result.Add("BeforeInitAssociations(ref handled);");
                result.Add("if (handled == false)");
                result.Add("{");
                foreach (var item in listMasters)
                {
                    var referenceEntityName = CreateEntityNameFromInterface(item.From);

                    result.Add($"association{referenceEntityName} = new Modules.Common.AssociationItem<TMaster, {item.From.FullName}>(MasterDetailsPage, this, \"{item.Name}\", i =>i.ToString());");
                }
                result.Add("}");
                result.Add("AfterInitAssosiations();");
                result.Add("}");
                result.Add("partial void BeforeInitAssociations(ref bool handled);");
                result.Add("partial void AfterInitAssosiations();");
            }

            result.Add("}");
            result.Add("}");

            FinishCreateMasterComponentCode(type, listMasters, result.Source);
            result.FormatCSharpCode();
            return result;
        }
        partial void StartCreateMasterComponentCode(Type type, List<Models.Relation> masters, List<string> lines);
        partial void FinishCreateMasterComponentCode(Type type, List<Models.Relation> masters, List<string> lines);

        private Contracts.IGeneratedItem CreateDetailsComponentRazor(Type type, IEnumerable<Models.Relation> details)
        {
            type.CheckArgument(nameof(type));
            details.CheckArgument(nameof(details));

            var listDetails = new List<Models.Relation>(details);
            var subPath = CreateSubPathFromType(type);
            var subNamespace = CreateSubNamespaceFromType(type);
            var projectPagePath = Path.Combine(ProjectName, SharedFolder, ComponentsFolder, subPath);
            var entityName = CreateEntityNameFromInterface(type);
            var entityFullName = $"{CreateModelsNamespace(type)}.{entityName}";
            var fileNameRazor = $"{entityName}Details{ComponentePostfix}{PageExtension}";
            var result = new Models.GeneratedItem(Common.UnitType.BlazorApp, Common.ItemType.DetailsComponentRazor)
            {
                FullName = CreateEntityFullNameFromInterface(type),
                FileExtension = PageExtension,
            };
            result.SubFilePath = Path.Combine(projectPagePath, fileNameRazor);
            StartCreateDetailsComponentRazor(type, listDetails, result.Source);

            result.Add($"@using {SolutionProperties.BlazorAppProjectName}.Shared.Components;");
            result.Add($"@using TMasterContract = {type.FullName};");
            result.Add($"@using TMaster = {entityFullName};");
            result.Add("@inherits DetailsComponent<TMasterContract, TMaster>");
            result.Add(string.Empty);

            result.Add("@*EmbeddedBegin:File=_DetailsComponent.template:Label=DefaultPage*@");
            result.Add("@*EmbeddedEnd:Label=DefaultPage*@");

            result.AddRange(EmbeddedTagReplacer.ReplaceEmbeddedTags(result.Source.Eject(), TemplatesSubPath, "@*", "*@", (st, et, rt, p) => EmbeddedTagManager.Handle(type, st, et, rt, p))
                                            .Select(l => l.Replace("TDetailsComponent", $"{entityName}Component")));
            result.AddRange(EmbeddedTagReplacer.ReplaceEmbeddedTags(result.Source.Eject(), TemplatesSubPath, "@*", "*@", (st, et, rt, p) => EmbeddedTagManager.Handle(type, st, et, rt, p)));

            if (listDetails.Any())
            {
                var namespaceComponents = $"{SolutionProperties.BlazorAppProjectName}.Shared.Components";

                result.Add("<RadzenTabs SelectedIndex=@SelectedIndex @ref=@RadzenTabs >");
                result.Add("  <Tabs>");
                foreach (var item in listDetails)
                {
                    var namespaceSub = CreateSubNamespaceFromType(item.To);
                    var referenceEntityName = CreateEntityNameFromInterface(item.To);

                    result.Add($"    <RadzenTabsItem Text=\"@TranslateFor(\"{referenceEntityName}_{item.Name}\")\">");
                    result.Add($"      <{namespaceComponents}.{namespaceSub}.{referenceEntityName}DataGrid DataGridHandler={referenceEntityName}DataGridHandler{item.Name} ParentComponent=@this />");
                    result.Add("    </RadzenTabsItem>");
                }
                result.Add("  </Tabs>");
                result.Add("</RadzenTabs>");
            }

            FinishCreateDetailsComponentRazor(type, listDetails, result.Source);
            return result;
        }
        partial void StartCreateDetailsComponentRazor(Type type, List<Models.Relation> details, List<string> lines);
        partial void FinishCreateDetailsComponentRazor(Type type, List<Models.Relation> details, List<string> lines);

        private Contracts.IGeneratedItem CreateDetailsComponentCode(Type type, IEnumerable<Models.Relation> details)
        {
            type.CheckArgument(nameof(type));
            details.CheckArgument(nameof(details));

            var listDetails = new List<Models.Relation>(details);
            var customUsings = new List<string>();
            var customNamespaceCode = new List<string>();
            var customClassCode = new List<string>();
            var subPath = CreateSubPathFromType(type);
            var projectPagePath = Path.Combine(ProjectName, SharedFolder, ComponentsFolder, subPath);
            var entityName = CreateEntityNameFromInterface(type);
            var entityFullName = $"{CreateModelsNamespace(type)}.{entityName}";
            var fileNameRazor = $"{entityName}Details{ComponentePostfix}{PageExtension}";
            var fileNameRazorCode = $"{fileNameRazor}{CodeExtension}";
            var filePathRazorCode = Path.Combine(ProjectName, subPath, fileNameRazorCode);
            var result = new Models.GeneratedItem(Common.UnitType.BlazorApp, Common.ItemType.DetailsComponentCode)
            {
                FullName = CreateEntityFullNameFromInterface(type),
                FileExtension = CodeExtension,
            };
            result.SubFilePath = Path.Combine(projectPagePath, fileNameRazorCode);

            StartCreateDetailsComponentCode(type, listDetails, result.Source);
            if (File.Exists(filePathRazorCode))
            {
                var fileCode = File.ReadAllText(filePathRazorCode, Encoding.Default);

                foreach (var item in fileCode.GetAllTags(new string[] { $"/*{UsingsLabel}Begin*/", $"/*{UsingsLabel}nd*/" })
                                             .OrderBy(e => e.StartTagIndex))
                {
                    customUsings.Add(item.FullText);
                }
                foreach (var item in fileCode.GetAllTags(new string[] { $"/*{NamespaceCodeLabel}Begin*/", $"/*{NamespaceCodeLabel}End*/" })
                                             .OrderBy(e => e.StartTagIndex))
                {
                    customNamespaceCode.Add(item.FullText);
                }
                foreach (var item in fileCode.GetAllTags(new string[] { $"/*{ClassCodeLabel}Begin*/", $"/*{ClassCodeLabel}End*/" })
                                             .OrderBy(e => e.StartTagIndex))
                {
                    customClassCode.Add(item.FullText);
                }
            }

            result.Add("using System.Threading.Tasks;");
            result.Add("using Microsoft.AspNetCore.Components;");
            result.Add("using Radzen;");
            result.Add($"using {CreateComponentsNameSpace(type)};");

            result.AddRange(customUsings);

            result.Add($"namespace {CreateComponentsNameSpace(type)}");
            result.Add("{");

            result.AddRange(customNamespaceCode);

            result.Add($"partial class {entityName}Details{ComponentePostfix}");
            result.Add("{");

            result.AddRange(customClassCode);

            result.Add("[Inject]");
            result.Add("protected DialogService DialogService { get; private set; }");

            result.Add(string.Empty);

            if (listDetails.Any())
            {
                foreach (var item in listDetails)
                {
                    var referenceEntityName = CreateEntityNameFromInterface(item.To);

                    result.Add($"protected {CreateComponentsNameSpace(item.To)}.{referenceEntityName}DataGridHandler {referenceEntityName}DataGridHandler{item.Name}" + "{ get; private set; }");
                }

                result.Add("protected override Task InitializeParametersAsync()");
                result.Add("{");
                foreach (var item in listDetails)
                {
                    var detailEntityName = CreateEntityNameFromInterface(item.To);
                    var dataGridHandler = $"{detailEntityName}DataGridHandler{item.Name}";

                    result.Add($"{dataGridHandler}.Editable = MasterDetailsPage.Id != 0;");
                    result.Add($"{dataGridHandler}.AccessFilter = $\"{item.Name}=" + "{MasterDetailsPage.Id}\";");
                }
                result.Add("return base.InitializeParametersAsync();");
                result.Add("}");

                result.Add("protected override void BeforeInitialized()");
                result.Add("{");
                result.Add("base.BeforeInitialized();");

                foreach (var item in listDetails)
                {
                    var referenceEntityName = CreateEntityNameFromInterface(item.To);

                    result.Add($"{referenceEntityName}DataGridHandler{item.Name} = new {CreateComponentsNameSpace(item.To)}.{referenceEntityName}DataGridHandler(MasterDetailsPage);");
                    result.Add($"InitDataGridHandler({referenceEntityName}DataGridHandler{item.Name}, \"{referenceEntityName}\");");
                    result.Add(string.Empty);
                    result.Add($"{referenceEntityName}DataGridHandler{item.Name}.BeforeLoadDataHandler += {referenceEntityName}DataGridHandler{item.Name}_BeforeLoadDataHandler;");
                    result.Add($"{referenceEntityName}DataGridHandler{item.Name}.AfterCreateModelHandler += {referenceEntityName}DataGridHandler{item.Name}_AfterCreateModelHandler;");
                }
                result.Add("}");
                result.Add(string.Empty);

                foreach (var item in listDetails)
                {
                    var referenceEntityName = CreateEntityNameFromInterface(item.To);

                    result.Add($"private void {referenceEntityName}DataGridHandler{item.Name}_BeforeLoadDataHandler(object sender, LoadDataArgs e)");
                    result.Add("{");
                    result.Add("if (sender is Modules.DataGrid.IDataGridBase dataGridHandler)");
                    result.Add("{");
                    result.Add($"dataGridHandler.AccessFilter = $\"{item.Name}=" + "{MasterDetailsPage.Id}\";");
                    result.Add("}");
                    result.Add("}");
                }

                foreach (var item in listDetails)
                {
                    var namespaceModel = CreateModelsNamespace(item.To);
                    var referenceEntityName = CreateEntityNameFromInterface(item.To);

                    result.Add($"private void {referenceEntityName}DataGridHandler{item.Name}_AfterCreateModelHandler(object sender, {namespaceModel}.{referenceEntityName} model)");
                    result.Add("{");
                    result.Add("if (sender is Modules.DataGrid.IDataGridBase)");
                    result.Add("{");
                    result.Add($"model.{item.Name}=MasterDetailsPage.Id;");
                    result.Add("}");
                    result.Add("}");
                }
                result.Add("protected override void InitDisplayInfoContainer(Models.Modules.Form.DisplayInfoContainer displayInfos)");
                result.Add("{");
                result.Add("base.InitDisplayInfoContainer(displayInfos);");
                result.Add("var handled = false;");
                result.Add("BeforeInitDisplayInfoContainer(displayInfos, ref handled);");
                result.Add("if (handled == false)");
                result.Add("{");
                result.Add($"displayInfos.AddOrSet(\"{CreateEntityNameFromInterface(type)}Id\", " + "dp => { dp.VisibilityMode = Models.Modules.Common.VisibilityMode.Hidden; });");
                result.Add("}");
                result.Add("AfterInitDisplayInfoContainer(displayInfos);");
                result.Add("}");
                result.Add("partial void BeforeInitDisplayInfoContainer(Models.Modules.Form.DisplayInfoContainer displayInfos, ref bool handled);");
                result.Add("partial void AfterInitDisplayInfoContainer(Models.Modules.Form.DisplayInfoContainer displayInfos);");
            }
            result.Add("}");
            result.Add("}");

            FinishCreateDetailsComponentCode(type, listDetails, result.Source);
            result.FormatCSharpCode();
            return result;
        }
        partial void StartCreateDetailsComponentCode(Type type, List<Models.Relation> details, List<string> lines);
        partial void FinishCreateDetailsComponentCode(Type type, List<Models.Relation> details, List<string> lines);
        #endregion Master details generation
    }
}
//MdEnd
