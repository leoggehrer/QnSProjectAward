//@QnSGeneratedCode
namespace QnSProjectAward.Adapters
{
    public static partial class Factory
    {
        public static Contracts.Client.IAdapterAccess<I> Create<I>()
        {
            Contracts.Client.IAdapterAccess<I> result = null;
            if (Adapter == AdapterType.Controller)
            {
                if (typeof(I) == typeof(QnSProjectAward.Contracts.Persistence.Language.ITranslation))
                {
                    result = new Controller.GenericControllerAdapter<QnSProjectAward.Contracts.Persistence.Language.ITranslation>() as Contracts.Client.IAdapterAccess<I>;
                }
                else if (typeof(I) == typeof(QnSProjectAward.Contracts.Persistence.Data.IBinaryData))
                {
                    result = new Controller.GenericControllerAdapter<QnSProjectAward.Contracts.Persistence.Data.IBinaryData>() as Contracts.Client.IAdapterAccess<I>;
                }
                else if (typeof(I) == typeof(QnSProjectAward.Contracts.Persistence.Configuration.IIdentitySetting))
                {
                    result = new Controller.GenericControllerAdapter<QnSProjectAward.Contracts.Persistence.Configuration.IIdentitySetting>() as Contracts.Client.IAdapterAccess<I>;
                }
                else if (typeof(I) == typeof(QnSProjectAward.Contracts.Persistence.Configuration.ISetting))
                {
                    result = new Controller.GenericControllerAdapter<QnSProjectAward.Contracts.Persistence.Configuration.ISetting>() as Contracts.Client.IAdapterAccess<I>;
                }
                else if (typeof(I) == typeof(QnSProjectAward.Contracts.Persistence.App.IAward))
                {
                    result = new Controller.GenericControllerAdapter<QnSProjectAward.Contracts.Persistence.App.IAward>() as Contracts.Client.IAdapterAccess<I>;
                }
                else if (typeof(I) == typeof(QnSProjectAward.Contracts.Persistence.App.IJuror))
                {
                    result = new Controller.GenericControllerAdapter<QnSProjectAward.Contracts.Persistence.App.IJuror>() as Contracts.Client.IAdapterAccess<I>;
                }
                else if (typeof(I) == typeof(QnSProjectAward.Contracts.Persistence.App.IMember))
                {
                    result = new Controller.GenericControllerAdapter<QnSProjectAward.Contracts.Persistence.App.IMember>() as Contracts.Client.IAdapterAccess<I>;
                }
                else if (typeof(I) == typeof(QnSProjectAward.Contracts.Persistence.App.IProject))
                {
                    result = new Controller.GenericControllerAdapter<QnSProjectAward.Contracts.Persistence.App.IProject>() as Contracts.Client.IAdapterAccess<I>;
                }
                else if (typeof(I) == typeof(QnSProjectAward.Contracts.Persistence.App.IRating))
                {
                    result = new Controller.GenericControllerAdapter<QnSProjectAward.Contracts.Persistence.App.IRating>() as Contracts.Client.IAdapterAccess<I>;
                }
                else if (typeof(I) == typeof(QnSProjectAward.Contracts.Persistence.Account.IAccess))
                {
                    result = new Controller.GenericControllerAdapter<QnSProjectAward.Contracts.Persistence.Account.IAccess>() as Contracts.Client.IAdapterAccess<I>;
                }
                else if (typeof(I) == typeof(QnSProjectAward.Contracts.Persistence.Account.IActionLog))
                {
                    result = new Controller.GenericControllerAdapter<QnSProjectAward.Contracts.Persistence.Account.IActionLog>() as Contracts.Client.IAdapterAccess<I>;
                }
                else if (typeof(I) == typeof(QnSProjectAward.Contracts.Persistence.Account.IIdentity))
                {
                    result = new Controller.GenericControllerAdapter<QnSProjectAward.Contracts.Persistence.Account.IIdentity>() as Contracts.Client.IAdapterAccess<I>;
                }
                else if (typeof(I) == typeof(QnSProjectAward.Contracts.Persistence.Account.IIdentityXRole))
                {
                    result = new Controller.GenericControllerAdapter<QnSProjectAward.Contracts.Persistence.Account.IIdentityXRole>() as Contracts.Client.IAdapterAccess<I>;
                }
                else if (typeof(I) == typeof(QnSProjectAward.Contracts.Persistence.Account.ILoginSession))
                {
                    result = new Controller.GenericControllerAdapter<QnSProjectAward.Contracts.Persistence.Account.ILoginSession>() as Contracts.Client.IAdapterAccess<I>;
                }
                else if (typeof(I) == typeof(QnSProjectAward.Contracts.Persistence.Account.IRole))
                {
                    result = new Controller.GenericControllerAdapter<QnSProjectAward.Contracts.Persistence.Account.IRole>() as Contracts.Client.IAdapterAccess<I>;
                }
                else if (typeof(I) == typeof(QnSProjectAward.Contracts.Persistence.Account.IUser))
                {
                    result = new Controller.GenericControllerAdapter<QnSProjectAward.Contracts.Persistence.Account.IUser>() as Contracts.Client.IAdapterAccess<I>;
                }
                else if (typeof(I) == typeof(QnSProjectAward.Contracts.Business.Account.IAppAccess))
                {
                    result = new Controller.GenericControllerAdapter<QnSProjectAward.Contracts.Business.Account.IAppAccess>() as Contracts.Client.IAdapterAccess<I>;
                }
                else if (typeof(I) == typeof(QnSProjectAward.Contracts.Business.Account.IIdentityUser))
                {
                    result = new Controller.GenericControllerAdapter<QnSProjectAward.Contracts.Business.Account.IIdentityUser>() as Contracts.Client.IAdapterAccess<I>;
                }
            }
            else if (Adapter == AdapterType.Service)
            {
                if (typeof(I) == typeof(QnSProjectAward.Contracts.Persistence.Language.ITranslation))
                {
                    result = new Service.GenericServiceAdapter<QnSProjectAward.Contracts.Persistence.Language.ITranslation, Transfer.Persistence.Language.Translation>(BaseUri, "Translations") as Contracts.Client.IAdapterAccess<I>;
                }
                else if (typeof(I) == typeof(QnSProjectAward.Contracts.Persistence.Data.IBinaryData))
                {
                    result = new Service.GenericServiceAdapter<QnSProjectAward.Contracts.Persistence.Data.IBinaryData, Transfer.Persistence.Data.BinaryData>(BaseUri, "BinaryDatas") as Contracts.Client.IAdapterAccess<I>;
                }
                else if (typeof(I) == typeof(QnSProjectAward.Contracts.Persistence.Configuration.IIdentitySetting))
                {
                    result = new Service.GenericServiceAdapter<QnSProjectAward.Contracts.Persistence.Configuration.IIdentitySetting, Transfer.Persistence.Configuration.IdentitySetting>(BaseUri, "IdentitySettings") as Contracts.Client.IAdapterAccess<I>;
                }
                else if (typeof(I) == typeof(QnSProjectAward.Contracts.Persistence.Configuration.ISetting))
                {
                    result = new Service.GenericServiceAdapter<QnSProjectAward.Contracts.Persistence.Configuration.ISetting, Transfer.Persistence.Configuration.Setting>(BaseUri, "Settings") as Contracts.Client.IAdapterAccess<I>;
                }
                else if (typeof(I) == typeof(QnSProjectAward.Contracts.Persistence.App.IAward))
                {
                    result = new Service.GenericServiceAdapter<QnSProjectAward.Contracts.Persistence.App.IAward, Transfer.Persistence.App.Award>(BaseUri, "Awards") as Contracts.Client.IAdapterAccess<I>;
                }
                else if (typeof(I) == typeof(QnSProjectAward.Contracts.Persistence.App.IJuror))
                {
                    result = new Service.GenericServiceAdapter<QnSProjectAward.Contracts.Persistence.App.IJuror, Transfer.Persistence.App.Juror>(BaseUri, "Jurors") as Contracts.Client.IAdapterAccess<I>;
                }
                else if (typeof(I) == typeof(QnSProjectAward.Contracts.Persistence.App.IMember))
                {
                    result = new Service.GenericServiceAdapter<QnSProjectAward.Contracts.Persistence.App.IMember, Transfer.Persistence.App.Member>(BaseUri, "Members") as Contracts.Client.IAdapterAccess<I>;
                }
                else if (typeof(I) == typeof(QnSProjectAward.Contracts.Persistence.App.IProject))
                {
                    result = new Service.GenericServiceAdapter<QnSProjectAward.Contracts.Persistence.App.IProject, Transfer.Persistence.App.Project>(BaseUri, "Projects") as Contracts.Client.IAdapterAccess<I>;
                }
                else if (typeof(I) == typeof(QnSProjectAward.Contracts.Persistence.App.IRating))
                {
                    result = new Service.GenericServiceAdapter<QnSProjectAward.Contracts.Persistence.App.IRating, Transfer.Persistence.App.Rating>(BaseUri, "Ratings") as Contracts.Client.IAdapterAccess<I>;
                }
                else if (typeof(I) == typeof(QnSProjectAward.Contracts.Persistence.Account.IAccess))
                {
                    result = new Service.GenericServiceAdapter<QnSProjectAward.Contracts.Persistence.Account.IAccess, Transfer.Persistence.Account.Access>(BaseUri, "Access") as Contracts.Client.IAdapterAccess<I>;
                }
                else if (typeof(I) == typeof(QnSProjectAward.Contracts.Persistence.Account.IActionLog))
                {
                    result = new Service.GenericServiceAdapter<QnSProjectAward.Contracts.Persistence.Account.IActionLog, Transfer.Persistence.Account.ActionLog>(BaseUri, "ActionLogs") as Contracts.Client.IAdapterAccess<I>;
                }
                else if (typeof(I) == typeof(QnSProjectAward.Contracts.Persistence.Account.IIdentity))
                {
                    result = new Service.GenericServiceAdapter<QnSProjectAward.Contracts.Persistence.Account.IIdentity, Transfer.Persistence.Account.Identity>(BaseUri, "Identitys") as Contracts.Client.IAdapterAccess<I>;
                }
                else if (typeof(I) == typeof(QnSProjectAward.Contracts.Persistence.Account.IIdentityXRole))
                {
                    result = new Service.GenericServiceAdapter<QnSProjectAward.Contracts.Persistence.Account.IIdentityXRole, Transfer.Persistence.Account.IdentityXRole>(BaseUri, "IdentityXRoles") as Contracts.Client.IAdapterAccess<I>;
                }
                else if (typeof(I) == typeof(QnSProjectAward.Contracts.Persistence.Account.ILoginSession))
                {
                    result = new Service.GenericServiceAdapter<QnSProjectAward.Contracts.Persistence.Account.ILoginSession, Transfer.Persistence.Account.LoginSession>(BaseUri, "LoginSessions") as Contracts.Client.IAdapterAccess<I>;
                }
                else if (typeof(I) == typeof(QnSProjectAward.Contracts.Persistence.Account.IRole))
                {
                    result = new Service.GenericServiceAdapter<QnSProjectAward.Contracts.Persistence.Account.IRole, Transfer.Persistence.Account.Role>(BaseUri, "Roles") as Contracts.Client.IAdapterAccess<I>;
                }
                else if (typeof(I) == typeof(QnSProjectAward.Contracts.Persistence.Account.IUser))
                {
                    result = new Service.GenericServiceAdapter<QnSProjectAward.Contracts.Persistence.Account.IUser, Transfer.Persistence.Account.User>(BaseUri, "Users") as Contracts.Client.IAdapterAccess<I>;
                }
                else if (typeof(I) == typeof(QnSProjectAward.Contracts.Business.Account.IAppAccess))
                {
                    result = new Service.GenericServiceAdapter<QnSProjectAward.Contracts.Business.Account.IAppAccess, Transfer.Business.Account.AppAccess>(BaseUri, "AppAccess") as Contracts.Client.IAdapterAccess<I>;
                }
                else if (typeof(I) == typeof(QnSProjectAward.Contracts.Business.Account.IIdentityUser))
                {
                    result = new Service.GenericServiceAdapter<QnSProjectAward.Contracts.Business.Account.IIdentityUser, Transfer.Business.Account.IdentityUser>(BaseUri, "IdentityUsers") as Contracts.Client.IAdapterAccess<I>;
                }
            }
            return result;
        }
        public static Contracts.Client.IAdapterAccess<I> Create<I>(string sessionToken)
        {
            Contracts.Client.IAdapterAccess<I> result = null;
            if (Adapter == AdapterType.Controller)
            {
                if (typeof(I) == typeof(QnSProjectAward.Contracts.Persistence.Language.ITranslation))
                {
                    result = new Controller.GenericControllerAdapter<QnSProjectAward.Contracts.Persistence.Language.ITranslation>(sessionToken) as Contracts.Client.IAdapterAccess<I>;
                }
                else if (typeof(I) == typeof(QnSProjectAward.Contracts.Persistence.Data.IBinaryData))
                {
                    result = new Controller.GenericControllerAdapter<QnSProjectAward.Contracts.Persistence.Data.IBinaryData>(sessionToken) as Contracts.Client.IAdapterAccess<I>;
                }
                else if (typeof(I) == typeof(QnSProjectAward.Contracts.Persistence.Configuration.IIdentitySetting))
                {
                    result = new Controller.GenericControllerAdapter<QnSProjectAward.Contracts.Persistence.Configuration.IIdentitySetting>(sessionToken) as Contracts.Client.IAdapterAccess<I>;
                }
                else if (typeof(I) == typeof(QnSProjectAward.Contracts.Persistence.Configuration.ISetting))
                {
                    result = new Controller.GenericControllerAdapter<QnSProjectAward.Contracts.Persistence.Configuration.ISetting>(sessionToken) as Contracts.Client.IAdapterAccess<I>;
                }
                else if (typeof(I) == typeof(QnSProjectAward.Contracts.Persistence.App.IAward))
                {
                    result = new Controller.GenericControllerAdapter<QnSProjectAward.Contracts.Persistence.App.IAward>(sessionToken) as Contracts.Client.IAdapterAccess<I>;
                }
                else if (typeof(I) == typeof(QnSProjectAward.Contracts.Persistence.App.IJuror))
                {
                    result = new Controller.GenericControllerAdapter<QnSProjectAward.Contracts.Persistence.App.IJuror>(sessionToken) as Contracts.Client.IAdapterAccess<I>;
                }
                else if (typeof(I) == typeof(QnSProjectAward.Contracts.Persistence.App.IMember))
                {
                    result = new Controller.GenericControllerAdapter<QnSProjectAward.Contracts.Persistence.App.IMember>(sessionToken) as Contracts.Client.IAdapterAccess<I>;
                }
                else if (typeof(I) == typeof(QnSProjectAward.Contracts.Persistence.App.IProject))
                {
                    result = new Controller.GenericControllerAdapter<QnSProjectAward.Contracts.Persistence.App.IProject>(sessionToken) as Contracts.Client.IAdapterAccess<I>;
                }
                else if (typeof(I) == typeof(QnSProjectAward.Contracts.Persistence.App.IRating))
                {
                    result = new Controller.GenericControllerAdapter<QnSProjectAward.Contracts.Persistence.App.IRating>(sessionToken) as Contracts.Client.IAdapterAccess<I>;
                }
                else if (typeof(I) == typeof(QnSProjectAward.Contracts.Persistence.Account.IAccess))
                {
                    result = new Controller.GenericControllerAdapter<QnSProjectAward.Contracts.Persistence.Account.IAccess>(sessionToken) as Contracts.Client.IAdapterAccess<I>;
                }
                else if (typeof(I) == typeof(QnSProjectAward.Contracts.Persistence.Account.IActionLog))
                {
                    result = new Controller.GenericControllerAdapter<QnSProjectAward.Contracts.Persistence.Account.IActionLog>(sessionToken) as Contracts.Client.IAdapterAccess<I>;
                }
                else if (typeof(I) == typeof(QnSProjectAward.Contracts.Persistence.Account.IIdentity))
                {
                    result = new Controller.GenericControllerAdapter<QnSProjectAward.Contracts.Persistence.Account.IIdentity>(sessionToken) as Contracts.Client.IAdapterAccess<I>;
                }
                else if (typeof(I) == typeof(QnSProjectAward.Contracts.Persistence.Account.IIdentityXRole))
                {
                    result = new Controller.GenericControllerAdapter<QnSProjectAward.Contracts.Persistence.Account.IIdentityXRole>(sessionToken) as Contracts.Client.IAdapterAccess<I>;
                }
                else if (typeof(I) == typeof(QnSProjectAward.Contracts.Persistence.Account.ILoginSession))
                {
                    result = new Controller.GenericControllerAdapter<QnSProjectAward.Contracts.Persistence.Account.ILoginSession>(sessionToken) as Contracts.Client.IAdapterAccess<I>;
                }
                else if (typeof(I) == typeof(QnSProjectAward.Contracts.Persistence.Account.IRole))
                {
                    result = new Controller.GenericControllerAdapter<QnSProjectAward.Contracts.Persistence.Account.IRole>(sessionToken) as Contracts.Client.IAdapterAccess<I>;
                }
                else if (typeof(I) == typeof(QnSProjectAward.Contracts.Persistence.Account.IUser))
                {
                    result = new Controller.GenericControllerAdapter<QnSProjectAward.Contracts.Persistence.Account.IUser>(sessionToken) as Contracts.Client.IAdapterAccess<I>;
                }
                else if (typeof(I) == typeof(QnSProjectAward.Contracts.Business.Account.IAppAccess))
                {
                    result = new Controller.GenericControllerAdapter<QnSProjectAward.Contracts.Business.Account.IAppAccess>(sessionToken) as Contracts.Client.IAdapterAccess<I>;
                }
                else if (typeof(I) == typeof(QnSProjectAward.Contracts.Business.Account.IIdentityUser))
                {
                    result = new Controller.GenericControllerAdapter<QnSProjectAward.Contracts.Business.Account.IIdentityUser>(sessionToken) as Contracts.Client.IAdapterAccess<I>;
                }
            }
            else if (Adapter == AdapterType.Service)
            {
                if (typeof(I) == typeof(QnSProjectAward.Contracts.Persistence.Language.ITranslation))
                {
                    result = new Service.GenericServiceAdapter<QnSProjectAward.Contracts.Persistence.Language.ITranslation, Transfer.Persistence.Language.Translation>(sessionToken, BaseUri, "Translations") as Contracts.Client.IAdapterAccess<I>;
                }
                else if (typeof(I) == typeof(QnSProjectAward.Contracts.Persistence.Data.IBinaryData))
                {
                    result = new Service.GenericServiceAdapter<QnSProjectAward.Contracts.Persistence.Data.IBinaryData, Transfer.Persistence.Data.BinaryData>(sessionToken, BaseUri, "BinaryDatas") as Contracts.Client.IAdapterAccess<I>;
                }
                else if (typeof(I) == typeof(QnSProjectAward.Contracts.Persistence.Configuration.IIdentitySetting))
                {
                    result = new Service.GenericServiceAdapter<QnSProjectAward.Contracts.Persistence.Configuration.IIdentitySetting, Transfer.Persistence.Configuration.IdentitySetting>(sessionToken, BaseUri, "IdentitySettings") as Contracts.Client.IAdapterAccess<I>;
                }
                else if (typeof(I) == typeof(QnSProjectAward.Contracts.Persistence.Configuration.ISetting))
                {
                    result = new Service.GenericServiceAdapter<QnSProjectAward.Contracts.Persistence.Configuration.ISetting, Transfer.Persistence.Configuration.Setting>(sessionToken, BaseUri, "Settings") as Contracts.Client.IAdapterAccess<I>;
                }
                else if (typeof(I) == typeof(QnSProjectAward.Contracts.Persistence.App.IAward))
                {
                    result = new Service.GenericServiceAdapter<QnSProjectAward.Contracts.Persistence.App.IAward, Transfer.Persistence.App.Award>(sessionToken, BaseUri, "Awards") as Contracts.Client.IAdapterAccess<I>;
                }
                else if (typeof(I) == typeof(QnSProjectAward.Contracts.Persistence.App.IJuror))
                {
                    result = new Service.GenericServiceAdapter<QnSProjectAward.Contracts.Persistence.App.IJuror, Transfer.Persistence.App.Juror>(sessionToken, BaseUri, "Jurors") as Contracts.Client.IAdapterAccess<I>;
                }
                else if (typeof(I) == typeof(QnSProjectAward.Contracts.Persistence.App.IMember))
                {
                    result = new Service.GenericServiceAdapter<QnSProjectAward.Contracts.Persistence.App.IMember, Transfer.Persistence.App.Member>(sessionToken, BaseUri, "Members") as Contracts.Client.IAdapterAccess<I>;
                }
                else if (typeof(I) == typeof(QnSProjectAward.Contracts.Persistence.App.IProject))
                {
                    result = new Service.GenericServiceAdapter<QnSProjectAward.Contracts.Persistence.App.IProject, Transfer.Persistence.App.Project>(sessionToken, BaseUri, "Projects") as Contracts.Client.IAdapterAccess<I>;
                }
                else if (typeof(I) == typeof(QnSProjectAward.Contracts.Persistence.App.IRating))
                {
                    result = new Service.GenericServiceAdapter<QnSProjectAward.Contracts.Persistence.App.IRating, Transfer.Persistence.App.Rating>(sessionToken, BaseUri, "Ratings") as Contracts.Client.IAdapterAccess<I>;
                }
                else if (typeof(I) == typeof(QnSProjectAward.Contracts.Persistence.Account.IAccess))
                {
                    result = new Service.GenericServiceAdapter<QnSProjectAward.Contracts.Persistence.Account.IAccess, Transfer.Persistence.Account.Access>(sessionToken, BaseUri, "Access") as Contracts.Client.IAdapterAccess<I>;
                }
                else if (typeof(I) == typeof(QnSProjectAward.Contracts.Persistence.Account.IActionLog))
                {
                    result = new Service.GenericServiceAdapter<QnSProjectAward.Contracts.Persistence.Account.IActionLog, Transfer.Persistence.Account.ActionLog>(sessionToken, BaseUri, "ActionLogs") as Contracts.Client.IAdapterAccess<I>;
                }
                else if (typeof(I) == typeof(QnSProjectAward.Contracts.Persistence.Account.IIdentity))
                {
                    result = new Service.GenericServiceAdapter<QnSProjectAward.Contracts.Persistence.Account.IIdentity, Transfer.Persistence.Account.Identity>(sessionToken, BaseUri, "Identitys") as Contracts.Client.IAdapterAccess<I>;
                }
                else if (typeof(I) == typeof(QnSProjectAward.Contracts.Persistence.Account.IIdentityXRole))
                {
                    result = new Service.GenericServiceAdapter<QnSProjectAward.Contracts.Persistence.Account.IIdentityXRole, Transfer.Persistence.Account.IdentityXRole>(sessionToken, BaseUri, "IdentityXRoles") as Contracts.Client.IAdapterAccess<I>;
                }
                else if (typeof(I) == typeof(QnSProjectAward.Contracts.Persistence.Account.ILoginSession))
                {
                    result = new Service.GenericServiceAdapter<QnSProjectAward.Contracts.Persistence.Account.ILoginSession, Transfer.Persistence.Account.LoginSession>(sessionToken, BaseUri, "LoginSessions") as Contracts.Client.IAdapterAccess<I>;
                }
                else if (typeof(I) == typeof(QnSProjectAward.Contracts.Persistence.Account.IRole))
                {
                    result = new Service.GenericServiceAdapter<QnSProjectAward.Contracts.Persistence.Account.IRole, Transfer.Persistence.Account.Role>(sessionToken, BaseUri, "Roles") as Contracts.Client.IAdapterAccess<I>;
                }
                else if (typeof(I) == typeof(QnSProjectAward.Contracts.Persistence.Account.IUser))
                {
                    result = new Service.GenericServiceAdapter<QnSProjectAward.Contracts.Persistence.Account.IUser, Transfer.Persistence.Account.User>(sessionToken, BaseUri, "Users") as Contracts.Client.IAdapterAccess<I>;
                }
                else if (typeof(I) == typeof(QnSProjectAward.Contracts.Business.Account.IAppAccess))
                {
                    result = new Service.GenericServiceAdapter<QnSProjectAward.Contracts.Business.Account.IAppAccess, Transfer.Business.Account.AppAccess>(sessionToken, BaseUri, "AppAccess") as Contracts.Client.IAdapterAccess<I>;
                }
                else if (typeof(I) == typeof(QnSProjectAward.Contracts.Business.Account.IIdentityUser))
                {
                    result = new Service.GenericServiceAdapter<QnSProjectAward.Contracts.Business.Account.IIdentityUser, Transfer.Business.Account.IdentityUser>(sessionToken, BaseUri, "IdentityUsers") as Contracts.Client.IAdapterAccess<I>;
                }
            }
            return result;
        }
    }
}
