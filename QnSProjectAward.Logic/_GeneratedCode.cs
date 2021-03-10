//@QnSGeneratedCode
namespace QnSProjectAward.Logic
{
    public static partial class Factory
    {
        public static Contracts.Client.IControllerAccess<I> Create<I>() where I : Contracts.IIdentifiable
        {
            Contracts.Client.IControllerAccess<I> result;
            if (typeof(I) == typeof(QnSProjectAward.Contracts.Persistence.Language.ITranslation))
            {
                result = new Controllers.Persistence.Language.TranslationController(CreateContext()) as Contracts.Client.IControllerAccess<I>;
            }
            else if (typeof(I) == typeof(QnSProjectAward.Contracts.Persistence.Data.IBinaryData))
            {
                result = new Controllers.Persistence.Data.BinaryDataController(CreateContext()) as Contracts.Client.IControllerAccess<I>;
            }
            else if (typeof(I) == typeof(QnSProjectAward.Contracts.Persistence.Configuration.ISetting))
            {
                result = new Controllers.Persistence.Configuration.SettingController(CreateContext()) as Contracts.Client.IControllerAccess<I>;
            }
            else if (typeof(I) == typeof(QnSProjectAward.Contracts.Persistence.Account.IRole))
            {
                result = new Controllers.Persistence.Account.RoleController(CreateContext()) as Contracts.Client.IControllerAccess<I>;
            }
            else if (typeof(I) == typeof(QnSProjectAward.Contracts.Persistence.Account.IUser))
            {
                result = new Controllers.Persistence.Account.UserController(CreateContext()) as Contracts.Client.IControllerAccess<I>;
            }
            else if (typeof(I) == typeof(QnSProjectAward.Contracts.Business.Account.IAppAccess))
            {
                result = new Controllers.Business.Account.AppAccessController(CreateContext()) as Contracts.Client.IControllerAccess<I>;
            }
            else if (typeof(I) == typeof(QnSProjectAward.Contracts.Business.Account.IIdentityUser))
            {
                result = new Controllers.Business.Account.IdentityUserController(CreateContext()) as Contracts.Client.IControllerAccess<I>;
            }
            else
            {
                throw new Logic.Modules.Exception.LogicException(Modules.Exception.ErrorType.InvalidControllerType);
            }
            return result;
        }
        public static Contracts.Client.IControllerAccess<I> Create<I>(object sharedController) where I : Contracts.IIdentifiable
        {
            Contracts.Client.IControllerAccess<I> result;
            if (typeof(I) == typeof(QnSProjectAward.Contracts.Persistence.Language.ITranslation))
            {
                result = new Controllers.Persistence.Language.TranslationController(sharedController as Controllers.ControllerObject) as Contracts.Client.IControllerAccess<I>;
            }
            else if (typeof(I) == typeof(QnSProjectAward.Contracts.Persistence.Data.IBinaryData))
            {
                result = new Controllers.Persistence.Data.BinaryDataController(sharedController as Controllers.ControllerObject) as Contracts.Client.IControllerAccess<I>;
            }
            else if (typeof(I) == typeof(QnSProjectAward.Contracts.Persistence.Configuration.ISetting))
            {
                result = new Controllers.Persistence.Configuration.SettingController(sharedController as Controllers.ControllerObject) as Contracts.Client.IControllerAccess<I>;
            }
            else if (typeof(I) == typeof(QnSProjectAward.Contracts.Persistence.Account.IRole))
            {
                result = new Controllers.Persistence.Account.RoleController(sharedController as Controllers.ControllerObject) as Contracts.Client.IControllerAccess<I>;
            }
            else if (typeof(I) == typeof(QnSProjectAward.Contracts.Persistence.Account.IUser))
            {
                result = new Controllers.Persistence.Account.UserController(sharedController as Controllers.ControllerObject) as Contracts.Client.IControllerAccess<I>;
            }
            else if (typeof(I) == typeof(QnSProjectAward.Contracts.Business.Account.IAppAccess))
            {
                result = new Controllers.Business.Account.AppAccessController(sharedController as Controllers.ControllerObject) as Contracts.Client.IControllerAccess<I>;
            }
            else if (typeof(I) == typeof(QnSProjectAward.Contracts.Business.Account.IIdentityUser))
            {
                result = new Controllers.Business.Account.IdentityUserController(sharedController as Controllers.ControllerObject) as Contracts.Client.IControllerAccess<I>;
            }
            else
            {
                throw new Logic.Modules.Exception.LogicException(Modules.Exception.ErrorType.InvalidControllerType);
            }
            return result;
        }
        public static Contracts.Client.IControllerAccess<I> Create<I>(string sessionToken) where I : Contracts.IIdentifiable
        {
            Contracts.Client.IControllerAccess<I> result;
            if (typeof(I) == typeof(QnSProjectAward.Contracts.Persistence.Language.ITranslation))
            {
                result = new Controllers.Persistence.Language.TranslationController(CreateContext())
                {
                    SessionToken = sessionToken
                }
                as Contracts.Client.IControllerAccess<I>;
            }
            else if (typeof(I) == typeof(QnSProjectAward.Contracts.Persistence.Data.IBinaryData))
            {
                result = new Controllers.Persistence.Data.BinaryDataController(CreateContext())
                {
                    SessionToken = sessionToken
                }
                as Contracts.Client.IControllerAccess<I>;
            }
            else if (typeof(I) == typeof(QnSProjectAward.Contracts.Persistence.Configuration.ISetting))
            {
                result = new Controllers.Persistence.Configuration.SettingController(CreateContext())
                {
                    SessionToken = sessionToken
                }
                as Contracts.Client.IControllerAccess<I>;
            }
            else if (typeof(I) == typeof(QnSProjectAward.Contracts.Persistence.Account.IRole))
            {
                result = new Controllers.Persistence.Account.RoleController(CreateContext())
                {
                    SessionToken = sessionToken
                }
                as Contracts.Client.IControllerAccess<I>;
            }
            else if (typeof(I) == typeof(QnSProjectAward.Contracts.Persistence.Account.IUser))
            {
                result = new Controllers.Persistence.Account.UserController(CreateContext())
                {
                    SessionToken = sessionToken
                }
                as Contracts.Client.IControllerAccess<I>;
            }
            else if (typeof(I) == typeof(QnSProjectAward.Contracts.Business.Account.IAppAccess))
            {
                result = new Controllers.Business.Account.AppAccessController(CreateContext())
                {
                    SessionToken = sessionToken
                }
                as Contracts.Client.IControllerAccess<I>;
            }
            else if (typeof(I) == typeof(QnSProjectAward.Contracts.Business.Account.IIdentityUser))
            {
                result = new Controllers.Business.Account.IdentityUserController(CreateContext())
                {
                    SessionToken = sessionToken
                }
                as Contracts.Client.IControllerAccess<I>;
            }
            else
            {
                throw new Logic.Modules.Exception.LogicException(Modules.Exception.ErrorType.InvalidControllerType);
            }
            return result;
        }
    }
}
