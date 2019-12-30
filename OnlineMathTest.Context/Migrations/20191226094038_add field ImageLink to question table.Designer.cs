﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OnlineMathTest.Context;

namespace OnlineMathTest.Context.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20191226094038_add field ImageLink to question table")]
    partial class addfieldImageLinktoquestiontable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("OnlineMathTest.Models.Models.Level", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("CreateOn");

                    b.Property<bool?>("IsDeleted");

                    b.Property<string>("LevelName");

                    b.HasKey("Id");

                    b.ToTable("Level");
                });

            modelBuilder.Entity("OnlineMathTest.Models.Models.Mcq", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("Attempts");

                    b.Property<DateTime?>("CreateOn");

                    b.Property<int?>("Duration");

                    b.Property<string>("ExamType");

                    b.Property<bool?>("IsDeleted");

                    b.Property<int?>("LevelType");

                    b.Property<int?>("LevelTypeNavigationId");

                    b.Property<int?>("NumberOfQuestion");

                    b.Property<string>("Title");

                    b.Property<string>("Type");

                    b.Property<int?>("Views");

                    b.HasKey("Id");

                    b.HasIndex("LevelTypeNavigationId");

                    b.ToTable("Mcq");
                });

            modelBuilder.Entity("OnlineMathTest.Models.Models.Mcqhistory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CreateBy");

                    b.Property<DateTime?>("CreateOn");

                    b.Property<int>("Mcqid");

                    b.Property<int>("QuestionAnswerId");

                    b.Property<int>("QuestionId");

                    b.Property<int>("UserTestId");

                    b.HasKey("Id");

                    b.HasIndex("Mcqid");

                    b.HasIndex("QuestionAnswerId");

                    b.HasIndex("QuestionId");

                    b.HasIndex("UserTestId");

                    b.ToTable("Mcqhistory");
                });

            modelBuilder.Entity("OnlineMathTest.Models.Models.Mcqquestion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("McqquestionId");

                    b.Property<int?>("McqquestionNavigationId");

                    b.Property<int>("QuestionId");

                    b.HasKey("Id");

                    b.HasIndex("McqquestionNavigationId");

                    b.HasIndex("QuestionId");

                    b.ToTable("Mcqquestion");
                });

            modelBuilder.Entity("OnlineMathTest.Models.Models.Question", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CorrectAnswer");

                    b.Property<DateTime?>("CreateOn");

                    b.Property<string>("Guide");

                    b.Property<string>("ImageLink");

                    b.Property<bool?>("IsDeleted");

                    b.Property<int?>("LevelType");

                    b.Property<int?>("LevelTypeNavigationId");

                    b.Property<double?>("Point");

                    b.Property<int?>("QuestionType");

                    b.Property<int?>("QuestionTypeNavigationId");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.HasIndex("LevelTypeNavigationId");

                    b.HasIndex("QuestionTypeNavigationId");

                    b.ToTable("Question");
                });

            modelBuilder.Entity("OnlineMathTest.Models.Models.QuestionAnswer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Answer");

                    b.Property<string>("AnswerType");

                    b.Property<string>("AnswerTypeChoice");

                    b.Property<string>("Choice");

                    b.Property<DateTime?>("CreateOn");

                    b.Property<int?>("DisplayNumber");

                    b.Property<bool?>("IsDeleted");

                    b.Property<int>("QuestionId");

                    b.HasKey("Id");

                    b.HasIndex("QuestionId");

                    b.ToTable("QuestionAnswer");
                });

            modelBuilder.Entity("OnlineMathTest.Models.Models.QuestionType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("CreateOn");

                    b.Property<bool?>("IsDeleted");

                    b.Property<string>("QuestionType1");

                    b.HasKey("Id");

                    b.ToTable("QuestionType");
                });

            modelBuilder.Entity("OnlineMathTest.Models.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("CreateOn");

                    b.Property<string>("Firstname");

                    b.Property<bool?>("IsDeleted");

                    b.Property<string>("Lastname");

                    b.Property<string>("Password");

                    b.Property<string>("Type");

                    b.Property<string>("Username");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("OnlineMathTest.Models.Models.UserTest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("CreateOn");

                    b.Property<int>("Mcqid");

                    b.Property<double?>("Point");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("Mcqid");

                    b.HasIndex("UserId");

                    b.ToTable("UserTest");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("OnlineMathTest.Models.Models.Mcq", b =>
                {
                    b.HasOne("OnlineMathTest.Models.Models.Level", "LevelTypeNavigation")
                        .WithMany("Mcq")
                        .HasForeignKey("LevelTypeNavigationId");
                });

            modelBuilder.Entity("OnlineMathTest.Models.Models.Mcqhistory", b =>
                {
                    b.HasOne("OnlineMathTest.Models.Models.Mcq", "Mcq")
                        .WithMany("Mcqhistory")
                        .HasForeignKey("Mcqid")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("OnlineMathTest.Models.Models.QuestionAnswer", "QuestionAnswer")
                        .WithMany("Mcqhistory")
                        .HasForeignKey("QuestionAnswerId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("OnlineMathTest.Models.Models.Question", "Question")
                        .WithMany("Mcqhistory")
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("OnlineMathTest.Models.Models.UserTest", "UserTest")
                        .WithMany("Mcqhistory")
                        .HasForeignKey("UserTestId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("OnlineMathTest.Models.Models.Mcqquestion", b =>
                {
                    b.HasOne("OnlineMathTest.Models.Models.Mcq", "McqquestionNavigation")
                        .WithMany("Mcqquestion")
                        .HasForeignKey("McqquestionNavigationId");

                    b.HasOne("OnlineMathTest.Models.Models.Question", "Question")
                        .WithMany("Mcqquestion")
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("OnlineMathTest.Models.Models.Question", b =>
                {
                    b.HasOne("OnlineMathTest.Models.Models.Level", "LevelTypeNavigation")
                        .WithMany("Question")
                        .HasForeignKey("LevelTypeNavigationId");

                    b.HasOne("OnlineMathTest.Models.Models.QuestionType", "QuestionTypeNavigation")
                        .WithMany("Question")
                        .HasForeignKey("QuestionTypeNavigationId");
                });

            modelBuilder.Entity("OnlineMathTest.Models.Models.QuestionAnswer", b =>
                {
                    b.HasOne("OnlineMathTest.Models.Models.Question", "Question")
                        .WithMany("QuestionAnswer")
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("OnlineMathTest.Models.Models.UserTest", b =>
                {
                    b.HasOne("OnlineMathTest.Models.Models.Mcq", "Mcq")
                        .WithMany("UserTest")
                        .HasForeignKey("Mcqid")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("OnlineMathTest.Models.Models.User", "User")
                        .WithMany("UserTest")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
