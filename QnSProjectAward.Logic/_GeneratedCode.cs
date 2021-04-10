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
            else if (typeof(I) == typeof(QnSProjectAward.Contracts.Persistence.Configuration.IIdentitySetting))
            {
                result = new Controllers.Persistence.Configuration.IdentitySettingController(CreateContext()) as Contracts.Client.IControllerAccess<I>;
            }
            else if (typeof(I) == typeof(QnSProjectAward.Contracts.Persistence.Configuration.ISetting))
            {
                result = new Controllers.Persistence.Configuration.SettingController(CreateContext()) as Contracts.Client.IControllerAccess<I>;
            }
            else if (typeof(I) == typeof(QnSProjectAward.Contracts.Persistence.App.IAward))
            {
                result = new Controllers.Persistence.App.AwardController(CreateContext()) as Contracts.Client.IControllerAccess<I>;
            }
            else if (typeof(I) == typeof(QnSProjectAward.Contracts.Persistence.App.IJuror))
            {
                result = new Controllers.Persistence.App.JurorController(CreateContext()) as Contracts.Client.IControllerAccess<I>;
            }
            else if (typeof(I) == typeof(QnSProjectAward.Contracts.Persistence.App.IMember))
            {
                result = new Controllers.Persistence.App.MemberController(CreateContext()) as Contracts.Client.IControllerAccess<I>;
            }
            else if (typeof(I) == typeof(QnSProjectAward.Contracts.Persistence.App.IProject))
            {
                result = new Controllers.Persistence.App.ProjectController(CreateContext()) as Contracts.Client.IControllerAccess<I>;
            }
            else if (typeof(I) == typeof(QnSProjectAward.Contracts.Persistence.App.IRating))
            {
                result = new Controllers.Persistence.App.RatingController(CreateContext()) as Contracts.Client.IControllerAccess<I>;
            }
            else if (typeof(I) == typeof(QnSProjectAward.Contracts.Persistence.Account.IActionLog))
            {
                result = new Controllers.Persistence.Account.ActionLogController(CreateContext()) as Contracts.Client.IControllerAccess<I>;
            }
            else if (typeof(I) == typeof(QnSProjectAward.Contracts.Persistence.Account.IIdentity))
            {
                result = new Controllers.Persistence.Account.IdentityController(CreateContext()) as Contracts.Client.IControllerAccess<I>;
            }
            else if (typeof(I) == typeof(QnSProjectAward.Contracts.Persistence.Account.IIdentityXRole))
            {
                result = new Controllers.Persistence.Account.IdentityXRoleController(CreateContext()) as Contracts.Client.IControllerAccess<I>;
            }
            else if (typeof(I) == typeof(QnSProjectAward.Contracts.Persistence.Account.ILoginSession))
            {
                result = new Controllers.Persistence.Account.LoginSessionController(CreateContext()) as Contracts.Client.IControllerAccess<I>;
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
            else if (typeof(I) == typeof(QnSProjectAward.Contracts.Persistence.Configuration.IIdentitySetting))
            {
                result = new Controllers.Persistence.Configuration.IdentitySettingController(sharedController as Controllers.ControllerObject) as Contracts.Client.IControllerAccess<I>;
            }
            else if (typeof(I) == typeof(QnSProjectAward.Contracts.Persistence.Configuration.ISetting))
            {
                result = new Controllers.Persistence.Configuration.SettingController(sharedController as Controllers.ControllerObject) as Contracts.Client.IControllerAccess<I>;
            }
            else if (typeof(I) == typeof(QnSProjectAward.Contracts.Persistence.App.IAward))
            {
                result = new Controllers.Persistence.App.AwardController(sharedController as Controllers.ControllerObject) as Contracts.Client.IControllerAccess<I>;
            }
            else if (typeof(I) == typeof(QnSProjectAward.Contracts.Persistence.App.IJuror))
            {
                result = new Controllers.Persistence.App.JurorController(sharedController as Controllers.ControllerObject) as Contracts.Client.IControllerAccess<I>;
            }
            else if (typeof(I) == typeof(QnSProjectAward.Contracts.Persistence.App.IMember))
            {
                result = new Controllers.Persistence.App.MemberController(sharedController as Controllers.ControllerObject) as Contracts.Client.IControllerAccess<I>;
            }
            else if (typeof(I) == typeof(QnSProjectAward.Contracts.Persistence.App.IProject))
            {
                result = new Controllers.Persistence.App.ProjectController(sharedController as Controllers.ControllerObject) as Contracts.Client.IControllerAccess<I>;
            }
            else if (typeof(I) == typeof(QnSProjectAward.Contracts.Persistence.App.IRating))
            {
                result = new Controllers.Persistence.App.RatingController(sharedController as Controllers.ControllerObject) as Contracts.Client.IControllerAccess<I>;
            }
            else if (typeof(I) == typeof(QnSProjectAward.Contracts.Persistence.Account.IActionLog))
            {
                result = new Controllers.Persistence.Account.ActionLogController(sharedController as Controllers.ControllerObject) as Contracts.Client.IControllerAccess<I>;
            }
            else if (typeof(I) == typeof(QnSProjectAward.Contracts.Persistence.Account.IIdentity))
            {
                result = new Controllers.Persistence.Account.IdentityController(sharedController as Controllers.ControllerObject) as Contracts.Client.IControllerAccess<I>;
            }
            else if (typeof(I) == typeof(QnSProjectAward.Contracts.Persistence.Account.IIdentityXRole))
            {
                result = new Controllers.Persistence.Account.IdentityXRoleController(sharedController as Controllers.ControllerObject) as Contracts.Client.IControllerAccess<I>;
            }
            else if (typeof(I) == typeof(QnSProjectAward.Contracts.Persistence.Account.ILoginSession))
            {
                result = new Controllers.Persistence.Account.LoginSessionController(sharedController as Controllers.ControllerObject) as Contracts.Client.IControllerAccess<I>;
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
            else if (typeof(I) == typeof(QnSProjectAward.Contracts.Persistence.Configuration.IIdentitySetting))
            {
                result = new Controllers.Persistence.Configuration.IdentitySettingController(CreateContext())
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
            else if (typeof(I) == typeof(QnSProjectAward.Contracts.Persistence.App.IAward))
            {
                result = new Controllers.Persistence.App.AwardController(CreateContext())
                {
                    SessionToken = sessionToken
                }
                as Contracts.Client.IControllerAccess<I>;
            }
            else if (typeof(I) == typeof(QnSProjectAward.Contracts.Persistence.App.IJuror))
            {
                result = new Controllers.Persistence.App.JurorController(CreateContext())
                {
                    SessionToken = sessionToken
                }
                as Contracts.Client.IControllerAccess<I>;
            }
            else if (typeof(I) == typeof(QnSProjectAward.Contracts.Persistence.App.IMember))
            {
                result = new Controllers.Persistence.App.MemberController(CreateContext())
                {
                    SessionToken = sessionToken
                }
                as Contracts.Client.IControllerAccess<I>;
            }
            else if (typeof(I) == typeof(QnSProjectAward.Contracts.Persistence.App.IProject))
            {
                result = new Controllers.Persistence.App.ProjectController(CreateContext())
                {
                    SessionToken = sessionToken
                }
                as Contracts.Client.IControllerAccess<I>;
            }
            else if (typeof(I) == typeof(QnSProjectAward.Contracts.Persistence.App.IRating))
            {
                result = new Controllers.Persistence.App.RatingController(CreateContext())
                {
                    SessionToken = sessionToken
                }
                as Contracts.Client.IControllerAccess<I>;
            }
            else if (typeof(I) == typeof(QnSProjectAward.Contracts.Persistence.Account.IActionLog))
            {
                result = new Controllers.Persistence.Account.ActionLogController(CreateContext())
                {
                    SessionToken = sessionToken
                }
                as Contracts.Client.IControllerAccess<I>;
            }
            else if (typeof(I) == typeof(QnSProjectAward.Contracts.Persistence.Account.IIdentity))
            {
                result = new Controllers.Persistence.Account.IdentityController(CreateContext())
                {
                    SessionToken = sessionToken
                }
                as Contracts.Client.IControllerAccess<I>;
            }
            else if (typeof(I) == typeof(QnSProjectAward.Contracts.Persistence.Account.IIdentityXRole))
            {
                result = new Controllers.Persistence.Account.IdentityXRoleController(CreateContext())
                {
                    SessionToken = sessionToken
                }
                as Contracts.Client.IControllerAccess<I>;
            }
            else if (typeof(I) == typeof(QnSProjectAward.Contracts.Persistence.Account.ILoginSession))
            {
                result = new Controllers.Persistence.Account.LoginSessionController(CreateContext())
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
