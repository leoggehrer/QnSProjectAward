//@QnSGeneratedCode
namespace QnSProjectAward.Logic.Controllers.Business.Account
{
    sealed partial class IdentityUserController : GenericOneToAnotherController<QnSProjectAward.Contracts.Business.Account.IIdentityUser, Entities.Business.Account.IdentityUser, QnSProjectAward.Contracts.Persistence.Account.IIdentity, QnSProjectAward.Logic.Entities.Persistence.Account.Identity, QnSProjectAward.Contracts.Persistence.Account.IUser, QnSProjectAward.Logic.Entities.Persistence.Account.User>
    {
        static IdentityUserController()
        {
            ClassConstructing();
            ClassConstructed();
        }
        static partial void ClassConstructing();
        static partial void ClassConstructed();
        public IdentityUserController(DataContext.IContext context):base(context)
        {
            Constructing();
            oneEntityController = new QnSProjectAward.Logic.Controllers.Persistence.Account.IdentityController(this);
            anotherEntityController = new QnSProjectAward.Logic.Controllers.Persistence.Account.UserController(this);
            Constructed();
        }
        partial void Constructing();
        partial void Constructed();
        public IdentityUserController(ControllerObject controller):base(controller)
        {
            Constructing();
            oneEntityController = new QnSProjectAward.Logic.Controllers.Persistence.Account.IdentityController(this);
            anotherEntityController = new QnSProjectAward.Logic.Controllers.Persistence.Account.UserController(this);
            Constructed();
        }
        private QnSProjectAward.Logic.Controllers.Persistence.Account.IdentityController oneEntityController = null;
        protected override GenericController<QnSProjectAward.Contracts.Persistence.Account.IIdentity, QnSProjectAward.Logic.Entities.Persistence.Account.Identity> OneEntityController
        {
            get => oneEntityController;
            set => oneEntityController = value as QnSProjectAward.Logic.Controllers.Persistence.Account.IdentityController;
        }
        private QnSProjectAward.Logic.Controllers.Persistence.Account.UserController anotherEntityController = null;
        protected override GenericController<QnSProjectAward.Contracts.Persistence.Account.IUser, QnSProjectAward.Logic.Entities.Persistence.Account.User> AnotherEntityController
        {
            get => anotherEntityController;
            set => anotherEntityController = value as QnSProjectAward.Logic.Controllers.Persistence.Account.UserController;
        }
    }
}
namespace QnSProjectAward.Logic.Controllers.Business.Account
{
    sealed partial class AppAccessController : GenericOneToManyController<QnSProjectAward.Contracts.Business.Account.IAppAccess, Entities.Business.Account.AppAccess, QnSProjectAward.Contracts.Persistence.Account.IIdentity, QnSProjectAward.Logic.Entities.Persistence.Account.Identity, QnSProjectAward.Contracts.Persistence.Account.IRole, QnSProjectAward.Logic.Entities.Persistence.Account.Role>
    {
        static AppAccessController()
        {
            ClassConstructing();
            ClassConstructed();
        }
        static partial void ClassConstructing();
        static partial void ClassConstructed();
        public AppAccessController(DataContext.IContext context):base(context)
        {
            Constructing();
            oneEntityController = new QnSProjectAward.Logic.Controllers.Persistence.Account.IdentityController(this);
            manyEntityController = new QnSProjectAward.Logic.Controllers.Persistence.Account.RoleController(this);
            Constructed();
        }
        partial void Constructing();
        partial void Constructed();
        public AppAccessController(ControllerObject controller):base(controller)
        {
            Constructing();
            oneEntityController = new QnSProjectAward.Logic.Controllers.Persistence.Account.IdentityController(this);
            manyEntityController = new QnSProjectAward.Logic.Controllers.Persistence.Account.RoleController(this);
            Constructed();
        }
        private QnSProjectAward.Logic.Controllers.Persistence.Account.IdentityController oneEntityController = null;
        protected override GenericController<QnSProjectAward.Contracts.Persistence.Account.IIdentity, QnSProjectAward.Logic.Entities.Persistence.Account.Identity> OneEntityController
        {
            get => oneEntityController;
            set => oneEntityController = value as QnSProjectAward.Logic.Controllers.Persistence.Account.IdentityController;
        }
        private QnSProjectAward.Logic.Controllers.Persistence.Account.RoleController manyEntityController = null;
        protected override GenericController<QnSProjectAward.Contracts.Persistence.Account.IRole, QnSProjectAward.Logic.Entities.Persistence.Account.Role> ManyEntityController
        {
            get => manyEntityController;
            set => manyEntityController = value as QnSProjectAward.Logic.Controllers.Persistence.Account.RoleController;
        }
    }
}
