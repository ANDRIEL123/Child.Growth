﻿// <auto-generated />
using System;
using Child.Growth.src.Infra.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Child.Growth.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20231012192333_addResponsible4")]
    partial class addResponsible4
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Child.Growth.src.Entities.Children", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<bool>("Active")
                        .HasColumnType("bit")
                        .HasColumnName("active");

                    b.Property<string>("Avatar")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("avatar");

                    b.Property<DateTime?>("BirthDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("birth_date");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("created_at");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("modified_at");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("name");

                    b.Property<long>("ResponsibleId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("ResponsibleId");

                    b.ToTable("children", (string)null);
                });

            modelBuilder.Entity("Child.Growth.src.Entities.PatientConsultation", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<float>("CephalicPerimeter")
                        .HasColumnType("real")
                        .HasColumnName("cephalic_perimeter");

                    b.Property<long>("ChildrenId")
                        .HasColumnType("bigint")
                        .HasColumnName("children_id");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("created_at");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2")
                        .HasColumnName("date");

                    b.Property<float>("Height")
                        .HasColumnType("real")
                        .HasColumnName("height");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("modified_at");

                    b.Property<float>("Observations")
                        .HasColumnType("real")
                        .HasColumnName("observations");

                    b.Property<float>("Weight")
                        .HasColumnType("real")
                        .HasColumnName("weight");

                    b.HasKey("Id");

                    b.HasIndex("ChildrenId");

                    b.ToTable("patient_consultation", (string)null);
                });

            modelBuilder.Entity("Child.Growth.src.Entities.Responsible", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime?>("BirthDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("birthDate");

                    b.Property<string>("Cpf")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("cpf");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("created_at");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("email");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("modified_at");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("name");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("phone");

                    b.HasKey("Id");

                    b.ToTable("responsible", (string)null);
                });

            modelBuilder.Entity("Child.Growth.src.Entities.Users", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<bool>("Active")
                        .HasColumnType("bit")
                        .HasColumnName("active");

                    b.Property<string>("Avatar")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("avatar");

                    b.Property<DateTime?>("BirthDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("birth_date");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("created_at");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("email");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("modified_at");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("name");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("password");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("phone");

                    b.Property<short>("Type")
                        .HasColumnType("smallint")
                        .HasColumnName("type");

                    b.HasKey("Id");

                    b.ToTable("users", (string)null);
                });

            modelBuilder.Entity("Child.Growth.src.Entities.Children", b =>
                {
                    b.HasOne("Child.Growth.src.Entities.Responsible", "Responsible")
                        .WithMany("Children")
                        .HasForeignKey("ResponsibleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Responsible");
                });

            modelBuilder.Entity("Child.Growth.src.Entities.PatientConsultation", b =>
                {
                    b.HasOne("Child.Growth.src.Entities.Children", "Children")
                        .WithMany("Consultations")
                        .HasForeignKey("ChildrenId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Children");
                });

            modelBuilder.Entity("Child.Growth.src.Entities.Children", b =>
                {
                    b.Navigation("Consultations");
                });

            modelBuilder.Entity("Child.Growth.src.Entities.Responsible", b =>
                {
                    b.Navigation("Children");
                });
#pragma warning restore 612, 618
        }
    }
}
