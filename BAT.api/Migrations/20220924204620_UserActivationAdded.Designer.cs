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
    [Migration("20220924204620_UserActivationAdded")]
    partial class UserActivationAdded
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

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<string>("SecretAnswer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Updated")
                        .HasColumnType("datetime2");

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
                            Created = new DateTime(2022, 9, 24, 20, 46, 20, 328, DateTimeKind.Utc).AddTicks(7371),
                            Email = "batAdmin@gmail.com",
                            FirstName = "Dennis",
                            IsOnline = true,
                            LastName = "Osagiede",
                            LastTimeLoggedIn = new DateTime(2022, 9, 24, 20, 46, 20, 328, DateTimeKind.Utc).AddTicks(7372),
                            LoggedOutTime = new DateTime(2022, 9, 24, 20, 46, 20, 328, DateTimeKind.Utc).AddTicks(7373),
                            PasswordHash = "$HASH|V1$10000$eRRuxwfi1eOLn+jS4vfw37Xt0oD2FXHuO7WwVskzIuF0LGKc",
                            Role = 2,
                            SecretAnswer = "TnVUfh67W2LTbJemuDoCQQ==",
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
                            Created = new DateTime(2022, 9, 24, 20, 46, 20, 328, DateTimeKind.Utc).AddTicks(7257),
                            CreatedBy = 1,
                            Name = "Can use upload data feature"
                        },
                        new
                        {
                            Id = 2,
                            Created = new DateTime(2022, 9, 24, 20, 46, 20, 328, DateTimeKind.Utc).AddTicks(7259),
                            CreatedBy = 1,
                            Name = "Can use the process data feature"
                        },
                        new
                        {
                            Id = 3,
                            Created = new DateTime(2022, 9, 24, 20, 46, 20, 328, DateTimeKind.Utc).AddTicks(7260),
                            CreatedBy = 1,
                            Name = "Can use the analyze data feature"
                        },
                        new
                        {
                            Id = 4,
                            Created = new DateTime(2022, 9, 24, 20, 46, 20, 328, DateTimeKind.Utc).AddTicks(7260),
                            CreatedBy = 1,
                            Name = "Can use the export data feature"
                        },
                        new
                        {
                            Id = 5,
                            Created = new DateTime(2022, 9, 24, 20, 46, 20, 328, DateTimeKind.Utc).AddTicks(7261),
                            CreatedBy = 1,
                            Name = "Can use the view or edit data feature"
                        },
                        new
                        {
                            Id = 6,
                            Created = new DateTime(2022, 9, 24, 20, 46, 20, 328, DateTimeKind.Utc).AddTicks(7262),
                            CreatedBy = 1,
                            Name = "Can use the update data feature"
                        },
                        new
                        {
                            Id = 7,
                            Created = new DateTime(2022, 9, 24, 20, 46, 20, 328, DateTimeKind.Utc).AddTicks(7263),
                            CreatedBy = 1,
                            Name = "Can add new team"
                        },
                        new
                        {
                            Id = 8,
                            Created = new DateTime(2022, 9, 24, 20, 46, 20, 328, DateTimeKind.Utc).AddTicks(7263),
                            CreatedBy = 1,
                            Name = "Can add new privilege"
                        },
                        new
                        {
                            Id = 9,
                            Created = new DateTime(2022, 9, 24, 20, 46, 20, 328, DateTimeKind.Utc).AddTicks(7264),
                            CreatedBy = 1,
                            Name = "Can change team name"
                        },
                        new
                        {
                            Id = 10,
                            Created = new DateTime(2022, 9, 24, 20, 46, 20, 328, DateTimeKind.Utc).AddTicks(7265),
                            CreatedBy = 1,
                            Name = "Can view teams"
                        },
                        new
                        {
                            Id = 11,
                            Created = new DateTime(2022, 9, 24, 20, 46, 20, 328, DateTimeKind.Utc).AddTicks(7266),
                            CreatedBy = 1,
                            Name = "Can add admin users to teams"
                        });
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

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("UserActivations");
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
