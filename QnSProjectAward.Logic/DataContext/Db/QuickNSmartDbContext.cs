//@QnSCodeCopy
//MdStart
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Logging;
using QnSProjectAward.Logic.Entities.Persistence.Account;
using System.Linq;

namespace QnSProjectAward.Logic.DataContext.Db
{
    internal partial class QnSProjectAwardDbContext
    {
        static QnSProjectAwardDbContext()
        {
            ClassConstructing();
            ConnectionString = Modules.Configuration.AppSettings.Get(CommonBase.StaticLiterals.ConnectionString);
            ClassConstructed();
        }
        static partial void ClassConstructing();
        static partial void ClassConstructed();

#if DEBUG
        public static readonly ILoggerFactory loggerFactory = LoggerFactory.Create(builder =>
        {
            //builder
            //    .AddFilter((category, level) =>
            //        category == DbLoggerCategory.Database.Command.Name
            //        && level == LogLevel.Information)
            //    .AddDebug();
        });
#endif
        private static string ConnectionString { get; set; }

        public QnSProjectAwardDbContext()
        {
            Constructing();
            Constructed();
        }
        partial void Constructing();
        partial void Constructed();

        #region Configuration
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            var handled = false;

            BeforeOnConfiguring(optionsBuilder, ref handled);
            if (handled == false)
            {
                optionsBuilder
#if DEBUG
                .EnableSensitiveDataLogging()
                    .UseLoggerFactory(loggerFactory)
#endif
                .UseSqlServer(ConnectionString);
            }
            AfterOnConfiguring(optionsBuilder);
        }
        partial void BeforeOnConfiguring(DbContextOptionsBuilder optionsBuilder, ref bool handled);
        partial void AfterOnConfiguring(DbContextOptionsBuilder optionsBuilder);
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var handled = false;

            BeforeOnModelCreating(modelBuilder, ref handled);
            if (handled == false)
			{
                DoModelCreating(modelBuilder);
            }
            AfterOnModelCreating(modelBuilder);

            var cascadeFKs = modelBuilder.Model.GetEntityTypes()
                .SelectMany(t => t.GetForeignKeys())
                .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);

            foreach (var fk in cascadeFKs)
                fk.DeleteBehavior = DeleteBehavior.Restrict;

            base.OnModelCreating(modelBuilder);
        }
        static partial void BeforeOnModelCreating(ModelBuilder modelBuilder, ref bool handled);
        static partial void DoModelCreating(ModelBuilder modelBuilder);
        static partial void AfterOnModelCreating(ModelBuilder modelBuilder);

        static partial void ConfigureEntityType(EntityTypeBuilder<Identity> entityTypeBuilder)
        {
            entityTypeBuilder
                .Property(p => p.PasswordHash)
                .HasMaxLength(512)
                .IsRequired();
            entityTypeBuilder
                .Property(p => p.PasswordSalt)
                .HasMaxLength(512)
                .IsRequired();
        }
        #endregion Configuration
    }
}
//MdEnd
