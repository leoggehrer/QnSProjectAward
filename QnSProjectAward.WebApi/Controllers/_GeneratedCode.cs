//@QnSGeneratedCode
namespace QnSProjectAward.WebApi.Controllers.Business.Account
{
    using Microsoft.AspNetCore.Mvc;
    using TContract = Contracts.Business.Account.IIdentityUser;
    using TModel = Transfer.Business.Account.IdentityUser;
    [ApiController]
    [Route("Controller")]
    public partial class IdentityUsersController : GenericController<TContract, TModel>
    {
    }
}
namespace QnSProjectAward.WebApi.Controllers.Business.Account
{
    using Microsoft.AspNetCore.Mvc;
    using TContract = Contracts.Business.Account.IAppAccess;
    using TModel = Transfer.Business.Account.AppAccess;
    [ApiController]
    [Route("Controller")]
    public partial class AppAccessController : GenericController<TContract, TModel>
    {
    }
}
namespace QnSProjectAward.WebApi.Controllers.Persistence.Account
{
    using Microsoft.AspNetCore.Mvc;
    using TContract = Contracts.Persistence.Account.IUser;
    using TModel = Transfer.Persistence.Account.User;
    [ApiController]
    [Route("Controller")]
    public partial class UsersController : GenericController<TContract, TModel>
    {
    }
}
namespace QnSProjectAward.WebApi.Controllers.Persistence.Account
{
    using Microsoft.AspNetCore.Mvc;
    using TContract = Contracts.Persistence.Account.IRole;
    using TModel = Transfer.Persistence.Account.Role;
    [ApiController]
    [Route("Controller")]
    public partial class RolesController : GenericController<TContract, TModel>
    {
    }
}
namespace QnSProjectAward.WebApi.Controllers.Persistence.Account
{
    using Microsoft.AspNetCore.Mvc;
    using TContract = Contracts.Persistence.Account.ILoginSession;
    using TModel = Transfer.Persistence.Account.LoginSession;
    [ApiController]
    [Route("Controller")]
    public partial class LoginSessionsController : GenericController<TContract, TModel>
    {
    }
}
namespace QnSProjectAward.WebApi.Controllers.Persistence.Account
{
    using Microsoft.AspNetCore.Mvc;
    using TContract = Contracts.Persistence.Account.IIdentityXRole;
    using TModel = Transfer.Persistence.Account.IdentityXRole;
    [ApiController]
    [Route("Controller")]
    public partial class IdentityXRolesController : GenericController<TContract, TModel>
    {
    }
}
namespace QnSProjectAward.WebApi.Controllers.Persistence.Account
{
    using Microsoft.AspNetCore.Mvc;
    using TContract = Contracts.Persistence.Account.IIdentity;
    using TModel = Transfer.Persistence.Account.Identity;
    [ApiController]
    [Route("Controller")]
    public partial class IdentitysController : GenericController<TContract, TModel>
    {
    }
}
namespace QnSProjectAward.WebApi.Controllers.Persistence.Account
{
    using Microsoft.AspNetCore.Mvc;
    using TContract = Contracts.Persistence.Account.IActionLog;
    using TModel = Transfer.Persistence.Account.ActionLog;
    [ApiController]
    [Route("Controller")]
    public partial class ActionLogsController : GenericController<TContract, TModel>
    {
    }
}
namespace QnSProjectAward.WebApi.Controllers.Persistence.Account
{
    using Microsoft.AspNetCore.Mvc;
    using TContract = Contracts.Persistence.Account.IAccess;
    using TModel = Transfer.Persistence.Account.Access;
    [ApiController]
    [Route("Controller")]
    public partial class AccessController : GenericController<TContract, TModel>
    {
    }
}
namespace QnSProjectAward.WebApi.Controllers.Persistence.App
{
    using Microsoft.AspNetCore.Mvc;
    using TContract = Contracts.Persistence.App.IRating;
    using TModel = Transfer.Persistence.App.Rating;
    [ApiController]
    [Route("Controller")]
    public partial class RatingsController : GenericController<TContract, TModel>
    {
    }
}
namespace QnSProjectAward.WebApi.Controllers.Persistence.App
{
    using Microsoft.AspNetCore.Mvc;
    using TContract = Contracts.Persistence.App.IProject;
    using TModel = Transfer.Persistence.App.Project;
    [ApiController]
    [Route("Controller")]
    public partial class ProjectsController : GenericController<TContract, TModel>
    {
    }
}
namespace QnSProjectAward.WebApi.Controllers.Persistence.App
{
    using Microsoft.AspNetCore.Mvc;
    using TContract = Contracts.Persistence.App.IMember;
    using TModel = Transfer.Persistence.App.Member;
    [ApiController]
    [Route("Controller")]
    public partial class MembersController : GenericController<TContract, TModel>
    {
    }
}
namespace QnSProjectAward.WebApi.Controllers.Persistence.App
{
    using Microsoft.AspNetCore.Mvc;
    using TContract = Contracts.Persistence.App.IJuror;
    using TModel = Transfer.Persistence.App.Juror;
    [ApiController]
    [Route("Controller")]
    public partial class JurorsController : GenericController<TContract, TModel>
    {
    }
}
namespace QnSProjectAward.WebApi.Controllers.Persistence.App
{
    using Microsoft.AspNetCore.Mvc;
    using TContract = Contracts.Persistence.App.IAward;
    using TModel = Transfer.Persistence.App.Award;
    [ApiController]
    [Route("Controller")]
    public partial class AwardsController : GenericController<TContract, TModel>
    {
    }
}
namespace QnSProjectAward.WebApi.Controllers.Persistence.Configuration
{
    using Microsoft.AspNetCore.Mvc;
    using TContract = Contracts.Persistence.Configuration.ISetting;
    using TModel = Transfer.Persistence.Configuration.Setting;
    [ApiController]
    [Route("Controller")]
    public partial class SettingsController : GenericController<TContract, TModel>
    {
    }
}
namespace QnSProjectAward.WebApi.Controllers.Persistence.Configuration
{
    using Microsoft.AspNetCore.Mvc;
    using TContract = Contracts.Persistence.Configuration.IIdentitySetting;
    using TModel = Transfer.Persistence.Configuration.IdentitySetting;
    [ApiController]
    [Route("Controller")]
    public partial class IdentitySettingsController : GenericController<TContract, TModel>
    {
    }
}
namespace QnSProjectAward.WebApi.Controllers.Persistence.Data
{
    using Microsoft.AspNetCore.Mvc;
    using TContract = Contracts.Persistence.Data.IBinaryData;
    using TModel = Transfer.Persistence.Data.BinaryData;
    [ApiController]
    [Route("Controller")]
    public partial class BinaryDatasController : GenericController<TContract, TModel>
    {
    }
}
namespace QnSProjectAward.WebApi.Controllers.Persistence.Language
{
    using Microsoft.AspNetCore.Mvc;
    using TContract = Contracts.Persistence.Language.ITranslation;
    using TModel = Transfer.Persistence.Language.Translation;
    [ApiController]
    [Route("Controller")]
    public partial class TranslationsController : GenericController<TContract, TModel>
    {
    }
}
