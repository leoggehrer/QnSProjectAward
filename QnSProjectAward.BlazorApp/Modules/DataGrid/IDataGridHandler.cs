//@QnSCodeCopy
//MdStart
using QnSProjectAward.BlazorApp.Models;
using QnSProjectAward.Contracts;
using System;

namespace QnSProjectAward.BlazorApp.Modules.DataGrid
{
    public interface IDataGridHandler<TModel> : IDataGridBase
        where TModel : ModelObject, IIdentifiable, new()
    {

        TModel[] Models { get; }
        string[] ModelItems { get; set; }
        TModel DeleteModel { get; }
        TModel EditModel { get; }
        TModel ExpandModel { get; }
        TModel SelectedModel { get; }

        event EventHandler<TModel> AfterCreateModelHandler;
        event EventHandler<TModel> AfterDeleteModelHandler;
        event EventHandler<TModel> AfterEditModelHandler;
        event EventHandler<TModel> AfterInsertModelHandler;
        event EventHandler<TModel> AfterRowCollapseHandler;
        event EventHandler<TModel> AfterRowExpandHandler;
        event EventHandler<TModel> AfterRowSelectedHandler;
        event EventHandler<TModel> AfterUpdateModelHandler;
        event EventHandler<TModel> BeforeDeleteModelHandler;
        event EventHandler<TModel> BeforeEditModelHandler;
        event EventHandler<TModel> BeforeInsertModelHandler;
        event EventHandler<TModel> BeforeRowCollapseHandler;
        event EventHandler<TModel> BeforeRowExpandHandler;
        event EventHandler<TModel> BeforeRowSelectedHandler;
        event EventHandler<TModel> BeforeUpdateModelHandler;
        event EventHandler<TModel[]> LoadModelDataHandler;

        void ReloadModel(TModel model);
    }
}
//MdEnd
