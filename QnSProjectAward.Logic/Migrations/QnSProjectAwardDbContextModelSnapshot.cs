// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using QnSProjectAward.Logic.DataContext.Db;

namespace QnSProjectAward.Logic.Migrations
{
    [DbContext(typeof(QnSProjectAwardDbContext))]
    partial class QnSProjectAwardDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("QnSProjectAward.Logic.Entities.Persistence.Account.ActionLog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Action")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdentityId")
                        .HasColumnType("int");

                    b.Property<string>("Info")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.Property<string>("Subject")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Time")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("IdentityId");

                    b.ToTable("ActionLog", "Account");
                });

            modelBuilder.Entity("QnSProjectAward.Logic.Entities.Persistence.Account.Identity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<bool>("EnableJwtAuth")
                        .HasColumnType("bit");

                    b.Property<string>("Guid")
                        .IsRequired()
                        .HasMaxLength(36)
                        .HasColumnType("nvarchar(36)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasMaxLength(512)
                        .HasColumnType("varbinary(512)");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasMaxLength(512)
                        .HasColumnType("varbinary(512)");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.Property<int>("State")
                        .HasColumnType("int");

                    b.Property<int>("TimeOutInMinutes")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Identity", "Account");
                });

            modelBuilder.Entity("QnSProjectAward.Logic.Entities.Persistence.Account.IdentityXRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("IdentityId")
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.HasKey("Id");

                    b.HasIndex("IdentityId");

                    b.HasIndex("RoleId");

                    b.ToTable("IdentityXRole", "Account");
                });

            modelBuilder.Entity("QnSProjectAward.Logic.Entities.Persistence.Account.LoginSession", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("IdentityId")
                        .HasColumnType("int");

                    b.Property<DateTime>("LastAccess")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("LoginTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("LogoutTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("OptionalInfo")
                        .HasMaxLength(4096)
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.Property<string>("SessionToken")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.HasKey("Id");

                    b.HasIndex("IdentityId");

                    b.ToTable("LoginSession", "Account");
                });

            modelBuilder.Entity("QnSProjectAward.Logic.Entities.Persistence.Account.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Description")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("Designation")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.HasKey("Id");

                    b.HasIndex("Designation")
                        .IsUnique();

                    b.ToTable("Role", "Account");
                });

            modelBuilder.Entity("QnSProjectAward.Logic.Entities.Persistence.Account.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Firstname")
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<int>("IdentityId")
                        .HasColumnType("int");

                    b.Property<string>("Lastname")
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.HasKey("Id");

                    b.HasIndex("IdentityId")
                        .IsUnique();

                    b.ToTable("User", "Account");
                });

            modelBuilder.Entity("QnSProjectAward.Logic.Entities.Persistence.Configuration.Setting", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("AppName")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Key")
                        .IsRequired()
                        .HasMaxLength(512)
                        .HasColumnType("nvarchar(512)");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.Property<string>("Value")
                        .HasMaxLength(4096)
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AppName", "Key")
                        .IsUnique();

                    b.ToTable("Setting", "Configuration");
                });

            modelBuilder.Entity("QnSProjectAward.Logic.Entities.Persistence.Data.BinaryData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<byte[]>("Data")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<Guid>("Guid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.HasKey("Id");

                    b.HasIndex("Guid")
                        .IsUnique();

                    b.ToTable("BinaryData", "Data");
                });

            modelBuilder.Entity("QnSProjectAward.Logic.Entities.Persistence.Language.Translation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("AppName")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Key")
                        .IsRequired()
                        .HasMaxLength(512)
                        .HasColumnType("nvarchar(512)");

                    b.Property<int>("KeyLanguage")
                        .HasColumnType("int");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.Property<string>("Value")
                        .HasMaxLength(1024)
                        .HasColumnType("nvarchar(1024)");

                    b.Property<int>("ValueLanguage")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AppName", "KeyLanguage", "Key")
                        .IsUnique();

                    b.ToTable("Translation", "Language");
                });

            modelBuilder.Entity("QnSProjectAward.Logic.Entities.Persistence.MusicStoreApp.Album", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("ArtistId")
                        .HasColumnType("int");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.Property<int>("State")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(1024)
                        .HasColumnType("nvarchar(1024)");

                    b.HasKey("Id");

                    b.HasIndex("ArtistId");

                    b.HasIndex("Title")
                        .IsUnique();

                    b.ToTable("Album", "MusicStoreApp");
                });

            modelBuilder.Entity("QnSProjectAward.Logic.Entities.Persistence.MusicStoreApp.Artist", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(512)
                        .HasColumnType("nvarchar(512)");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.Property<int>("State")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Artist", "MusicStoreApp");
                });

            modelBuilder.Entity("QnSProjectAward.Logic.Entities.Persistence.MusicStoreApp.Genre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.Property<int>("State")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Genre", "MusicStoreApp");
                });

            modelBuilder.Entity("QnSProjectAward.Logic.Entities.Persistence.MusicStoreApp.Track", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("AlbumId")
                        .HasColumnType("int");

                    b.Property<long>("Bytes")
                        .HasColumnType("bigint");

                    b.Property<string>("Composer")
                        .HasMaxLength(512)
                        .HasColumnType("nvarchar(512)");

                    b.Property<int>("GenreId")
                        .HasColumnType("int");

                    b.Property<long>("Milliseconds")
                        .HasColumnType("bigint");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.Property<int>("State")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(1024)
                        .HasColumnType("nvarchar(1024)");

                    b.Property<double>("UnitPrice")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("AlbumId");

                    b.HasIndex("GenreId");

                    b.HasIndex("Title");

                    b.ToTable("Track", "MusicStoreApp");
                });

            modelBuilder.Entity("QnSProjectAward.Logic.Entities.Persistence.MusicStoreApp.ViewFullTrack", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("AlbumId")
                        .HasColumnType("int");

                    b.Property<string>("AlbumTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("Bytes")
                        .HasColumnType("bigint");

                    b.Property<string>("Composer")
                        .IsRequired()
                        .HasMaxLength(512)
                        .HasColumnType("nvarchar(512)");

                    b.Property<int>("GenreId")
                        .HasColumnType("int");

                    b.Property<string>("GenreName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("Milliseconds")
                        .HasColumnType("bigint");

                    b.Property<byte[]>("RowVersion")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(1024)
                        .HasColumnType("nvarchar(1024)");

                    b.Property<double>("UnitPrice")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("AlbumId");

                    b.HasIndex("GenreId");

                    b.HasIndex("Title");

                    b.ToView("qryFullTrack", "dbo");
                });

            modelBuilder.Entity("QnSProjectAward.Logic.Entities.Persistence.MusicStoreApp.ViewTrack", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("GenreId")
                        .HasColumnType("int");

                    b.Property<string>("GenreName")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Genre Name");

                    b.Property<int>("TrackId")
                        .HasColumnType("int");

                    b.Property<string>("TrackTitle")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Track Title");

                    b.HasKey("Id");

                    b.HasIndex("GenreId");

                    b.HasIndex("TrackId");

                    b.ToView("qryTrack", "dbo");
                });

            modelBuilder.Entity("QnSProjectAward.Logic.Entities.Persistence.Test.EditForm", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<byte?>("ByteNullable")
                        .HasColumnType("tinyint");

                    b.Property<byte>("ByteValue")
                        .HasColumnType("tinyint");

                    b.Property<bool>("CheckBox")
                        .HasColumnType("bit");

                    b.Property<bool?>("CheckBoxNullable")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("DateTimeNullable")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateTimeValue")
                        .HasColumnType("datetime2");

                    b.Property<double?>("DoubleNullable")
                        .HasColumnType("float");

                    b.Property<double>("DoubleValue")
                        .HasColumnType("float");

                    b.Property<int>("EnumState")
                        .HasColumnType("int");

                    b.Property<int?>("IntegerNullable")
                        .HasColumnType("int");

                    b.Property<int>("IntegerValue")
                        .HasColumnType("int");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.Property<short?>("ShortNullable")
                        .HasColumnType("smallint");

                    b.Property<short>("ShortValue")
                        .HasColumnType("smallint");

                    b.Property<string>("TextArea")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("TextAreaReadonly")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("TextBox")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("TextBoxRequired")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<TimeSpan?>("TimeSpanNullable")
                        .HasColumnType("time");

                    b.Property<TimeSpan>("TimeSpanValue")
                        .HasColumnType("time");

                    b.HasKey("Id");

                    b.ToTable("EditForm", "Test");
                });

            modelBuilder.Entity("QnSProjectAward.Logic.Entities.Persistence.Test.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Discount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<double>("Percentage")
                        .HasColumnType("float");

                    b.Property<decimal>("PiecePrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("PriceNet")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.HasKey("Id");

                    b.ToTable("Order", "Test");
                });

            modelBuilder.Entity("QnSProjectAward.Logic.Entities.Persistence.MusicStoreApp.GenreEx", b =>
                {
                    b.HasBaseType("QnSProjectAward.Logic.Entities.Persistence.MusicStoreApp.Genre");

                    b.Property<string>("Note")
                        .HasMaxLength(1024)
                        .HasColumnType("nvarchar(1024)");

                    b.ToTable("GenreEx", "MusicStoreApp");
                });

            modelBuilder.Entity("QnSProjectAward.Logic.Entities.Persistence.Account.ActionLog", b =>
                {
                    b.HasOne("QnSProjectAward.Logic.Entities.Persistence.Account.Identity", "Identity")
                        .WithMany("ActionLogs")
                        .HasForeignKey("IdentityId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Identity");
                });

            modelBuilder.Entity("QnSProjectAward.Logic.Entities.Persistence.Account.IdentityXRole", b =>
                {
                    b.HasOne("QnSProjectAward.Logic.Entities.Persistence.Account.Identity", "Identity")
                        .WithMany("IdentityXRoles")
                        .HasForeignKey("IdentityId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("QnSProjectAward.Logic.Entities.Persistence.Account.Role", "Role")
                        .WithMany("IdentityXRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Identity");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("QnSProjectAward.Logic.Entities.Persistence.Account.LoginSession", b =>
                {
                    b.HasOne("QnSProjectAward.Logic.Entities.Persistence.Account.Identity", "Identity")
                        .WithMany("LoginSessions")
                        .HasForeignKey("IdentityId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Identity");
                });

            modelBuilder.Entity("QnSProjectAward.Logic.Entities.Persistence.Account.User", b =>
                {
                    b.HasOne("QnSProjectAward.Logic.Entities.Persistence.Account.Identity", "Identity")
                        .WithMany("Users")
                        .HasForeignKey("IdentityId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Identity");
                });

            modelBuilder.Entity("QnSProjectAward.Logic.Entities.Persistence.MusicStoreApp.Album", b =>
                {
                    b.HasOne("QnSProjectAward.Logic.Entities.Persistence.MusicStoreApp.Artist", "Artist")
                        .WithMany("Albums")
                        .HasForeignKey("ArtistId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Artist");
                });

            modelBuilder.Entity("QnSProjectAward.Logic.Entities.Persistence.MusicStoreApp.Track", b =>
                {
                    b.HasOne("QnSProjectAward.Logic.Entities.Persistence.MusicStoreApp.Album", "Album")
                        .WithMany("Tracks")
                        .HasForeignKey("AlbumId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("QnSProjectAward.Logic.Entities.Persistence.MusicStoreApp.Genre", "Genre")
                        .WithMany("Tracks")
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Album");

                    b.Navigation("Genre");
                });

            modelBuilder.Entity("QnSProjectAward.Logic.Entities.Persistence.MusicStoreApp.ViewFullTrack", b =>
                {
                    b.HasOne("QnSProjectAward.Logic.Entities.Persistence.MusicStoreApp.Album", "Album")
                        .WithMany()
                        .HasForeignKey("AlbumId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("QnSProjectAward.Logic.Entities.Persistence.MusicStoreApp.Genre", "Genre")
                        .WithMany()
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Album");

                    b.Navigation("Genre");
                });

            modelBuilder.Entity("QnSProjectAward.Logic.Entities.Persistence.MusicStoreApp.ViewTrack", b =>
                {
                    b.HasOne("QnSProjectAward.Logic.Entities.Persistence.MusicStoreApp.Genre", "Genre")
                        .WithMany()
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("QnSProjectAward.Logic.Entities.Persistence.MusicStoreApp.Track", "Track")
                        .WithMany()
                        .HasForeignKey("TrackId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Genre");

                    b.Navigation("Track");
                });

            modelBuilder.Entity("QnSProjectAward.Logic.Entities.Persistence.MusicStoreApp.GenreEx", b =>
                {
                    b.HasOne("QnSProjectAward.Logic.Entities.Persistence.MusicStoreApp.Genre", null)
                        .WithOne()
                        .HasForeignKey("QnSProjectAward.Logic.Entities.Persistence.MusicStoreApp.GenreEx", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("QnSProjectAward.Logic.Entities.Persistence.Account.Identity", b =>
                {
                    b.Navigation("ActionLogs");

                    b.Navigation("IdentityXRoles");

                    b.Navigation("LoginSessions");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("QnSProjectAward.Logic.Entities.Persistence.Account.Role", b =>
                {
                    b.Navigation("IdentityXRoles");
                });

            modelBuilder.Entity("QnSProjectAward.Logic.Entities.Persistence.MusicStoreApp.Album", b =>
                {
                    b.Navigation("Tracks");
                });

            modelBuilder.Entity("QnSProjectAward.Logic.Entities.Persistence.MusicStoreApp.Artist", b =>
                {
                    b.Navigation("Albums");
                });

            modelBuilder.Entity("QnSProjectAward.Logic.Entities.Persistence.MusicStoreApp.Genre", b =>
                {
                    b.Navigation("Tracks");
                });
#pragma warning restore 612, 618
        }
    }
}
