//@QnSGeneratedCode
namespace QnSProjectAward.BlazorApp.Models.Modules.Account
{
    partial class Logon : ModuleModel
    {
    }
}
namespace QnSProjectAward.BlazorApp.Models.Modules.Account
{
    using System;
    public partial class Logon : QnSProjectAward.Contracts.Modules.Account.ILogon
    {
        static Logon()
        {
            ClassConstructing();
            ClassConstructed();
        }
        static partial void ClassConstructing();
        static partial void ClassConstructed();
        public Logon()
        {
            Constructing();
            Constructed();
        }
        partial void Constructing();
        partial void Constructed();
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
        public System.String OptionalInfo
        {
            get;
            set;
        }
        public void CopyProperties(QnSProjectAward.Contracts.Modules.Account.ILogon other)
        {
            if (other == null)
            {
                throw new System.ArgumentNullException(nameof(other));
            }
            bool handled = false;
            BeforeCopyProperties(other, ref handled);
            if (handled == false)
            {
                Email = other.Email;
                Password = other.Password;
                OptionalInfo = other.OptionalInfo;
            }
            AfterCopyProperties(other);
        }
        partial void BeforeCopyProperties(QnSProjectAward.Contracts.Modules.Account.ILogon other, ref bool handled);
        partial void AfterCopyProperties(QnSProjectAward.Contracts.Modules.Account.ILogon other);
        public static Modules.Account.Logon Create()
        {
            BeforeCreate();
            var result = new Modules.Account.Logon();
            AfterCreate(result);
            return result;
        }
        public static Modules.Account.Logon Create(object other)
        {
            BeforeCreate(other);
            CommonBase.Extensions.ObjectExtensions.CheckArgument(other, nameof(other));
            var result = new Modules.Account.Logon();
            CommonBase.Extensions.ObjectExtensions.CopyFrom(result, other);
            AfterCreate(result, other);
            return result;
        }
        public static Modules.Account.Logon Create(QnSProjectAward.Contracts.Modules.Account.ILogon other)
        {
            BeforeCreate(other);
            var result = new Modules.Account.Logon();
            result.CopyProperties(other);
            AfterCreate(result, other);
            return result;
        }
        static partial void BeforeCreate();
        static partial void AfterCreate(Modules.Account.Logon instance);
        static partial void BeforeCreate(object other);
        static partial void AfterCreate(Modules.Account.Logon instance, object other);
        static partial void BeforeCreate(QnSProjectAward.Contracts.Modules.Account.ILogon other);
        static partial void AfterCreate(Modules.Account.Logon instance, QnSProjectAward.Contracts.Modules.Account.ILogon other);
    }
}
namespace QnSProjectAward.BlazorApp.Models.Modules.Account
{
    partial class JsonWebLogon : ModuleModel
    {
    }
}
namespace QnSProjectAward.BlazorApp.Models.Modules.Account
{
    using System;
    public partial class JsonWebLogon : QnSProjectAward.Contracts.Modules.Account.IJsonWebLogon
    {
        static JsonWebLogon()
        {
            ClassConstructing();
            ClassConstructed();
        }
        static partial void ClassConstructing();
        static partial void ClassConstructed();
        public JsonWebLogon()
        {
            Constructing();
            Constructed();
        }
        partial void Constructing();
        partial void Constructed();
        public System.String Token
        {
            get;
            set;
        }
        public void CopyProperties(QnSProjectAward.Contracts.Modules.Account.IJsonWebLogon other)
        {
            if (other == null)
            {
                throw new System.ArgumentNullException(nameof(other));
            }
            bool handled = false;
            BeforeCopyProperties(other, ref handled);
            if (handled == false)
            {
                Token = other.Token;
            }
            AfterCopyProperties(other);
        }
        partial void BeforeCopyProperties(QnSProjectAward.Contracts.Modules.Account.IJsonWebLogon other, ref bool handled);
        partial void AfterCopyProperties(QnSProjectAward.Contracts.Modules.Account.IJsonWebLogon other);
        public static Modules.Account.JsonWebLogon Create()
        {
            BeforeCreate();
            var result = new Modules.Account.JsonWebLogon();
            AfterCreate(result);
            return result;
        }
        public static Modules.Account.JsonWebLogon Create(object other)
        {
            BeforeCreate(other);
            CommonBase.Extensions.ObjectExtensions.CheckArgument(other, nameof(other));
            var result = new Modules.Account.JsonWebLogon();
            CommonBase.Extensions.ObjectExtensions.CopyFrom(result, other);
            AfterCreate(result, other);
            return result;
        }
        public static Modules.Account.JsonWebLogon Create(QnSProjectAward.Contracts.Modules.Account.IJsonWebLogon other)
        {
            BeforeCreate(other);
            var result = new Modules.Account.JsonWebLogon();
            result.CopyProperties(other);
            AfterCreate(result, other);
            return result;
        }
        static partial void BeforeCreate();
        static partial void AfterCreate(Modules.Account.JsonWebLogon instance);
        static partial void BeforeCreate(object other);
        static partial void AfterCreate(Modules.Account.JsonWebLogon instance, object other);
        static partial void BeforeCreate(QnSProjectAward.Contracts.Modules.Account.IJsonWebLogon other);
        static partial void AfterCreate(Modules.Account.JsonWebLogon instance, QnSProjectAward.Contracts.Modules.Account.IJsonWebLogon other);
    }
}
namespace QnSProjectAward.BlazorApp.Models.Modules.Base
{
    partial class Translation : IdentityModel
    {
    }
}
namespace QnSProjectAward.BlazorApp.Models.Modules.Base
{
    using System;
    public partial class Translation : QnSProjectAward.Contracts.Modules.Base.ITranslation
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
        [System.ComponentModel.DataAnnotations.Required]
        [System.ComponentModel.DataAnnotations.StringLength(128)]
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
        [System.ComponentModel.DataAnnotations.Required]
        [System.ComponentModel.DataAnnotations.StringLength(512)]
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
        [System.ComponentModel.DataAnnotations.StringLength(1024)]
        public System.String Value
        {
            get;
            set;
        }
        = string.Empty;
        public void CopyProperties(QnSProjectAward.Contracts.Modules.Base.ITranslation other)
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
                AppName = other.AppName;
                KeyLanguage = other.KeyLanguage;
                Key = other.Key;
                ValueLanguage = other.ValueLanguage;
                Value = other.Value;
            }
            AfterCopyProperties(other);
        }
        partial void BeforeCopyProperties(QnSProjectAward.Contracts.Modules.Base.ITranslation other, ref bool handled);
        partial void AfterCopyProperties(QnSProjectAward.Contracts.Modules.Base.ITranslation other);
        public static Modules.Base.Translation Create()
        {
            BeforeCreate();
            var result = new Modules.Base.Translation();
            AfterCreate(result);
            return result;
        }
        public static Modules.Base.Translation Create(object other)
        {
            BeforeCreate(other);
            CommonBase.Extensions.ObjectExtensions.CheckArgument(other, nameof(other));
            var result = new Modules.Base.Translation();
            CommonBase.Extensions.ObjectExtensions.CopyFrom(result, other);
            AfterCreate(result, other);
            return result;
        }
        public static Modules.Base.Translation Create(QnSProjectAward.Contracts.Modules.Base.ITranslation other)
        {
            BeforeCreate(other);
            var result = new Modules.Base.Translation();
            result.CopyProperties(other);
            AfterCreate(result, other);
            return result;
        }
        static partial void BeforeCreate();
        static partial void AfterCreate(Modules.Base.Translation instance);
        static partial void BeforeCreate(object other);
        static partial void AfterCreate(Modules.Base.Translation instance, object other);
        static partial void BeforeCreate(QnSProjectAward.Contracts.Modules.Base.ITranslation other);
        static partial void AfterCreate(Modules.Base.Translation instance, QnSProjectAward.Contracts.Modules.Base.ITranslation other);
    }
}
namespace QnSProjectAward.BlazorApp.Models.Modules.Base
{
    partial class Setting : IdentityModel
    {
    }
}
namespace QnSProjectAward.BlazorApp.Models.Modules.Base
{
    using System;
    public partial class Setting : QnSProjectAward.Contracts.Modules.Base.ISetting
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
        [System.ComponentModel.DataAnnotations.Required]
        [System.ComponentModel.DataAnnotations.StringLength(128)]
        public System.String AppName
        {
            get;
            set;
        }
        = nameof(QnSProjectAward);
        [System.ComponentModel.DataAnnotations.Required]
        [System.ComponentModel.DataAnnotations.StringLength(512)]
        public System.String Key
        {
            get;
            set;
        }
        [System.ComponentModel.DataAnnotations.StringLength(4096)]
        public System.String Value
        {
            get;
            set;
        }
        = string.Empty;
        public void CopyProperties(QnSProjectAward.Contracts.Modules.Base.ISetting other)
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
                AppName = other.AppName;
                Key = other.Key;
                Value = other.Value;
            }
            AfterCopyProperties(other);
        }
        partial void BeforeCopyProperties(QnSProjectAward.Contracts.Modules.Base.ISetting other, ref bool handled);
        partial void AfterCopyProperties(QnSProjectAward.Contracts.Modules.Base.ISetting other);
        public static Modules.Base.Setting Create()
        {
            BeforeCreate();
            var result = new Modules.Base.Setting();
            AfterCreate(result);
            return result;
        }
        public static Modules.Base.Setting Create(object other)
        {
            BeforeCreate(other);
            CommonBase.Extensions.ObjectExtensions.CheckArgument(other, nameof(other));
            var result = new Modules.Base.Setting();
            CommonBase.Extensions.ObjectExtensions.CopyFrom(result, other);
            AfterCreate(result, other);
            return result;
        }
        public static Modules.Base.Setting Create(QnSProjectAward.Contracts.Modules.Base.ISetting other)
        {
            BeforeCreate(other);
            var result = new Modules.Base.Setting();
            result.CopyProperties(other);
            AfterCreate(result, other);
            return result;
        }
        static partial void BeforeCreate();
        static partial void AfterCreate(Modules.Base.Setting instance);
        static partial void BeforeCreate(object other);
        static partial void AfterCreate(Modules.Base.Setting instance, object other);
        static partial void BeforeCreate(QnSProjectAward.Contracts.Modules.Base.ISetting other);
        static partial void AfterCreate(Modules.Base.Setting instance, QnSProjectAward.Contracts.Modules.Base.ISetting other);
    }
}
namespace QnSProjectAward.BlazorApp.Models.Modules.Base
{
    partial class IdentitySetting : IdentityModel
    {
    }
}
namespace QnSProjectAward.BlazorApp.Models.Modules.Base
{
    using System;
    public partial class IdentitySetting : QnSProjectAward.Contracts.Modules.Base.IIdentitySetting
    {
        static IdentitySetting()
        {
            ClassConstructing();
            ClassConstructed();
        }
        static partial void ClassConstructing();
        static partial void ClassConstructed();
        public IdentitySetting()
        {
            Constructing();
            Constructed();
        }
        partial void Constructing();
        partial void Constructed();
        [System.ComponentModel.DataAnnotations.Required]
        public System.Int32 IdentityId
        {
            get;
            set;
        }
        [System.ComponentModel.DataAnnotations.Required]
        [System.ComponentModel.DataAnnotations.StringLength(128)]
        public System.String AppName
        {
            get;
            set;
        }
        = nameof(QnSProjectAward);
        [System.ComponentModel.DataAnnotations.Required]
        [System.ComponentModel.DataAnnotations.StringLength(512)]
        public System.String Key
        {
            get;
            set;
        }
        [System.ComponentModel.DataAnnotations.StringLength(4096)]
        public System.String Value
        {
            get;
            set;
        }
        = string.Empty;
        public void CopyProperties(QnSProjectAward.Contracts.Modules.Base.IIdentitySetting other)
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
                IdentityId = other.IdentityId;
                AppName = other.AppName;
                Key = other.Key;
                Value = other.Value;
            }
            AfterCopyProperties(other);
        }
        partial void BeforeCopyProperties(QnSProjectAward.Contracts.Modules.Base.IIdentitySetting other, ref bool handled);
        partial void AfterCopyProperties(QnSProjectAward.Contracts.Modules.Base.IIdentitySetting other);
        public static Modules.Base.IdentitySetting Create()
        {
            BeforeCreate();
            var result = new Modules.Base.IdentitySetting();
            AfterCreate(result);
            return result;
        }
        public static Modules.Base.IdentitySetting Create(object other)
        {
            BeforeCreate(other);
            CommonBase.Extensions.ObjectExtensions.CheckArgument(other, nameof(other));
            var result = new Modules.Base.IdentitySetting();
            CommonBase.Extensions.ObjectExtensions.CopyFrom(result, other);
            AfterCreate(result, other);
            return result;
        }
        public static Modules.Base.IdentitySetting Create(QnSProjectAward.Contracts.Modules.Base.IIdentitySetting other)
        {
            BeforeCreate(other);
            var result = new Modules.Base.IdentitySetting();
            result.CopyProperties(other);
            AfterCreate(result, other);
            return result;
        }
        static partial void BeforeCreate();
        static partial void AfterCreate(Modules.Base.IdentitySetting instance);
        static partial void BeforeCreate(object other);
        static partial void AfterCreate(Modules.Base.IdentitySetting instance, object other);
        static partial void BeforeCreate(QnSProjectAward.Contracts.Modules.Base.IIdentitySetting other);
        static partial void AfterCreate(Modules.Base.IdentitySetting instance, QnSProjectAward.Contracts.Modules.Base.IIdentitySetting other);
    }
}
namespace QnSProjectAward.BlazorApp.Models.Modules.Language
{
    partial class Translation : IdentityModel
    {
    }
}
namespace QnSProjectAward.BlazorApp.Models.Modules.Language
{
    using System;
    public partial class Translation : QnSProjectAward.Contracts.Modules.Language.ITranslation
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
        [System.ComponentModel.DataAnnotations.Required]
        [System.ComponentModel.DataAnnotations.StringLength(128)]
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
        [System.ComponentModel.DataAnnotations.Required]
        [System.ComponentModel.DataAnnotations.StringLength(512)]
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
        [System.ComponentModel.DataAnnotations.StringLength(1024)]
        public System.String Value
        {
            get;
            set;
        }
        = string.Empty;
        public void CopyProperties(QnSProjectAward.Contracts.Modules.Language.ITranslation other)
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
                AppName = other.AppName;
                KeyLanguage = other.KeyLanguage;
                Key = other.Key;
                ValueLanguage = other.ValueLanguage;
                Value = other.Value;
            }
            AfterCopyProperties(other);
        }
        partial void BeforeCopyProperties(QnSProjectAward.Contracts.Modules.Language.ITranslation other, ref bool handled);
        partial void AfterCopyProperties(QnSProjectAward.Contracts.Modules.Language.ITranslation other);
        public static Modules.Language.Translation Create()
        {
            BeforeCreate();
            var result = new Modules.Language.Translation();
            AfterCreate(result);
            return result;
        }
        public static Modules.Language.Translation Create(object other)
        {
            BeforeCreate(other);
            CommonBase.Extensions.ObjectExtensions.CheckArgument(other, nameof(other));
            var result = new Modules.Language.Translation();
            CommonBase.Extensions.ObjectExtensions.CopyFrom(result, other);
            AfterCreate(result, other);
            return result;
        }
        public static Modules.Language.Translation Create(QnSProjectAward.Contracts.Modules.Language.ITranslation other)
        {
            BeforeCreate(other);
            var result = new Modules.Language.Translation();
            result.CopyProperties(other);
            AfterCreate(result, other);
            return result;
        }
        static partial void BeforeCreate();
        static partial void AfterCreate(Modules.Language.Translation instance);
        static partial void BeforeCreate(object other);
        static partial void AfterCreate(Modules.Language.Translation instance, object other);
        static partial void BeforeCreate(QnSProjectAward.Contracts.Modules.Language.ITranslation other);
        static partial void AfterCreate(Modules.Language.Translation instance, QnSProjectAward.Contracts.Modules.Language.ITranslation other);
    }
}
