//@QnSGeneratedCode
namespace QnSProjectAward.Logic.DataContext.Db
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    partial class QnSProjectAwardDbContext : GenericDbContext
    {
        protected DbSet<Entities.Persistence.Language.Translation> TranslationSet
        {
            get;
            set;
        }
        protected DbSet<Entities.Persistence.Data.BinaryData> BinaryDataSet
        {
            get;
            set;
        }
        protected DbSet<Entities.Persistence.Configuration.IdentitySetting> IdentitySettingSet
        {
            get;
            set;
        }
        protected DbSet<Entities.Persistence.Configuration.Setting> SettingSet
        {
            get;
            set;
        }
        protected DbSet<Entities.Persistence.App.Award> AwardSet
        {
            get;
            set;
        }
        protected DbSet<Entities.Persistence.App.Juror> JurorSet
        {
            get;
            set;
        }
        protected DbSet<Entities.Persistence.App.Member> MemberSet
        {
            get;
            set;
        }
        protected DbSet<Entities.Persistence.App.Project> ProjectSet
        {
            get;
            set;
        }
        protected DbSet<Entities.Persistence.App.Rating> RatingSet
        {
            get;
            set;
        }
        protected DbSet<Entities.Persistence.Account.ActionLog> ActionLogSet
        {
            get;
            set;
        }
        protected DbSet<Entities.Persistence.Account.Identity> IdentitySet
        {
            get;
            set;
        }
        protected DbSet<Entities.Persistence.Account.IdentityXRole> IdentityXRoleSet
        {
            get;
            set;
        }
        protected DbSet<Entities.Persistence.Account.LoginSession> LoginSessionSet
        {
            get;
            set;
        }
        protected DbSet<Entities.Persistence.Account.Role> RoleSet
        {
            get;
            set;
        }
        protected DbSet<Entities.Persistence.Account.User> UserSet
        {
            get;
            set;
        }
        public override DbSet<E> Set<I, E>()
        {
            DbSet<E> result = null;
            if (typeof(I) == typeof(QnSProjectAward.Contracts.Persistence.Language.ITranslation))
            {
                result = TranslationSet as DbSet<E>;
            }
            else if (typeof(I) == typeof(QnSProjectAward.Contracts.Persistence.Data.IBinaryData))
            {
                result = BinaryDataSet as DbSet<E>;
            }
            else if (typeof(I) == typeof(QnSProjectAward.Contracts.Persistence.Configuration.IIdentitySetting))
            {
                result = IdentitySettingSet as DbSet<E>;
            }
            else if (typeof(I) == typeof(QnSProjectAward.Contracts.Persistence.Configuration.ISetting))
            {
                result = SettingSet as DbSet<E>;
            }
            else if (typeof(I) == typeof(QnSProjectAward.Contracts.Persistence.App.IAward))
            {
                result = AwardSet as DbSet<E>;
            }
            else if (typeof(I) == typeof(QnSProjectAward.Contracts.Persistence.App.IJuror))
            {
                result = JurorSet as DbSet<E>;
            }
            else if (typeof(I) == typeof(QnSProjectAward.Contracts.Persistence.App.IMember))
            {
                result = MemberSet as DbSet<E>;
            }
            else if (typeof(I) == typeof(QnSProjectAward.Contracts.Persistence.App.IProject))
            {
                result = ProjectSet as DbSet<E>;
            }
            else if (typeof(I) == typeof(QnSProjectAward.Contracts.Persistence.App.IRating))
            {
                result = RatingSet as DbSet<E>;
            }
            else if (typeof(I) == typeof(QnSProjectAward.Contracts.Persistence.Account.IActionLog))
            {
                result = ActionLogSet as DbSet<E>;
            }
            else if (typeof(I) == typeof(QnSProjectAward.Contracts.Persistence.Account.IIdentity))
            {
                result = IdentitySet as DbSet<E>;
            }
            else if (typeof(I) == typeof(QnSProjectAward.Contracts.Persistence.Account.IIdentityXRole))
            {
                result = IdentityXRoleSet as DbSet<E>;
            }
            else if (typeof(I) == typeof(QnSProjectAward.Contracts.Persistence.Account.ILoginSession))
            {
                result = LoginSessionSet as DbSet<E>;
            }
            else if (typeof(I) == typeof(QnSProjectAward.Contracts.Persistence.Account.IRole))
            {
                result = RoleSet as DbSet<E>;
            }
            else if (typeof(I) == typeof(QnSProjectAward.Contracts.Persistence.Account.IUser))
            {
                result = UserSet as DbSet<E>;
            }
            return result;
        }
        static partial void DoModelCreating(ModelBuilder modelBuilder)
        {
            var translationBuilder = modelBuilder.Entity<Entities.Persistence.Language.Translation>();
            translationBuilder.ToTable("Translation", "Language").HasKey("Id");
            modelBuilder.Entity<Entities.Persistence.Language.Translation>().Property(p => p.RowVersion).IsRowVersion();
            translationBuilder.Property(p => p.AppName).IsRequired().HasMaxLength(128);
            translationBuilder.Property(p => p.Key).IsRequired().HasMaxLength(512);
            translationBuilder.Property(p => p.Value).HasMaxLength(1024);
            translationBuilder.HasIndex(c => new
            {
                c.AppName, c.KeyLanguage, c.Key
            }
            ).IsUnique();
            ConfigureEntityType(translationBuilder);
            var binaryDataBuilder = modelBuilder.Entity<Entities.Persistence.Data.BinaryData>();
            binaryDataBuilder.ToTable("BinaryData", "Data").HasKey("Id");
            modelBuilder.Entity<Entities.Persistence.Data.BinaryData>().Property(p => p.RowVersion).IsRowVersion();
            binaryDataBuilder.HasIndex(c => c.Guid).IsUnique();
            binaryDataBuilder.Property(p => p.Guid).IsRequired();
            binaryDataBuilder.Property(p => p.Data).IsRequired();
            ConfigureEntityType(binaryDataBuilder);
            var identitySettingBuilder = modelBuilder.Entity<Entities.Persistence.Configuration.IdentitySetting>();
            identitySettingBuilder.ToTable("IdentitySetting", "Configuration").HasKey("Id");
            modelBuilder.Entity<Entities.Persistence.Configuration.IdentitySetting>().Property(p => p.RowVersion).IsRowVersion();
            identitySettingBuilder.Property(p => p.IdentityId).IsRequired();
            identitySettingBuilder.Property(p => p.AppName).IsRequired().HasMaxLength(128);
            identitySettingBuilder.Property(p => p.Key).IsRequired().HasMaxLength(512);
            identitySettingBuilder.Property(p => p.Value).HasMaxLength(4096);
            identitySettingBuilder.HasIndex(c => new
            {
                c.IdentityId, c.AppName, c.Key
            }
            ).IsUnique();
            ConfigureEntityType(identitySettingBuilder);
            var settingBuilder = modelBuilder.Entity<Entities.Persistence.Configuration.Setting>();
            settingBuilder.ToTable("Setting", "Configuration").HasKey("Id");
            modelBuilder.Entity<Entities.Persistence.Configuration.Setting>().Property(p => p.RowVersion).IsRowVersion();
            settingBuilder.Property(p => p.AppName).IsRequired().HasMaxLength(128);
            settingBuilder.Property(p => p.Key).IsRequired().HasMaxLength(512);
            settingBuilder.Property(p => p.Value).HasMaxLength(4096);
            settingBuilder.HasIndex(c => new
            {
                c.AppName, c.Key
            }
            ).IsUnique();
            ConfigureEntityType(settingBuilder);
            var awardBuilder = modelBuilder.Entity<Entities.Persistence.App.Award>();
            awardBuilder.ToTable("Award", "App").HasKey("Id");
            modelBuilder.Entity<Entities.Persistence.App.Award>().Property(p => p.RowVersion).IsRowVersion();
            awardBuilder.Property(p => p.Title).IsRequired().HasMaxLength(256);
            awardBuilder.Property(p => p.Location).IsRequired().HasMaxLength(256);
            ConfigureEntityType(awardBuilder);
            var jurorBuilder = modelBuilder.Entity<Entities.Persistence.App.Juror>();
            jurorBuilder.ToTable("Juror", "App").HasKey("Id");
            modelBuilder.Entity<Entities.Persistence.App.Juror>().Property(p => p.RowVersion).IsRowVersion();
            jurorBuilder.Property(p => p.Name).IsRequired().HasMaxLength(256);
            jurorBuilder.Property(p => p.Position).HasMaxLength(128);
            jurorBuilder.Property(p => p.Institution).HasMaxLength(256);
            jurorBuilder.Property(p => p.Email).IsRequired().HasMaxLength(128);
            ConfigureEntityType(jurorBuilder);
            var memberBuilder = modelBuilder.Entity<Entities.Persistence.App.Member>();
            memberBuilder.ToTable("Member", "App").HasKey("Id");
            modelBuilder.Entity<Entities.Persistence.App.Member>().Property(p => p.RowVersion).IsRowVersion();
            memberBuilder.Property(p => p.Name).IsRequired().HasMaxLength(256);
            memberBuilder.Property(p => p.Course).IsRequired().HasMaxLength(20);
            memberBuilder.Property(p => p.Email).IsRequired().HasMaxLength(128);
            memberBuilder.Property(p => p.Phone).HasMaxLength(64);
            memberBuilder.Property(p => p.Role).IsRequired().HasMaxLength(128);
            ConfigureEntityType(memberBuilder);
            var projectBuilder = modelBuilder.Entity<Entities.Persistence.App.Project>();
            projectBuilder.ToTable("Project", "App").HasKey("Id");
            modelBuilder.Entity<Entities.Persistence.App.Project>().Property(p => p.RowVersion).IsRowVersion();
            projectBuilder.Property(p => p.School).IsRequired().HasMaxLength(128);
            projectBuilder.Property(p => p.Title).IsRequired().HasMaxLength(256);
            projectBuilder.Property(p => p.Description).IsRequired().HasMaxLength(2048);
            ConfigureEntityType(projectBuilder);
            var ratingBuilder = modelBuilder.Entity<Entities.Persistence.App.Rating>();
            ratingBuilder.ToTable("Rating", "App").HasKey("Id");
            modelBuilder.Entity<Entities.Persistence.App.Rating>().Property(p => p.RowVersion).IsRowVersion();
            ConfigureEntityType(ratingBuilder);
            var actionLogBuilder = modelBuilder.Entity<Entities.Persistence.Account.ActionLog>();
            actionLogBuilder.ToTable("ActionLog", "Account").HasKey("Id");
            modelBuilder.Entity<Entities.Persistence.Account.ActionLog>().Property(p => p.RowVersion).IsRowVersion();
            ConfigureEntityType(actionLogBuilder);
            var identityBuilder = modelBuilder.Entity<Entities.Persistence.Account.Identity>();
            identityBuilder.ToTable("Identity", "Account").HasKey("Id");
            modelBuilder.Entity<Entities.Persistence.Account.Identity>().Property(p => p.RowVersion).IsRowVersion();
            identityBuilder.Property(p => p.Guid).IsRequired().HasMaxLength(36);
            identityBuilder.HasIndex(c => c.Name).IsUnique();
            identityBuilder.Property(p => p.Name).IsRequired().HasMaxLength(128);
            identityBuilder.HasIndex(c => c.Email).IsUnique();
            identityBuilder.Property(p => p.Email).IsRequired().HasMaxLength(128);
            identityBuilder.Ignore(c => c.Password);
            ConfigureEntityType(identityBuilder);
            var identityXRoleBuilder = modelBuilder.Entity<Entities.Persistence.Account.IdentityXRole>();
            identityXRoleBuilder.ToTable("IdentityXRole", "Account").HasKey("Id");
            modelBuilder.Entity<Entities.Persistence.Account.IdentityXRole>().Property(p => p.RowVersion).IsRowVersion();
            ConfigureEntityType(identityXRoleBuilder);
            var loginSessionBuilder = modelBuilder.Entity<Entities.Persistence.Account.LoginSession>();
            loginSessionBuilder.ToTable("LoginSession", "Account").HasKey("Id");
            modelBuilder.Entity<Entities.Persistence.Account.LoginSession>().Property(p => p.RowVersion).IsRowVersion();
            loginSessionBuilder.Ignore(c => c.IsRemoteAuth);
            loginSessionBuilder.Ignore(c => c.Origin);
            loginSessionBuilder.Ignore(c => c.Name);
            loginSessionBuilder.Ignore(c => c.Email);
            loginSessionBuilder.Ignore(c => c.TimeOutInMinutes);
            loginSessionBuilder.Ignore(c => c.JsonWebToken);
            loginSessionBuilder.Property(p => p.SessionToken).IsRequired().HasMaxLength(128);
            loginSessionBuilder.Property(p => p.OptionalInfo).HasMaxLength(4096);
            ConfigureEntityType(loginSessionBuilder);
            var roleBuilder = modelBuilder.Entity<Entities.Persistence.Account.Role>();
            roleBuilder.ToTable("Role", "Account").HasKey("Id");
            modelBuilder.Entity<Entities.Persistence.Account.Role>().Property(p => p.RowVersion).IsRowVersion();
            roleBuilder.HasIndex(c => c.Designation).IsUnique();
            roleBuilder.Property(p => p.Designation).IsRequired().HasMaxLength(64);
            roleBuilder.Property(p => p.Description).HasMaxLength(256);
            ConfigureEntityType(roleBuilder);
            var userBuilder = modelBuilder.Entity<Entities.Persistence.Account.User>();
            userBuilder.ToTable("User", "Account").HasKey("Id");
            modelBuilder.Entity<Entities.Persistence.Account.User>().Property(p => p.RowVersion).IsRowVersion();
            userBuilder.HasIndex(c => c.IdentityId).IsUnique();
            userBuilder.Property(p => p.Firstname).HasMaxLength(64);
            userBuilder.Property(p => p.Lastname).HasMaxLength(64);
            ConfigureEntityType(userBuilder);
        }
        static partial void ConfigureEntityType(EntityTypeBuilder<Entities.Persistence.Language.Translation> entityTypeBuilder);
        static partial void ConfigureEntityType(EntityTypeBuilder<Entities.Persistence.Data.BinaryData> entityTypeBuilder);
        static partial void ConfigureEntityType(EntityTypeBuilder<Entities.Persistence.Configuration.IdentitySetting> entityTypeBuilder);
        static partial void ConfigureEntityType(EntityTypeBuilder<Entities.Persistence.Configuration.Setting> entityTypeBuilder);
        static partial void ConfigureEntityType(EntityTypeBuilder<Entities.Persistence.App.Award> entityTypeBuilder);
        static partial void ConfigureEntityType(EntityTypeBuilder<Entities.Persistence.App.Juror> entityTypeBuilder);
        static partial void ConfigureEntityType(EntityTypeBuilder<Entities.Persistence.App.Member> entityTypeBuilder);
        static partial void ConfigureEntityType(EntityTypeBuilder<Entities.Persistence.App.Project> entityTypeBuilder);
        static partial void ConfigureEntityType(EntityTypeBuilder<Entities.Persistence.App.Rating> entityTypeBuilder);
        static partial void ConfigureEntityType(EntityTypeBuilder<Entities.Persistence.Account.ActionLog> entityTypeBuilder);
        static partial void ConfigureEntityType(EntityTypeBuilder<Entities.Persistence.Account.Identity> entityTypeBuilder);
        static partial void ConfigureEntityType(EntityTypeBuilder<Entities.Persistence.Account.IdentityXRole> entityTypeBuilder);
        static partial void ConfigureEntityType(EntityTypeBuilder<Entities.Persistence.Account.LoginSession> entityTypeBuilder);
        static partial void ConfigureEntityType(EntityTypeBuilder<Entities.Persistence.Account.Role> entityTypeBuilder);
        static partial void ConfigureEntityType(EntityTypeBuilder<Entities.Persistence.Account.User> entityTypeBuilder);
    }
}
