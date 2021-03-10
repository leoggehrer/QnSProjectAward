//@QnSGeneratedCode
namespace QnSProjectAward.AspMvc.Models.Business.Account
{
    partial class IdentityUser : OneToAnotherModel<QnSProjectAward.Contracts.Persistence.Account.IIdentity, QnSProjectAward.AspMvc.Models.Persistence.Account.Identity, QnSProjectAward.Contracts.Persistence.Account.IUser, QnSProjectAward.AspMvc.Models.Persistence.Account.User>
    {
    }
}
namespace QnSProjectAward.AspMvc.Models.Business.Account
{
    using System;
    public partial class IdentityUser : QnSProjectAward.Contracts.Business.Account.IIdentityUser
    {
        static IdentityUser()
        {
            ClassConstructing();
            ClassConstructed();
        }
        static partial void ClassConstructing();
        static partial void ClassConstructed();
        public IdentityUser()
        {
            Constructing();
            Constructed();
        }
        partial void Constructing();
        partial void Constructed();
        public void CopyProperties(QnSProjectAward.Contracts.Business.Account.IIdentityUser other)
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
                OneItem.CopyProperties(other.OneItem);
                AnotherItem.CopyProperties(other.AnotherItem);
            }
            AfterCopyProperties(other);
        }
        partial void BeforeCopyProperties(QnSProjectAward.Contracts.Business.Account.IIdentityUser other, ref bool handled);
        partial void AfterCopyProperties(QnSProjectAward.Contracts.Business.Account.IIdentityUser other);
        public static Business.Account.IdentityUser Create()
        {
            BeforeCreate();
            var result = new Business.Account.IdentityUser();
            AfterCreate(result);
            return result;
        }
        public static Business.Account.IdentityUser Create(object other)
        {
            BeforeCreate(other);
            CommonBase.Extensions.ObjectExtensions.CheckArgument(other, nameof(other));
            var result = new Business.Account.IdentityUser();
            CommonBase.Extensions.ObjectExtensions.CopyFrom(result, other);
            AfterCreate(result, other);
            return result;
        }
        public static Business.Account.IdentityUser Create(QnSProjectAward.Contracts.Business.Account.IIdentityUser other)
        {
            BeforeCreate(other);
            var result = new Business.Account.IdentityUser();
            result.CopyProperties(other);
            AfterCreate(result, other);
            return result;
        }
        static partial void BeforeCreate();
        static partial void AfterCreate(Business.Account.IdentityUser instance);
        static partial void BeforeCreate(object other);
        static partial void AfterCreate(Business.Account.IdentityUser instance, object other);
        static partial void BeforeCreate(QnSProjectAward.Contracts.Business.Account.IIdentityUser other);
        static partial void AfterCreate(Business.Account.IdentityUser instance, QnSProjectAward.Contracts.Business.Account.IIdentityUser other);
    }
}
namespace QnSProjectAward.AspMvc.Models.Business.Account
{
    partial class AppAccess : OneToManyModel<QnSProjectAward.Contracts.Persistence.Account.IIdentity, QnSProjectAward.AspMvc.Models.Persistence.Account.Identity, QnSProjectAward.Contracts.Persistence.Account.IRole, QnSProjectAward.AspMvc.Models.Persistence.Account.Role>
    {
    }
}
namespace QnSProjectAward.AspMvc.Models.Business.Account
{
    using System;
    public partial class AppAccess
    {
        public System.String Guid
        {
            get => OneModel.Guid;
        }
        public System.String Name
        {
            get => OneModel.Name;
            set => OneModel.Name = value;
        }
        public System.String Email
        {
            get => OneModel.Email;
            set => OneModel.Email = value;
        }
        public System.String Password
        {
            get => OneModel.Password;
            set => OneModel.Password = value;
        }
        public System.Int32 TimeOutInMinutes
        {
            get => OneModel.TimeOutInMinutes;
            set => OneModel.TimeOutInMinutes = value;
        }
        public System.Boolean EnableJwtAuth
        {
            get => OneModel.EnableJwtAuth;
            set => OneModel.EnableJwtAuth = value;
        }
        public System.Int32 AccessFailedCount
        {
            get => OneModel.AccessFailedCount;
            set => OneModel.AccessFailedCount = value;
        }
        public QnSProjectAward.Contracts.Modules.Common.State State
        {
            get => OneModel.State;
            set => OneModel.State = value;
        }
    }
}
namespace QnSProjectAward.AspMvc.Models.Business.Account
{
    using System;
    public partial class AppAccess : QnSProjectAward.Contracts.Business.Account.IAppAccess
    {
        static AppAccess()
        {
            ClassConstructing();
            ClassConstructed();
        }
        static partial void ClassConstructing();
        static partial void ClassConstructed();
        public AppAccess()
        {
            Constructing();
            Constructed();
        }
        partial void Constructing();
        partial void Constructed();
        public void CopyProperties(QnSProjectAward.Contracts.Business.Account.IAppAccess other)
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
                OneItem.CopyProperties(other.OneItem);
                ClearManyItems();
                foreach (var item in other.ManyItems)
                {
                    AddManyItem(item);
                }
            }
            AfterCopyProperties(other);
        }
        partial void BeforeCopyProperties(QnSProjectAward.Contracts.Business.Account.IAppAccess other, ref bool handled);
        partial void AfterCopyProperties(QnSProjectAward.Contracts.Business.Account.IAppAccess other);
        public static Business.Account.AppAccess Create()
        {
            BeforeCreate();
            var result = new Business.Account.AppAccess();
            AfterCreate(result);
            return result;
        }
        public static Business.Account.AppAccess Create(object other)
        {
            BeforeCreate(other);
            CommonBase.Extensions.ObjectExtensions.CheckArgument(other, nameof(other));
            var result = new Business.Account.AppAccess();
            CommonBase.Extensions.ObjectExtensions.CopyFrom(result, other);
            AfterCreate(result, other);
            return result;
        }
        public static Business.Account.AppAccess Create(QnSProjectAward.Contracts.Business.Account.IAppAccess other)
        {
            BeforeCreate(other);
            var result = new Business.Account.AppAccess();
            result.CopyProperties(other);
            AfterCreate(result, other);
            return result;
        }
        static partial void BeforeCreate();
        static partial void AfterCreate(Business.Account.AppAccess instance);
        static partial void BeforeCreate(object other);
        static partial void AfterCreate(Business.Account.AppAccess instance, object other);
        static partial void BeforeCreate(QnSProjectAward.Contracts.Business.Account.IAppAccess other);
        static partial void AfterCreate(Business.Account.AppAccess instance, QnSProjectAward.Contracts.Business.Account.IAppAccess other);
    }
}
