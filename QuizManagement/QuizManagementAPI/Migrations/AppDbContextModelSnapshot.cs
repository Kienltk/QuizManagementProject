﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using QuizManagementAPI.Data;

#nullable disable

namespace QuizManagementAPI.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("QuizManagementAPI.Models.AttemptAnswer", b =>
                {
                    b.Property<int>("AttemptID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("QuestionID")
                        .HasColumnType("int");

                    b.Property<bool?>("IsCorrect")
                        .HasColumnType("bit");

                    b.Property<int?>("SelectedOptionID")
                        .HasColumnType("int");

                    b.HasKey("AttemptID", "QuestionID");

                    b.HasIndex("QuestionID");

                    b.HasIndex("SelectedOptionID");

                    b.ToTable("AttemptAnswers");
                });

            modelBuilder.Entity("QuizManagementAPI.Models.Class", b =>
                {
                    b.Property<int>("ClassID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ClassID"));

                    b.Property<string>("ClassName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ClassID");

                    b.HasIndex("CreatedBy");

                    b.ToTable("Classes");
                });

            modelBuilder.Entity("QuizManagementAPI.Models.ClassMembership", b =>
                {
                    b.Property<int>("ClassID")
                        .HasColumnType("int");

                    b.Property<int>("StudentID")
                        .HasColumnType("int");

                    b.HasKey("ClassID", "StudentID");

                    b.HasIndex("StudentID");

                    b.ToTable("ClassMemberships");
                });

            modelBuilder.Entity("QuizManagementAPI.Models.ClassQuiz", b =>
                {
                    b.Property<int>("ClassID")
                        .HasColumnType("int");

                    b.Property<int>("QuizID")
                        .HasColumnType("int");

                    b.HasKey("ClassID", "QuizID");

                    b.HasIndex("QuizID");

                    b.ToTable("ClassQuizzes");
                });

            modelBuilder.Entity("QuizManagementAPI.Models.Question", b =>
                {
                    b.Property<int>("QuestionID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("QuestionID"));

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<int?>("Difficulty")
                        .HasColumnType("int");

                    b.Property<bool>("IsPublic")
                        .HasColumnType("bit");

                    b.Property<string>("QuestionText")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("QuestionType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SubjectArea")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("QuestionID");

                    b.HasIndex("CreatedBy");

                    b.ToTable("Questions");
                });

            modelBuilder.Entity("QuizManagementAPI.Models.QuestionOption", b =>
                {
                    b.Property<int>("OptionID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OptionID"));

                    b.Property<bool>("IsCorrect")
                        .HasColumnType("bit");

                    b.Property<string>("OptionText")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("QuestionID")
                        .HasColumnType("int");

                    b.HasKey("OptionID");

                    b.HasIndex("QuestionID");

                    b.ToTable("QuestionOptions");
                });

            modelBuilder.Entity("QuizManagementAPI.Models.Quiz", b =>
                {
                    b.Property<int>("QuizID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("QuizID"));

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsPublic")
                        .HasColumnType("bit");

                    b.Property<string>("QuizCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("QuizTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("QuizID");

                    b.HasIndex("CreatedBy");

                    b.ToTable("Quizzes");
                });

            modelBuilder.Entity("QuizManagementAPI.Models.QuizAttempt", b =>
                {
                    b.Property<int>("AttemptID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AttemptID"));

                    b.Property<DateTime?>("EndTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("QuizID")
                        .HasColumnType("int");

                    b.Property<int?>("RoomID")
                        .HasColumnType("int");

                    b.Property<int?>("Score")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("StudentID")
                        .HasColumnType("int");

                    b.HasKey("AttemptID");

                    b.HasIndex("QuizID");

                    b.HasIndex("RoomID");

                    b.HasIndex("StudentID");

                    b.ToTable("QuizAttempts");
                });

            modelBuilder.Entity("QuizManagementAPI.Models.QuizQuestion", b =>
                {
                    b.Property<int>("QuizID")
                        .HasColumnType("int");

                    b.Property<int>("QuestionID")
                        .HasColumnType("int");

                    b.Property<int>("OrderNumber")
                        .HasColumnType("int");

                    b.HasKey("QuizID", "QuestionID");

                    b.HasIndex("QuestionID");

                    b.ToTable("QuizQuestions");
                });

            modelBuilder.Entity("QuizManagementAPI.Models.Role", b =>
                {
                    b.Property<int>("RoleID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RoleID"));

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RoleID");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("QuizManagementAPI.Models.Room", b =>
                {
                    b.Property<int>("RoomID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RoomID"));

                    b.Property<int?>("ClassID")
                        .HasColumnType("int");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("EndTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsPublish")
                        .HasColumnType("bit");

                    b.Property<int>("QuizID")
                        .HasColumnType("int");

                    b.Property<string>("RoomCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("StartTime")
                        .HasColumnType("datetime2");

                    b.HasKey("RoomID");

                    b.HasIndex("ClassID");

                    b.HasIndex("CreatedBy");

                    b.HasIndex("QuizID");

                    b.ToTable("Rooms");
                });

            modelBuilder.Entity("QuizManagementAPI.Models.RoomParticipant", b =>
                {
                    b.Property<int>("RoomID")
                        .HasColumnType("int");

                    b.Property<int>("StudentID")
                        .HasColumnType("int");

                    b.HasKey("RoomID", "StudentID");

                    b.HasIndex("StudentID");

                    b.ToTable("RoomParticipants");
                });

            modelBuilder.Entity("QuizManagementAPI.Models.User", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserID"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleID")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserID");

                    b.HasIndex("RoleID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("QuizManagementAPI.Models.AttemptAnswer", b =>
                {
                    b.HasOne("QuizManagementAPI.Models.QuizAttempt", "Attempt")
                        .WithMany("AttemptAnswers")
                        .HasForeignKey("AttemptID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("QuizManagementAPI.Models.Question", "Question")
                        .WithMany("AttemptAnswers")
                        .HasForeignKey("QuestionID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("QuizManagementAPI.Models.QuestionOption", "SelectedOption")
                        .WithMany()
                        .HasForeignKey("SelectedOptionID")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("Attempt");

                    b.Navigation("Question");

                    b.Navigation("SelectedOption");
                });

            modelBuilder.Entity("QuizManagementAPI.Models.Class", b =>
                {
                    b.HasOne("QuizManagementAPI.Models.User", "CreatedByUser")
                        .WithMany("CreatedClasses")
                        .HasForeignKey("CreatedBy")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("CreatedByUser");
                });

            modelBuilder.Entity("QuizManagementAPI.Models.ClassMembership", b =>
                {
                    b.HasOne("QuizManagementAPI.Models.Class", "Class")
                        .WithMany("ClassMemberships")
                        .HasForeignKey("ClassID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("QuizManagementAPI.Models.User", "Student")
                        .WithMany("ClassMemberships")
                        .HasForeignKey("StudentID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Class");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("QuizManagementAPI.Models.ClassQuiz", b =>
                {
                    b.HasOne("QuizManagementAPI.Models.Class", "Class")
                        .WithMany("ClassQuizzes")
                        .HasForeignKey("ClassID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("QuizManagementAPI.Models.Quiz", "Quiz")
                        .WithMany("ClassQuizzes")
                        .HasForeignKey("QuizID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Class");

                    b.Navigation("Quiz");
                });

            modelBuilder.Entity("QuizManagementAPI.Models.Question", b =>
                {
                    b.HasOne("QuizManagementAPI.Models.User", "CreatedByUser")
                        .WithMany("CreatedQuestions")
                        .HasForeignKey("CreatedBy")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("CreatedByUser");
                });

            modelBuilder.Entity("QuizManagementAPI.Models.QuestionOption", b =>
                {
                    b.HasOne("QuizManagementAPI.Models.Question", "Question")
                        .WithMany("Options")
                        .HasForeignKey("QuestionID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Question");
                });

            modelBuilder.Entity("QuizManagementAPI.Models.Quiz", b =>
                {
                    b.HasOne("QuizManagementAPI.Models.User", "CreatedByUser")
                        .WithMany("CreatedQuizzes")
                        .HasForeignKey("CreatedBy")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("CreatedByUser");
                });

            modelBuilder.Entity("QuizManagementAPI.Models.QuizAttempt", b =>
                {
                    b.HasOne("QuizManagementAPI.Models.Quiz", "Quiz")
                        .WithMany("QuizAttempts")
                        .HasForeignKey("QuizID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("QuizManagementAPI.Models.Room", "Room")
                        .WithMany("QuizAttempts")
                        .HasForeignKey("RoomID")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("QuizManagementAPI.Models.User", "Student")
                        .WithMany("QuizAttempts")
                        .HasForeignKey("StudentID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Quiz");

                    b.Navigation("Room");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("QuizManagementAPI.Models.QuizQuestion", b =>
                {
                    b.HasOne("QuizManagementAPI.Models.Question", "Question")
                        .WithMany("QuizQuestions")
                        .HasForeignKey("QuestionID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("QuizManagementAPI.Models.Quiz", "Quiz")
                        .WithMany("QuizQuestions")
                        .HasForeignKey("QuizID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Question");

                    b.Navigation("Quiz");
                });

            modelBuilder.Entity("QuizManagementAPI.Models.Room", b =>
                {
                    b.HasOne("QuizManagementAPI.Models.Class", "Class")
                        .WithMany()
                        .HasForeignKey("ClassID")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("QuizManagementAPI.Models.User", "CreatedByUser")
                        .WithMany("CreatedRooms")
                        .HasForeignKey("CreatedBy")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("QuizManagementAPI.Models.Quiz", "Quiz")
                        .WithMany("Rooms")
                        .HasForeignKey("QuizID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Class");

                    b.Navigation("CreatedByUser");

                    b.Navigation("Quiz");
                });

            modelBuilder.Entity("QuizManagementAPI.Models.RoomParticipant", b =>
                {
                    b.HasOne("QuizManagementAPI.Models.Room", "Room")
                        .WithMany("RoomParticipants")
                        .HasForeignKey("RoomID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("QuizManagementAPI.Models.User", "Student")
                        .WithMany("RoomParticipations")
                        .HasForeignKey("StudentID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Room");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("QuizManagementAPI.Models.User", b =>
                {
                    b.HasOne("QuizManagementAPI.Models.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("QuizManagementAPI.Models.Class", b =>
                {
                    b.Navigation("ClassMemberships");

                    b.Navigation("ClassQuizzes");
                });

            modelBuilder.Entity("QuizManagementAPI.Models.Question", b =>
                {
                    b.Navigation("AttemptAnswers");

                    b.Navigation("Options");

                    b.Navigation("QuizQuestions");
                });

            modelBuilder.Entity("QuizManagementAPI.Models.Quiz", b =>
                {
                    b.Navigation("ClassQuizzes");

                    b.Navigation("QuizAttempts");

                    b.Navigation("QuizQuestions");

                    b.Navigation("Rooms");
                });

            modelBuilder.Entity("QuizManagementAPI.Models.QuizAttempt", b =>
                {
                    b.Navigation("AttemptAnswers");
                });

            modelBuilder.Entity("QuizManagementAPI.Models.Role", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("QuizManagementAPI.Models.Room", b =>
                {
                    b.Navigation("QuizAttempts");

                    b.Navigation("RoomParticipants");
                });

            modelBuilder.Entity("QuizManagementAPI.Models.User", b =>
                {
                    b.Navigation("ClassMemberships");

                    b.Navigation("CreatedClasses");

                    b.Navigation("CreatedQuestions");

                    b.Navigation("CreatedQuizzes");

                    b.Navigation("CreatedRooms");

                    b.Navigation("QuizAttempts");

                    b.Navigation("RoomParticipations");
                });
#pragma warning restore 612, 618
        }
    }
}
