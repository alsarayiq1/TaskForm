﻿// <auto-generated />
using System;
using FormPage.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FormPage.Migrations
{
    [DbContext(typeof(Datacontext))]
    partial class DatacontextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("FormPage.Entity.Courses", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CoursesType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PersonInfoId")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("PersonInfoId");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("FormPage.Entity.Experience", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Appreciation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ExpType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PersonInfoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PersonInfoId");

                    b.ToTable("Experience");
                });

            modelBuilder.Entity("FormPage.Entity.PersonInfo", b =>
                {
                    b.Property<int>("PersonInfoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PersonInfoId"));

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nationalism")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhonNum")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Religion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SurName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ThirdName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PersonInfoId");

                    b.ToTable("PersonInfo");
                });

            modelBuilder.Entity("FormPage.Entity.Courses", b =>
                {
                    b.HasOne("FormPage.Entity.PersonInfo", "PersonInfo")
                        .WithMany("Courses")
                        .HasForeignKey("PersonInfoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PersonInfo");
                });

            modelBuilder.Entity("FormPage.Entity.Experience", b =>
                {
                    b.HasOne("FormPage.Entity.PersonInfo", "PersonInfo")
                        .WithMany("Experience")
                        .HasForeignKey("PersonInfoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PersonInfo");
                });

            modelBuilder.Entity("FormPage.Entity.PersonInfo", b =>
                {
                    b.Navigation("Courses");

                    b.Navigation("Experience");
                });
#pragma warning restore 612, 618
        }
    }
}
