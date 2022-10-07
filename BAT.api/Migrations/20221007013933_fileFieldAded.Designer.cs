﻿// <auto-generated />
using System;
using BAT.api.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BAT.api.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20221007013933_fileFieldAded")]
    partial class fileFieldAded
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("BAT.api.Models.Entities.Account", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsAdminPrivate")
                        .HasColumnType("bit");

                    b.Property<bool>("IsOnline")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("LastTimeLoggedIn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("LoggedOutTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("PasswordReset")
                        .HasColumnType("datetime2");

                    b.Property<string>("ResetToken")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ResetTokenExpires")
                        .HasColumnType("datetime2");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SecretAnswer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Updated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VerificationToken")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Verified")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Accounts");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Created = new DateTime(2022, 10, 7, 1, 39, 33, 25, DateTimeKind.Utc).AddTicks(6777),
                            Email = "batAdmin@gmail.com",
                            FirstName = "Dennis",
                            IsAdminPrivate = false,
                            IsOnline = true,
                            LastName = "Osagiede",
                            LastTimeLoggedIn = new DateTime(2022, 10, 7, 1, 39, 33, 25, DateTimeKind.Utc).AddTicks(6779),
                            LoggedOutTime = new DateTime(2022, 10, 7, 1, 39, 33, 25, DateTimeKind.Utc).AddTicks(6780),
                            PasswordHash = "$HASH|V1$10000$tyMhv6E3xHzoLWypRw7YVtiOaV0mb6uBRDwtyWSK+NXSVCPK",
                            Role = "SuperAdmin",
                            SecretAnswer = "TnVUfh67W2LTbJemuDoCQQ==",
                            Username = "mustang247",
                            VerificationToken = ""
                        });
                });

            modelBuilder.Entity("BAT.api.Models.Entities.AdminTeam", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AddedBy")
                        .HasColumnType("int");

                    b.Property<int>("AdminId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<int>("TeamId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("AdminTeams");
                });

            modelBuilder.Entity("BAT.api.Models.Entities.AnalyzeData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("AdminId")
                        .HasColumnType("int");

                    b.Property<string>("AnalyzedRecord")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<string>("ExportStatus")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ExportedBy")
                        .HasColumnType("int");

                    b.Property<int>("FileId")
                        .HasColumnType("int");

                    b.Property<string>("Objective")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("AnalyzeDatas");
                });

            modelBuilder.Entity("BAT.api.Models.Entities.Audit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("AffectedColumns")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AreaAccessed")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BrowserInfo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("HttpMethod")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ip")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NewValues")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OldValues")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PrimaryKey")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ReasonForUpdate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TableName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TraceId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WorkStation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("AuditLogs");
                });

            modelBuilder.Entity("BAT.api.Models.Entities.Candidate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Achievements")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AreaRepresenting")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CandidateImage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<string>("Education")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FaceBook")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Instagram")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("LastTimeModified")
                        .HasColumnType("datetime2");

                    b.Property<int>("MoidifiedBy")
                        .HasColumnType("int");

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Twitter")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WhatAppNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WorkExperinece")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Candidates");
                });

            modelBuilder.Entity("BAT.api.Models.Entities.FileUpload", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime?>("DateMerged")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateProcessed")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateSaved")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateUploaded")
                        .HasColumnType("datetime2");

                    b.Property<string>("DownloadUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Fields")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FileSize")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FileType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FileUploadType")
                        .HasColumnType("int");

                    b.Property<string>("HourMerged")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HourProcessed")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HourUploaded")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsInPreviewMode")
                        .HasColumnType("bit");

                    b.Property<bool>("IsMerged")
                        .HasColumnType("bit");

                    b.Property<bool>("IsProcessed")
                        .HasColumnType("bit");

                    b.Property<int?>("MergedBy")
                        .HasColumnType("int");

                    b.Property<string>("MergedDetails")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ProcessedBy")
                        .HasColumnType("int");

                    b.Property<int>("TotalRecordCount")
                        .HasColumnType("int");

                    b.Property<int>("UploadedBy")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("FileUploads");
                });

            modelBuilder.Entity("BAT.api.Models.Entities.Permission", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Permissions");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Created = new DateTime(2022, 10, 7, 1, 39, 33, 25, DateTimeKind.Utc).AddTicks(6637),
                            CreatedBy = 1,
                            Name = "Can use upload data feature"
                        },
                        new
                        {
                            Id = 2,
                            Created = new DateTime(2022, 10, 7, 1, 39, 33, 25, DateTimeKind.Utc).AddTicks(6641),
                            CreatedBy = 1,
                            Name = "Can use the process data feature"
                        },
                        new
                        {
                            Id = 3,
                            Created = new DateTime(2022, 10, 7, 1, 39, 33, 25, DateTimeKind.Utc).AddTicks(6642),
                            CreatedBy = 1,
                            Name = "Can use the analyze data feature"
                        },
                        new
                        {
                            Id = 4,
                            Created = new DateTime(2022, 10, 7, 1, 39, 33, 25, DateTimeKind.Utc).AddTicks(6643),
                            CreatedBy = 1,
                            Name = "Can use the export data feature"
                        },
                        new
                        {
                            Id = 5,
                            Created = new DateTime(2022, 10, 7, 1, 39, 33, 25, DateTimeKind.Utc).AddTicks(6648),
                            CreatedBy = 1,
                            Name = "Can use the view or edit data feature"
                        },
                        new
                        {
                            Id = 6,
                            Created = new DateTime(2022, 10, 7, 1, 39, 33, 25, DateTimeKind.Utc).AddTicks(6649),
                            CreatedBy = 1,
                            Name = "Can use the update data feature"
                        },
                        new
                        {
                            Id = 7,
                            Created = new DateTime(2022, 10, 7, 1, 39, 33, 25, DateTimeKind.Utc).AddTicks(6650),
                            CreatedBy = 1,
                            Name = "Can add new team"
                        },
                        new
                        {
                            Id = 8,
                            Created = new DateTime(2022, 10, 7, 1, 39, 33, 25, DateTimeKind.Utc).AddTicks(6650),
                            CreatedBy = 1,
                            Name = "Can add new privilege"
                        },
                        new
                        {
                            Id = 9,
                            Created = new DateTime(2022, 10, 7, 1, 39, 33, 25, DateTimeKind.Utc).AddTicks(6651),
                            CreatedBy = 1,
                            Name = "Can change team name"
                        },
                        new
                        {
                            Id = 10,
                            Created = new DateTime(2022, 10, 7, 1, 39, 33, 25, DateTimeKind.Utc).AddTicks(6652),
                            CreatedBy = 1,
                            Name = "Can view teams"
                        },
                        new
                        {
                            Id = 11,
                            Created = new DateTime(2022, 10, 7, 1, 39, 33, 25, DateTimeKind.Utc).AddTicks(6652),
                            CreatedBy = 1,
                            Name = "Can add admin users to teams"
                        });
                });

            modelBuilder.Entity("BAT.api.Models.Entities.ProcessedFileDetails", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Administrator")
                        .HasColumnType("int");

                    b.Property<string>("AdministratorName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateProcessed")
                        .HasColumnType("datetime2");

                    b.Property<string>("DownloadUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Fields")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FileId")
                        .HasColumnType("int");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProcessRule")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ProcessedFileDetails");
                });

            modelBuilder.Entity("BAT.api.Models.Entities.ProvisionedAdmin", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("HasCompletedRegistration")
                        .HasColumnType("bit");

                    b.Property<bool>("IsPrivateAdmin")
                        .HasColumnType("bit");

                    b.Property<DateTime>("Requested")
                        .HasColumnType("datetime2");

                    b.Property<int>("RequesterId")
                        .HasColumnType("int");

                    b.Property<int>("TeamId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("ProvisionedAdmins");
                });

            modelBuilder.Entity("BAT.api.Models.Entities.Team", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<int>("CretaedBy")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime>("LastTimeUpdated")
                        .HasColumnType("datetime2");

                    b.Property<int>("ModifiedBy")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("BAT.api.Models.Entities.TeamPermission", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<int>("PermissionId")
                        .HasColumnType("int");

                    b.Property<int>("TeamId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("TeamPermissions");
                });

            modelBuilder.Entity("BAT.api.Models.Entities.UserActivation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("DateActivated")
                        .HasColumnType("datetime2");

                    b.Property<string>("HourActivated")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("WeekActivated")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("UserActivations");
                });

            modelBuilder.Entity("BAT.api.Models.Entities.UserData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Age")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Created")
                        .HasColumnType("datetime2");

                    b.Property<int?>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FileFields")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("FileId")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("UserDatas");
                });

            modelBuilder.Entity("BAT.api.Models.Entities.Account", b =>
                {
                    b.OwnsMany("BAT.api.Models.Entities.RefreshToken", "RefreshTokens", b1 =>
                        {
                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int");

                            SqlServerPropertyBuilderExtensions.UseIdentityColumn(b1.Property<int>("Id"), 1L, 1);

                            b1.Property<int>("AccountId")
                                .HasColumnType("int");

                            b1.Property<DateTime>("Created")
                                .HasColumnType("datetime2");

                            b1.Property<string>("CreatedByIp")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<DateTime>("Expires")
                                .HasColumnType("datetime2");

                            b1.Property<string>("ReasonRevoked")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("ReplacedByToken")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<DateTime?>("Revoked")
                                .HasColumnType("datetime2");

                            b1.Property<string>("RevokedByIp")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Token")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("Id");

                            b1.HasIndex("AccountId");

                            b1.ToTable("RefreshToken");

                            b1.WithOwner("Account")
                                .HasForeignKey("AccountId");

                            b1.Navigation("Account");
                        });

                    b.Navigation("RefreshTokens");
                });
#pragma warning restore 612, 618
        }
    }
}
