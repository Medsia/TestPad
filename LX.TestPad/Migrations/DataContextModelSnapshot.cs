﻿// <auto-generated />
using LX.TestPad.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LX.TestPad.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("LX.TestPad.DataAccess.Answer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsCorrect")
                        .HasColumnType("bit");

                    b.Property<int>("QuestionId")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("QuestionId");

                    b.ToTable("Answers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IsCorrect = true,
                            QuestionId = 1,
                            Text = "Yes"
                        },
                        new
                        {
                            Id = 2,
                            IsCorrect = false,
                            QuestionId = 1,
                            Text = "No"
                        },
                        new
                        {
                            Id = 3,
                            IsCorrect = false,
                            QuestionId = 1,
                            Text = "What?"
                        },
                        new
                        {
                            Id = 4,
                            IsCorrect = true,
                            QuestionId = 2,
                            Text = "Yes"
                        },
                        new
                        {
                            Id = 5,
                            IsCorrect = false,
                            QuestionId = 2,
                            Text = "No"
                        },
                        new
                        {
                            Id = 6,
                            IsCorrect = false,
                            QuestionId = 2,
                            Text = "What?"
                        },
                        new
                        {
                            Id = 7,
                            IsCorrect = true,
                            QuestionId = 3,
                            Text = "Yes"
                        },
                        new
                        {
                            Id = 8,
                            IsCorrect = false,
                            QuestionId = 3,
                            Text = "No"
                        },
                        new
                        {
                            Id = 9,
                            IsCorrect = false,
                            QuestionId = 3,
                            Text = "What?"
                        },
                        new
                        {
                            Id = 10,
                            IsCorrect = true,
                            QuestionId = 4,
                            Text = "Yes"
                        },
                        new
                        {
                            Id = 11,
                            IsCorrect = false,
                            QuestionId = 4,
                            Text = "No"
                        },
                        new
                        {
                            Id = 12,
                            IsCorrect = false,
                            QuestionId = 4,
                            Text = "What?"
                        });
                });

            modelBuilder.Entity("LX.TestPad.DataAccess.Question", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("TestId")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("TestId");

                    b.ToTable("Questions");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            TestId = 1,
                            Text = "It's my first test for test?"
                        },
                        new
                        {
                            Id = 2,
                            TestId = 1,
                            Text = "It's better test?"
                        },
                        new
                        {
                            Id = 3,
                            TestId = 1,
                            Text = "Do you love this test?"
                        },
                        new
                        {
                            Id = 4,
                            TestId = 1,
                            Text = "Do yo like what you see?"
                        },
                        new
                        {
                            Id = 5,
                            TestId = 3,
                            Text = "Do yo like what you see?"
                        });
                });

            modelBuilder.Entity("LX.TestPad.DataAccess.Result", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("Score")
                        .HasColumnType("float");

                    b.Property<int>("TestId")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("TestId");

                    b.ToTable("Results");
                });

            modelBuilder.Entity("LX.TestPad.DataAccess.ResultAnswer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AnswerText")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("QuestionText")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ResultId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ResultId");

                    b.ToTable("ResultAnswers");
                });

            modelBuilder.Entity("LX.TestPad.DataAccess.Test", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Tests");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "It's my first test for test",
                            Name = "My first test"
                        },
                        new
                        {
                            Id = 2,
                            Description = "It's empty test for test",
                            Name = "Empty test"
                        },
                        new
                        {
                            Id = 3,
                            Description = "It's my empty test for test with 1 question and without answer",
                            Name = "My empty test V2.0"
                        });
                });

            modelBuilder.Entity("LX.TestPad.DataAccess.Answer", b =>
                {
                    b.HasOne("LX.TestPad.DataAccess.Question", "Question")
                        .WithMany()
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Question");
                });

            modelBuilder.Entity("LX.TestPad.DataAccess.Question", b =>
                {
                    b.HasOne("LX.TestPad.DataAccess.Test", "Test")
                        .WithMany()
                        .HasForeignKey("TestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Test");
                });

            modelBuilder.Entity("LX.TestPad.DataAccess.Result", b =>
                {
                    b.HasOne("LX.TestPad.DataAccess.Test", "Test")
                        .WithMany()
                        .HasForeignKey("TestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Test");
                });

            modelBuilder.Entity("LX.TestPad.DataAccess.ResultAnswer", b =>
                {
                    b.HasOne("LX.TestPad.DataAccess.Result", "Result")
                        .WithMany()
                        .HasForeignKey("ResultId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Result");
                });
#pragma warning restore 612, 618
        }
    }
}
