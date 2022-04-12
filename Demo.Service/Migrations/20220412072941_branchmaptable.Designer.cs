﻿// <auto-generated />
using Demo.Service.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Demo.Service.Migrations
{
    [DbContext(typeof(DemoDbContext))]
    [Migration("20220412072941_branchmaptable")]
    partial class branchmaptable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Demo.Service.Model.Branch", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Branch");
                });

            modelBuilder.Entity("Demo.Service.Model.EmpBranchMap", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("BranchID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("EmployeeID")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("BranchID");

                    b.HasIndex("EmployeeID");

                    b.ToTable("EmpBranchMap");
                });

            modelBuilder.Entity("Demo.Service.Model.EmpRoleMap", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("EmployeeID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleID")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeID");

                    b.HasIndex("RoleID");

                    b.ToTable("EmpRoleMap");
                });

            modelBuilder.Entity("Demo.Service.Model.Employee", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("EmailID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Employee");
                });

            modelBuilder.Entity("Demo.Service.Model.Role", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Role");
                });

            modelBuilder.Entity("Demo.Service.Model.EmpBranchMap", b =>
                {
                    b.HasOne("Demo.Service.Model.Branch", "Branches")
                        .WithMany()
                        .HasForeignKey("BranchID");

                    b.HasOne("Demo.Service.Model.Employee", "Employees")
                        .WithMany()
                        .HasForeignKey("EmployeeID");
                });

            modelBuilder.Entity("Demo.Service.Model.EmpRoleMap", b =>
                {
                    b.HasOne("Demo.Service.Model.Employee", "Employees")
                        .WithMany()
                        .HasForeignKey("EmployeeID");

                    b.HasOne("Demo.Service.Model.Role", "Roles")
                        .WithMany()
                        .HasForeignKey("RoleID");
                });
#pragma warning restore 612, 618
        }
    }
}
