//@QnSGeneratedCode
namespace QnSProjectAward.Transfer.Persistence.Account
{
    partial class User : VersionModel
    {
    }
}
namespace QnSProjectAward.Transfer.Persistence.Account
{
    using System;
    public partial class User : QnSProjectAward.Contracts.Persistence.Account.IUser
    {
        static User()
        {
            ClassConstructing();
            ClassConstructed();
        }
        static partial void ClassConstructing();
        static partial void ClassConstructed();
        public User()
        {
            Constructing();
            Constructed();
        }
        partial void Constructing();
        partial void Constructed();
        public System.Int32 IdentityId
        {
            get;
            set;
        }
        public System.String Firstname
        {
            get;
            set;
        }
        public System.String Lastname
        {
            get;
            set;
        }
        public void CopyProperties(QnSProjectAward.Contracts.Persistence.Account.IUser other)
        {
            if (other == null)
            {
                throw new System.ArgumentNullException(nameof(other));
            }
            bool handled = false;
            BeforeCopyProperties(other, ref handled);
            if (handled == false)
            {
                Id = other.Id;
                RowVersion = other.RowVersion;
                IdentityId = other.IdentityId;
                Firstname = other.Firstname;
                Lastname = other.Lastname;
            }
            AfterCopyProperties(other);
        }
        partial void BeforeCopyProperties(QnSProjectAward.Contracts.Persistence.Account.IUser other, ref bool handled);
        partial void AfterCopyProperties(QnSProjectAward.Contracts.Persistence.Account.IUser other);
        public static Persistence.Account.User Create()
        {
            BeforeCreate();
            var result = new Persistence.Account.User();
            AfterCreate(result);
            return result;
        }
        public static Persistence.Account.User Create(object other)
        {
            BeforeCreate(other);
            CommonBase.Extensions.ObjectExtensions.CheckArgument(other, nameof(other));
            var result = new Persistence.Account.User();
            CommonBase.Extensions.ObjectExtensions.CopyFrom(result, other);
            AfterCreate(result, other);
            return result;
        }
        public static Persistence.Account.User Create(QnSProjectAward.Contracts.Persistence.Account.IUser other)
        {
            BeforeCreate(other);
            var result = new Persistence.Account.User();
            result.CopyProperties(other);
            AfterCreate(result, other);
            return result;
        }
        static partial void BeforeCreate();
        static partial void AfterCreate(Persistence.Account.User instance);
        static partial void BeforeCreate(object other);
        static partial void AfterCreate(Persistence.Account.User instance, object other);
        static partial void BeforeCreate(QnSProjectAward.Contracts.Persistence.Account.IUser other);
        static partial void AfterCreate(Persistence.Account.User instance, QnSProjectAward.Contracts.Persistence.Account.IUser other);
    }
}
namespace QnSProjectAward.Transfer.Persistence.Account
{
    partial class Role : VersionModel
    {
    }
}
namespace QnSProjectAward.Transfer.Persistence.Account
{
    using System;
    public partial class Role : QnSProjectAward.Contracts.Persistence.Account.IRole
    {
        static Role()
        {
            ClassConstructing();
            ClassConstructed();
        }
        static partial void ClassConstructing();
        static partial void ClassConstructed();
        public Role()
        {
            Constructing();
            Constructed();
        }
        partial void Constructing();
        partial void Constructed();
        public System.String Designation
        {
            get;
            set;
        }
        public System.String Description
        {
            get;
            set;
        }
        public void CopyProperties(QnSProjectAward.Contracts.Persistence.Account.IRole other)
        {
            if (other == null)
            {
                throw new System.ArgumentNullException(nameof(other));
            }
            bool handled = false;
            BeforeCopyProperties(other, ref handled);
            if (handled == false)
            {
                Id = other.Id;
                RowVersion = other.RowVersion;
                Designation = other.Designation;
                Description = other.Description;
            }
            AfterCopyProperties(other);
        }
        partial void BeforeCopyProperties(QnSProjectAward.Contracts.Persistence.Account.IRole other, ref bool handled);
        partial void AfterCopyProperties(QnSProjectAward.Contracts.Persistence.Account.IRole other);
        public static Persistence.Account.Role Create()
        {
            BeforeCreate();
            var result = new Persistence.Account.Role();
            AfterCreate(result);
            return result;
        }
        public static Persistence.Account.Role Create(object other)
        {
            BeforeCreate(other);
            CommonBase.Extensions.ObjectExtensions.CheckArgument(other, nameof(other));
            var result = new Persistence.Account.Role();
            CommonBase.Extensions.ObjectExtensions.CopyFrom(result, other);
            AfterCreate(result, other);
            return result;
        }
        public static Persistence.Account.Role Create(QnSProjectAward.Contracts.Persistence.Account.IRole other)
        {
            BeforeCreate(other);
            var result = new Persistence.Account.Role();
            result.CopyProperties(other);
            AfterCreate(result, other);
            return result;
        }
        static partial void BeforeCreate();
        static partial void AfterCreate(Persistence.Account.Role instance);
        static partial void BeforeCreate(object other);
        static partial void AfterCreate(Persistence.Account.Role instance, object other);
        static partial void BeforeCreate(QnSProjectAward.Contracts.Persistence.Account.IRole other);
        static partial void AfterCreate(Persistence.Account.Role instance, QnSProjectAward.Contracts.Persistence.Account.IRole other);
    }
}
namespace QnSProjectAward.Transfer.Persistence.Account
{
    partial class LoginSession : VersionModel
    {
    }
}
namespace QnSProjectAward.Transfer.Persistence.Account
{
    using System;
    public partial class LoginSession : QnSProjectAward.Contracts.Persistence.Account.ILoginSession
    {
        static LoginSession()
        {
            ClassConstructing();
            ClassConstructed();
        }
        static partial void ClassConstructing();
        static partial void ClassConstructed();
        public LoginSession()
        {
            Constructing();
            Constructed();
        }
        partial void Constructing();
        partial void Constructed();
        public System.Int32 IdentityId
        {
            get
            {
                OnIdentityIdReading();
                return _identityId;
            }
            set
            {
                bool handled = false;
                OnIdentityIdChanging(ref handled, ref _identityId);
                if (handled == false)
                {
                    _identityId = value;
                }
                OnIdentityIdChanged();
            }
        }
        private System.Int32 _identityId;
        partial void OnIdentityIdReading();
        partial void OnIdentityIdChanging(ref bool handled, ref System.Int32 _identityId);
        partial void OnIdentityIdChanged();
        public System.Boolean IsRemoteAuth
        {
            get
            {
                OnIsRemoteAuthReading();
                return _isRemoteAuth;
            }
            set
            {
                bool handled = false;
                OnIsRemoteAuthChanging(ref handled, ref _isRemoteAuth);
                if (handled == false)
                {
                    _isRemoteAuth = value;
                }
                OnIsRemoteAuthChanged();
            }
        }
        private System.Boolean _isRemoteAuth;
        partial void OnIsRemoteAuthReading();
        partial void OnIsRemoteAuthChanging(ref bool handled, ref System.Boolean _isRemoteAuth);
        partial void OnIsRemoteAuthChanged();
        public System.String Origin
        {
            get
            {
                OnOriginReading();
                return _origin;
            }
            set
            {
                bool handled = false;
                OnOriginChanging(ref handled, ref _origin);
                if (handled == false)
                {
                    _origin = value;
                }
                OnOriginChanged();
            }
        }
        private System.String _origin;
        partial void OnOriginReading();
        partial void OnOriginChanging(ref bool handled, ref System.String _origin);
        partial void OnOriginChanged();
        public System.String Name
        {
            get
            {
                OnNameReading();
                return _name;
            }
            set
            {
                bool handled = false;
                OnNameChanging(ref handled, ref _name);
                if (handled == false)
                {
                    _name = value;
                }
                OnNameChanged();
            }
        }
        private System.String _name;
        partial void OnNameReading();
        partial void OnNameChanging(ref bool handled, ref System.String _name);
        partial void OnNameChanged();
        public System.String Email
        {
            get
            {
                OnEmailReading();
                return _email;
            }
            set
            {
                bool handled = false;
                OnEmailChanging(ref handled, ref _email);
                if (handled == false)
                {
                    _email = value;
                }
                OnEmailChanged();
            }
        }
        private System.String _email;
        partial void OnEmailReading();
        partial void OnEmailChanging(ref bool handled, ref System.String _email);
        partial void OnEmailChanged();
        public System.Int32 TimeOutInMinutes
        {
            get
            {
                OnTimeOutInMinutesReading();
                return _timeOutInMinutes;
            }
            set
            {
                bool handled = false;
                OnTimeOutInMinutesChanging(ref handled, ref _timeOutInMinutes);
                if (handled == false)
                {
                    _timeOutInMinutes = value;
                }
                OnTimeOutInMinutesChanged();
            }
        }
        private System.Int32 _timeOutInMinutes;
        partial void OnTimeOutInMinutesReading();
        partial void OnTimeOutInMinutesChanging(ref bool handled, ref System.Int32 _timeOutInMinutes);
        partial void OnTimeOutInMinutesChanged();
        public System.String JsonWebToken
        {
            get
            {
                OnJsonWebTokenReading();
                return _jsonWebToken;
            }
            set
            {
                bool handled = false;
                OnJsonWebTokenChanging(ref handled, ref _jsonWebToken);
                if (handled == false)
                {
                    _jsonWebToken = value;
                }
                OnJsonWebTokenChanged();
            }
        }
        private System.String _jsonWebToken;
        partial void OnJsonWebTokenReading();
        partial void OnJsonWebTokenChanging(ref bool handled, ref System.String _jsonWebToken);
        partial void OnJsonWebTokenChanged();
        public System.String SessionToken
        {
            get
            {
                OnSessionTokenReading();
                return _sessionToken;
            }
            set
            {
                bool handled = false;
                OnSessionTokenChanging(ref handled, ref _sessionToken);
                if (handled == false)
                {
                    _sessionToken = value;
                }
                OnSessionTokenChanged();
            }
        }
        private System.String _sessionToken;
        partial void OnSessionTokenReading();
        partial void OnSessionTokenChanging(ref bool handled, ref System.String _sessionToken);
        partial void OnSessionTokenChanged();
        public System.DateTime LoginTime
        {
            get
            {
                OnLoginTimeReading();
                return _loginTime;
            }
            set
            {
                bool handled = false;
                OnLoginTimeChanging(ref handled, ref _loginTime);
                if (handled == false)
                {
                    _loginTime = value;
                }
                OnLoginTimeChanged();
            }
        }
        private System.DateTime _loginTime;
        partial void OnLoginTimeReading();
        partial void OnLoginTimeChanging(ref bool handled, ref System.DateTime _loginTime);
        partial void OnLoginTimeChanged();
        public System.DateTime LastAccess
        {
            get
            {
                OnLastAccessReading();
                return _lastAccess;
            }
            set
            {
                bool handled = false;
                OnLastAccessChanging(ref handled, ref _lastAccess);
                if (handled == false)
                {
                    _lastAccess = value;
                }
                OnLastAccessChanged();
            }
        }
        private System.DateTime _lastAccess;
        partial void OnLastAccessReading();
        partial void OnLastAccessChanging(ref bool handled, ref System.DateTime _lastAccess);
        partial void OnLastAccessChanged();
        public System.DateTime? LogoutTime
        {
            get
            {
                OnLogoutTimeReading();
                return _logoutTime;
            }
            set
            {
                bool handled = false;
                OnLogoutTimeChanging(ref handled, ref _logoutTime);
                if (handled == false)
                {
                    _logoutTime = value;
                }
                OnLogoutTimeChanged();
            }
        }
        private System.DateTime? _logoutTime;
        partial void OnLogoutTimeReading();
        partial void OnLogoutTimeChanging(ref bool handled, ref System.DateTime? _logoutTime);
        partial void OnLogoutTimeChanged();
        public System.String OptionalInfo
        {
            get;
            set;
        }
        public void CopyProperties(QnSProjectAward.Contracts.Persistence.Account.ILoginSession other)
        {
            if (other == null)
            {
                throw new System.ArgumentNullException(nameof(other));
            }
            bool handled = false;
            BeforeCopyProperties(other, ref handled);
            if (handled == false)
            {
                Id = other.Id;
                RowVersion = other.RowVersion;
                IdentityId = other.IdentityId;
                IsRemoteAuth = other.IsRemoteAuth;
                Origin = other.Origin;
                Name = other.Name;
                Email = other.Email;
                TimeOutInMinutes = other.TimeOutInMinutes;
                JsonWebToken = other.JsonWebToken;
                SessionToken = other.SessionToken;
                LoginTime = other.LoginTime;
                LastAccess = other.LastAccess;
                LogoutTime = other.LogoutTime;
                OptionalInfo = other.OptionalInfo;
            }
            AfterCopyProperties(other);
        }
        partial void BeforeCopyProperties(QnSProjectAward.Contracts.Persistence.Account.ILoginSession other, ref bool handled);
        partial void AfterCopyProperties(QnSProjectAward.Contracts.Persistence.Account.ILoginSession other);
        public static Persistence.Account.LoginSession Create()
        {
            BeforeCreate();
            var result = new Persistence.Account.LoginSession();
            AfterCreate(result);
            return result;
        }
        public static Persistence.Account.LoginSession Create(object other)
        {
            BeforeCreate(other);
            CommonBase.Extensions.ObjectExtensions.CheckArgument(other, nameof(other));
            var result = new Persistence.Account.LoginSession();
            CommonBase.Extensions.ObjectExtensions.CopyFrom(result, other);
            AfterCreate(result, other);
            return result;
        }
        public static Persistence.Account.LoginSession Create(QnSProjectAward.Contracts.Persistence.Account.ILoginSession other)
        {
            BeforeCreate(other);
            var result = new Persistence.Account.LoginSession();
            result.CopyProperties(other);
            AfterCreate(result, other);
            return result;
        }
        static partial void BeforeCreate();
        static partial void AfterCreate(Persistence.Account.LoginSession instance);
        static partial void BeforeCreate(object other);
        static partial void AfterCreate(Persistence.Account.LoginSession instance, object other);
        static partial void BeforeCreate(QnSProjectAward.Contracts.Persistence.Account.ILoginSession other);
        static partial void AfterCreate(Persistence.Account.LoginSession instance, QnSProjectAward.Contracts.Persistence.Account.ILoginSession other);
    }
}
namespace QnSProjectAward.Transfer.Persistence.Account
{
    partial class IdentityXRole : VersionModel
    {
    }
}
namespace QnSProjectAward.Transfer.Persistence.Account
{
    using System;
    public partial class IdentityXRole : QnSProjectAward.Contracts.Persistence.Account.IIdentityXRole
    {
        static IdentityXRole()
        {
            ClassConstructing();
            ClassConstructed();
        }
        static partial void ClassConstructing();
        static partial void ClassConstructed();
        public IdentityXRole()
        {
            Constructing();
            Constructed();
        }
        partial void Constructing();
        partial void Constructed();
        public System.Int32 IdentityId
        {
            get;
            set;
        }
        public System.Int32 RoleId
        {
            get;
            set;
        }
        public void CopyProperties(QnSProjectAward.Contracts.Persistence.Account.IIdentityXRole other)
        {
            if (other == null)
            {
                throw new System.ArgumentNullException(nameof(other));
            }
            bool handled = false;
            BeforeCopyProperties(other, ref handled);
            if (handled == false)
            {
                Id = other.Id;
                RowVersion = other.RowVersion;
                IdentityId = other.IdentityId;
                RoleId = other.RoleId;
            }
            AfterCopyProperties(other);
        }
        partial void BeforeCopyProperties(QnSProjectAward.Contracts.Persistence.Account.IIdentityXRole other, ref bool handled);
        partial void AfterCopyProperties(QnSProjectAward.Contracts.Persistence.Account.IIdentityXRole other);
        public static Persistence.Account.IdentityXRole Create()
        {
            BeforeCreate();
            var result = new Persistence.Account.IdentityXRole();
            AfterCreate(result);
            return result;
        }
        public static Persistence.Account.IdentityXRole Create(object other)
        {
            BeforeCreate(other);
            CommonBase.Extensions.ObjectExtensions.CheckArgument(other, nameof(other));
            var result = new Persistence.Account.IdentityXRole();
            CommonBase.Extensions.ObjectExtensions.CopyFrom(result, other);
            AfterCreate(result, other);
            return result;
        }
        public static Persistence.Account.IdentityXRole Create(QnSProjectAward.Contracts.Persistence.Account.IIdentityXRole other)
        {
            BeforeCreate(other);
            var result = new Persistence.Account.IdentityXRole();
            result.CopyProperties(other);
            AfterCreate(result, other);
            return result;
        }
        static partial void BeforeCreate();
        static partial void AfterCreate(Persistence.Account.IdentityXRole instance);
        static partial void BeforeCreate(object other);
        static partial void AfterCreate(Persistence.Account.IdentityXRole instance, object other);
        static partial void BeforeCreate(QnSProjectAward.Contracts.Persistence.Account.IIdentityXRole other);
        static partial void AfterCreate(Persistence.Account.IdentityXRole instance, QnSProjectAward.Contracts.Persistence.Account.IIdentityXRole other);
    }
}
namespace QnSProjectAward.Transfer.Persistence.Account
{
    partial class Identity : VersionModel
    {
    }
}
namespace QnSProjectAward.Transfer.Persistence.Account
{
    using System;
    public partial class Identity : QnSProjectAward.Contracts.Persistence.Account.IIdentity
    {
        static Identity()
        {
            ClassConstructing();
            ClassConstructed();
        }
        static partial void ClassConstructing();
        static partial void ClassConstructed();
        public Identity()
        {
            Constructing();
            Constructed();
        }
        partial void Constructing();
        partial void Constructed();
        public System.String Guid
        {
            get;
            set;
        }
        public System.String Name
        {
            get;
            set;
        }
        public System.String Email
        {
            get;
            set;
        }
        public System.String Password
        {
            get;
            set;
        }
        public System.Int32 TimeOutInMinutes
        {
            get;
            set;
        }
        = 30;
        public System.Boolean EnableJwtAuth
        {
            get;
            set;
        }
        public System.Int32 AccessFailedCount
        {
            get;
            set;
        }
        public QnSProjectAward.Contracts.Modules.Common.State State
        {
            get;
            set;
        }
        = Contracts.Modules.Common.State.Active;
        public void CopyProperties(QnSProjectAward.Contracts.Persistence.Account.IIdentity other)
        {
            if (other == null)
            {
                throw new System.ArgumentNullException(nameof(other));
            }
            bool handled = false;
            BeforeCopyProperties(other, ref handled);
            if (handled == false)
            {
                Id = other.Id;
                RowVersion = other.RowVersion;
                Guid = other.Guid;
                Name = other.Name;
                Email = other.Email;
                Password = other.Password;
                TimeOutInMinutes = other.TimeOutInMinutes;
                EnableJwtAuth = other.EnableJwtAuth;
                AccessFailedCount = other.AccessFailedCount;
                State = other.State;
            }
            AfterCopyProperties(other);
        }
        partial void BeforeCopyProperties(QnSProjectAward.Contracts.Persistence.Account.IIdentity other, ref bool handled);
        partial void AfterCopyProperties(QnSProjectAward.Contracts.Persistence.Account.IIdentity other);
        public static Persistence.Account.Identity Create()
        {
            BeforeCreate();
            var result = new Persistence.Account.Identity();
            AfterCreate(result);
            return result;
        }
        public static Persistence.Account.Identity Create(object other)
        {
            BeforeCreate(other);
            CommonBase.Extensions.ObjectExtensions.CheckArgument(other, nameof(other));
            var result = new Persistence.Account.Identity();
            CommonBase.Extensions.ObjectExtensions.CopyFrom(result, other);
            AfterCreate(result, other);
            return result;
        }
        public static Persistence.Account.Identity Create(QnSProjectAward.Contracts.Persistence.Account.IIdentity other)
        {
            BeforeCreate(other);
            var result = new Persistence.Account.Identity();
            result.CopyProperties(other);
            AfterCreate(result, other);
            return result;
        }
        static partial void BeforeCreate();
        static partial void AfterCreate(Persistence.Account.Identity instance);
        static partial void BeforeCreate(object other);
        static partial void AfterCreate(Persistence.Account.Identity instance, object other);
        static partial void BeforeCreate(QnSProjectAward.Contracts.Persistence.Account.IIdentity other);
        static partial void AfterCreate(Persistence.Account.Identity instance, QnSProjectAward.Contracts.Persistence.Account.IIdentity other);
    }
}
namespace QnSProjectAward.Transfer.Persistence.Account
{
    partial class ActionLog : VersionModel
    {
    }
}
namespace QnSProjectAward.Transfer.Persistence.Account
{
    using System;
    public partial class ActionLog : QnSProjectAward.Contracts.Persistence.Account.IActionLog
    {
        static ActionLog()
        {
            ClassConstructing();
            ClassConstructed();
        }
        static partial void ClassConstructing();
        static partial void ClassConstructed();
        public ActionLog()
        {
            Constructing();
            Constructed();
        }
        partial void Constructing();
        partial void Constructed();
        public System.Int32 IdentityId
        {
            get;
            set;
        }
        public System.DateTime Time
        {
            get;
            set;
        }
        public System.String Subject
        {
            get;
            set;
        }
        public System.String Action
        {
            get;
            set;
        }
        public System.String Info
        {
            get;
            set;
        }
        public void CopyProperties(QnSProjectAward.Contracts.Persistence.Account.IActionLog other)
        {
            if (other == null)
            {
                throw new System.ArgumentNullException(nameof(other));
            }
            bool handled = false;
            BeforeCopyProperties(other, ref handled);
            if (handled == false)
            {
                Id = other.Id;
                RowVersion = other.RowVersion;
                IdentityId = other.IdentityId;
                Time = other.Time;
                Subject = other.Subject;
                Action = other.Action;
                Info = other.Info;
            }
            AfterCopyProperties(other);
        }
        partial void BeforeCopyProperties(QnSProjectAward.Contracts.Persistence.Account.IActionLog other, ref bool handled);
        partial void AfterCopyProperties(QnSProjectAward.Contracts.Persistence.Account.IActionLog other);
        public static Persistence.Account.ActionLog Create()
        {
            BeforeCreate();
            var result = new Persistence.Account.ActionLog();
            AfterCreate(result);
            return result;
        }
        public static Persistence.Account.ActionLog Create(object other)
        {
            BeforeCreate(other);
            CommonBase.Extensions.ObjectExtensions.CheckArgument(other, nameof(other));
            var result = new Persistence.Account.ActionLog();
            CommonBase.Extensions.ObjectExtensions.CopyFrom(result, other);
            AfterCreate(result, other);
            return result;
        }
        public static Persistence.Account.ActionLog Create(QnSProjectAward.Contracts.Persistence.Account.IActionLog other)
        {
            BeforeCreate(other);
            var result = new Persistence.Account.ActionLog();
            result.CopyProperties(other);
            AfterCreate(result, other);
            return result;
        }
        static partial void BeforeCreate();
        static partial void AfterCreate(Persistence.Account.ActionLog instance);
        static partial void BeforeCreate(object other);
        static partial void AfterCreate(Persistence.Account.ActionLog instance, object other);
        static partial void BeforeCreate(QnSProjectAward.Contracts.Persistence.Account.IActionLog other);
        static partial void AfterCreate(Persistence.Account.ActionLog instance, QnSProjectAward.Contracts.Persistence.Account.IActionLog other);
    }
}
namespace QnSProjectAward.Transfer.Persistence.Configuration
{
    partial class Setting : VersionModel
    {
    }
}
namespace QnSProjectAward.Transfer.Persistence.Configuration
{
    using System;
    public partial class Setting : QnSProjectAward.Contracts.Persistence.Configuration.ISetting
    {
        static Setting()
        {
            ClassConstructing();
            ClassConstructed();
        }
        static partial void ClassConstructing();
        static partial void ClassConstructed();
        public Setting()
        {
            Constructing();
            Constructed();
        }
        partial void Constructing();
        partial void Constructed();
        public System.String AppName
        {
            get;
            set;
        }
        = nameof(QnSProjectAward);
        public System.String Key
        {
            get;
            set;
        }
        public System.String Value
        {
            get;
            set;
        }
        = string.Empty;
        public void CopyProperties(QnSProjectAward.Contracts.Persistence.Configuration.ISetting other)
        {
            if (other == null)
            {
                throw new System.ArgumentNullException(nameof(other));
            }
            bool handled = false;
            BeforeCopyProperties(other, ref handled);
            if (handled == false)
            {
                RowVersion = other.RowVersion;
                Id = other.Id;
                AppName = other.AppName;
                Key = other.Key;
                Value = other.Value;
            }
            AfterCopyProperties(other);
        }
        partial void BeforeCopyProperties(QnSProjectAward.Contracts.Persistence.Configuration.ISetting other, ref bool handled);
        partial void AfterCopyProperties(QnSProjectAward.Contracts.Persistence.Configuration.ISetting other);
        public static Persistence.Configuration.Setting Create()
        {
            BeforeCreate();
            var result = new Persistence.Configuration.Setting();
            AfterCreate(result);
            return result;
        }
        public static Persistence.Configuration.Setting Create(object other)
        {
            BeforeCreate(other);
            CommonBase.Extensions.ObjectExtensions.CheckArgument(other, nameof(other));
            var result = new Persistence.Configuration.Setting();
            CommonBase.Extensions.ObjectExtensions.CopyFrom(result, other);
            AfterCreate(result, other);
            return result;
        }
        public static Persistence.Configuration.Setting Create(QnSProjectAward.Contracts.Persistence.Configuration.ISetting other)
        {
            BeforeCreate(other);
            var result = new Persistence.Configuration.Setting();
            result.CopyProperties(other);
            AfterCreate(result, other);
            return result;
        }
        static partial void BeforeCreate();
        static partial void AfterCreate(Persistence.Configuration.Setting instance);
        static partial void BeforeCreate(object other);
        static partial void AfterCreate(Persistence.Configuration.Setting instance, object other);
        static partial void BeforeCreate(QnSProjectAward.Contracts.Persistence.Configuration.ISetting other);
        static partial void AfterCreate(Persistence.Configuration.Setting instance, QnSProjectAward.Contracts.Persistence.Configuration.ISetting other);
    }
}
namespace QnSProjectAward.Transfer.Persistence.Data
{
    partial class BinaryData : VersionModel
    {
    }
}
namespace QnSProjectAward.Transfer.Persistence.Data
{
    using System;
    public partial class BinaryData : QnSProjectAward.Contracts.Persistence.Data.IBinaryData
    {
        static BinaryData()
        {
            ClassConstructing();
            ClassConstructed();
        }
        static partial void ClassConstructing();
        static partial void ClassConstructed();
        public BinaryData()
        {
            Constructing();
            Constructed();
        }
        partial void Constructing();
        partial void Constructed();
        public System.Guid Guid
        {
            get;
            set;
        }
        public System.Byte[] Data
        {
            get;
            set;
        }
        public void CopyProperties(QnSProjectAward.Contracts.Persistence.Data.IBinaryData other)
        {
            if (other == null)
            {
                throw new System.ArgumentNullException(nameof(other));
            }
            bool handled = false;
            BeforeCopyProperties(other, ref handled);
            if (handled == false)
            {
                Id = other.Id;
                RowVersion = other.RowVersion;
                Guid = other.Guid;
                Data = other.Data;
            }
            AfterCopyProperties(other);
        }
        partial void BeforeCopyProperties(QnSProjectAward.Contracts.Persistence.Data.IBinaryData other, ref bool handled);
        partial void AfterCopyProperties(QnSProjectAward.Contracts.Persistence.Data.IBinaryData other);
        public static Persistence.Data.BinaryData Create()
        {
            BeforeCreate();
            var result = new Persistence.Data.BinaryData();
            AfterCreate(result);
            return result;
        }
        public static Persistence.Data.BinaryData Create(object other)
        {
            BeforeCreate(other);
            CommonBase.Extensions.ObjectExtensions.CheckArgument(other, nameof(other));
            var result = new Persistence.Data.BinaryData();
            CommonBase.Extensions.ObjectExtensions.CopyFrom(result, other);
            AfterCreate(result, other);
            return result;
        }
        public static Persistence.Data.BinaryData Create(QnSProjectAward.Contracts.Persistence.Data.IBinaryData other)
        {
            BeforeCreate(other);
            var result = new Persistence.Data.BinaryData();
            result.CopyProperties(other);
            AfterCreate(result, other);
            return result;
        }
        static partial void BeforeCreate();
        static partial void AfterCreate(Persistence.Data.BinaryData instance);
        static partial void BeforeCreate(object other);
        static partial void AfterCreate(Persistence.Data.BinaryData instance, object other);
        static partial void BeforeCreate(QnSProjectAward.Contracts.Persistence.Data.IBinaryData other);
        static partial void AfterCreate(Persistence.Data.BinaryData instance, QnSProjectAward.Contracts.Persistence.Data.IBinaryData other);
    }
}
namespace QnSProjectAward.Transfer.Persistence.Language
{
    partial class Translation : VersionModel
    {
    }
}
namespace QnSProjectAward.Transfer.Persistence.Language
{
    using System;
    public partial class Translation : QnSProjectAward.Contracts.Persistence.Language.ITranslation
    {
        static Translation()
        {
            ClassConstructing();
            ClassConstructed();
        }
        static partial void ClassConstructing();
        static partial void ClassConstructed();
        public Translation()
        {
            Constructing();
            Constructed();
        }
        partial void Constructing();
        partial void Constructed();
        public System.String AppName
        {
            get;
            set;
        }
        = nameof(QnSProjectAward);
        public QnSProjectAward.Contracts.Modules.Common.LanguageCode KeyLanguage
        {
            get;
            set;
        }
        = Contracts.Modules.Common.LanguageCode.En;
        public System.String Key
        {
            get;
            set;
        }
        public QnSProjectAward.Contracts.Modules.Common.LanguageCode ValueLanguage
        {
            get;
            set;
        }
        = Contracts.Modules.Common.LanguageCode.De;
        public System.String Value
        {
            get;
            set;
        }
        = string.Empty;
        public void CopyProperties(QnSProjectAward.Contracts.Persistence.Language.ITranslation other)
        {
            if (other == null)
            {
                throw new System.ArgumentNullException(nameof(other));
            }
            bool handled = false;
            BeforeCopyProperties(other, ref handled);
            if (handled == false)
            {
                RowVersion = other.RowVersion;
                Id = other.Id;
                AppName = other.AppName;
                KeyLanguage = other.KeyLanguage;
                Key = other.Key;
                ValueLanguage = other.ValueLanguage;
                Value = other.Value;
            }
            AfterCopyProperties(other);
        }
        partial void BeforeCopyProperties(QnSProjectAward.Contracts.Persistence.Language.ITranslation other, ref bool handled);
        partial void AfterCopyProperties(QnSProjectAward.Contracts.Persistence.Language.ITranslation other);
        public static Persistence.Language.Translation Create()
        {
            BeforeCreate();
            var result = new Persistence.Language.Translation();
            AfterCreate(result);
            return result;
        }
        public static Persistence.Language.Translation Create(object other)
        {
            BeforeCreate(other);
            CommonBase.Extensions.ObjectExtensions.CheckArgument(other, nameof(other));
            var result = new Persistence.Language.Translation();
            CommonBase.Extensions.ObjectExtensions.CopyFrom(result, other);
            AfterCreate(result, other);
            return result;
        }
        public static Persistence.Language.Translation Create(QnSProjectAward.Contracts.Persistence.Language.ITranslation other)
        {
            BeforeCreate(other);
            var result = new Persistence.Language.Translation();
            result.CopyProperties(other);
            AfterCreate(result, other);
            return result;
        }
        static partial void BeforeCreate();
        static partial void AfterCreate(Persistence.Language.Translation instance);
        static partial void BeforeCreate(object other);
        static partial void AfterCreate(Persistence.Language.Translation instance, object other);
        static partial void BeforeCreate(QnSProjectAward.Contracts.Persistence.Language.ITranslation other);
        static partial void AfterCreate(Persistence.Language.Translation instance, QnSProjectAward.Contracts.Persistence.Language.ITranslation other);
    }
}