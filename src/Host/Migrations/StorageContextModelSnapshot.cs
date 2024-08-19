﻿// <auto-generated />
using System;
using Garuda.Persistences.MsSql;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Garuda.Migrations
{
    [DbContext(typeof(StorageContext))]
    partial class StorageContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Garuda.Domain.Common.Models.Animal", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id");

                    b.Property<int>("Age")
                        .HasColumnType("int")
                        .HasColumnName("age");

                    b.Property<string>("ApprovedBy")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("approved_by");

                    b.Property<DateTime?>("ApprovedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("approved_date");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("created_by");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("created_date");

                    b.Property<string>("DeletedBy")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("deleted_by");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("deleted_date");

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)")
                        .HasColumnName("description");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)")
                        .HasColumnName("gender");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("name");

                    b.Property<string>("PermittedBy")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("permitted_by");

                    b.Property<DateTime?>("PermittedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("permitted_date");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("price");

                    b.Property<string>("RejectedBy")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("rejected_by");

                    b.Property<DateTime?>("RejectedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("rejected_date");

                    b.Property<string>("RejectionReason")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)")
                        .HasColumnName("rejection_reason");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("status");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("type");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("updated_by");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("updated_date");

                    b.HasKey("Id");

                    b.ToTable("animals", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("47c49fdd-ad89-4acb-99e1-0cf45eae1910"),
                            Age = 5,
                            ApprovedBy = "admin@example.com",
                            ApprovedDate = new DateTime(2024, 8, 19, 1, 58, 1, 368, DateTimeKind.Utc).AddTicks(2021),
                            CreatedBy = "",
                            Description = "A majestic lion.",
                            Gender = "Male",
                            Name = "Lion",
                            PermittedBy = "admin@example.com",
                            PermittedDate = new DateTime(2024, 8, 19, 1, 58, 1, 368, DateTimeKind.Utc).AddTicks(2026),
                            Price = 1500.00m,
                            Status = "Approved",
                            Type = "Mammal"
                        },
                        new
                        {
                            Id = new Guid("dc69b089-fa6d-4d97-9a9e-cbdbd23cf84d"),
                            Age = 2,
                            CreatedBy = "",
                            Description = "A colorful parrot.",
                            Gender = "Female",
                            Name = "Parrot",
                            Price = 300.00m,
                            Status = "Pending",
                            Type = "Bird"
                        });
                });

            modelBuilder.Entity("Garuda.Domain.Common.Models.AppConfiguration", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("created_by");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("created_date");

                    b.Property<string>("DeletedBy")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("deleted_by");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("deleted_date");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Key")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("key");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("updated_by");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("updated_date");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasMaxLength(8000)
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("value");

                    b.HasKey("Id");

                    b.ToTable("app_configurations", (string)null);
                });

            modelBuilder.Entity("Garuda.Domain.Common.Models.Menu", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)")
                        .HasColumnName("code");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("created_by");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("created_date");

                    b.Property<string>("DeletedBy")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("deleted_by");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("deleted_date");

                    b.Property<string>("IconClass")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("icon_class");

                    b.Property<byte>("Level")
                        .HasColumnType("tinyint")
                        .HasColumnName("level");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("name");

                    b.Property<byte>("Order")
                        .HasColumnType("tinyint")
                        .HasColumnName("order");

                    b.Property<Guid?>("ParentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Slug")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("slug");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("updated_by");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("updated_date");

                    b.HasKey("Id");

                    b.ToTable("menus", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("8f735cdf-bd01-4ae3-89c6-b122bdd59b8b"),
                            Code = "dash",
                            CreatedBy = "System",
                            CreatedDate = new DateTime(2022, 6, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IconClass = "icon-home",
                            Level = (byte)0,
                            Name = "Dashboard",
                            Order = (byte)0,
                            ParentId = new Guid("00000000-0000-0000-0000-000000000000"),
                            Slug = "/Dashboard"
                        },
                        new
                        {
                            Id = new Guid("77118193-d70c-4e36-97a0-683b9e825569"),
                            Code = "act",
                            CreatedBy = "System",
                            CreatedDate = new DateTime(2022, 6, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IconClass = "icon-notes",
                            Level = (byte)0,
                            Name = "My Activity",
                            Order = (byte)2,
                            ParentId = new Guid("00000000-0000-0000-0000-000000000000"),
                            Slug = "/IndexMyActivity"
                        },
                        new
                        {
                            Id = new Guid("7f2302be-efd5-43f1-b6c9-8e8886c8460c"),
                            Code = "doc",
                            CreatedBy = "System",
                            CreatedDate = new DateTime(2022, 6, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IconClass = "icon-file",
                            Level = (byte)0,
                            Name = "My Document",
                            Order = (byte)3,
                            ParentId = new Guid("00000000-0000-0000-0000-000000000000"),
                            Slug = ""
                        },
                        new
                        {
                            Id = new Guid("f0663ca2-ffb8-42c2-b022-38479c7c84af"),
                            Code = "set",
                            CreatedBy = "System",
                            CreatedDate = new DateTime(2022, 6, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IconClass = "icon-cog-outline",
                            Level = (byte)0,
                            Name = "Settings",
                            Order = (byte)5,
                            ParentId = new Guid("00000000-0000-0000-0000-000000000000"),
                            Slug = ""
                        },
                        new
                        {
                            Id = new Guid("5026c85e-04f4-4d65-9fd2-bff26ad90013"),
                            Code = "user",
                            CreatedBy = "System",
                            CreatedDate = new DateTime(2022, 6, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IconClass = "icon-user",
                            Level = (byte)1,
                            Name = "User Management",
                            Order = (byte)0,
                            ParentId = new Guid("f0663ca2-ffb8-42c2-b022-38479c7c84af"),
                            Slug = "/IndexUser"
                        },
                        new
                        {
                            Id = new Guid("f45e2f20-e6c3-4d82-b0d9-e91469103672"),
                            Code = "sec",
                            CreatedBy = "System",
                            CreatedDate = new DateTime(2022, 6, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IconClass = "",
                            Level = (byte)1,
                            Name = "Manage Security Group",
                            Order = (byte)1,
                            ParentId = new Guid("f0663ca2-ffb8-42c2-b022-38479c7c84af"),
                            Slug = "/IndexSecurity"
                        });
                });

            modelBuilder.Entity("Garuda.Domain.Common.Models.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("created_by");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("created_date");

                    b.Property<string>("DeletedBy")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("deleted_by");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("deleted_date");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)")
                        .HasColumnName("name");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("updated_by");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("updated_date");

                    b.HasKey("Id");

                    b.ToTable("roles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("9ee09365-b140-4bc0-a5a1-79098ddbeed7"),
                            CreatedBy = "System",
                            CreatedDate = new DateTime(2022, 6, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Administrator"
                        },
                        new
                        {
                            Id = new Guid("91e4aa02-8c2f-4074-9a47-5e33d7ab641c"),
                            CreatedBy = "System",
                            CreatedDate = new DateTime(2023, 6, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Buyer"
                        },
                        new
                        {
                            Id = new Guid("f5105f3d-579f-42d8-be30-5b78249cba45"),
                            CreatedBy = "System",
                            CreatedDate = new DateTime(2023, 6, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Seller"
                        });
                });

            modelBuilder.Entity("Garuda.Domain.Common.Models.RoleMenuPermission", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id");

                    b.Property<bool>("CanCreate")
                        .HasColumnType("bit")
                        .HasColumnName("can_create");

                    b.Property<bool>("CanDelete")
                        .HasColumnType("bit")
                        .HasColumnName("can_delete");

                    b.Property<bool>("CanUpdate")
                        .HasColumnType("bit")
                        .HasColumnName("can_update");

                    b.Property<bool>("CanView")
                        .HasColumnType("bit")
                        .HasColumnName("can_view");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("created_by");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("created_date");

                    b.Property<string>("DeletedBy")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("deleted_by");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("deleted_date");

                    b.Property<Guid>("MenuId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("menu_id");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("role_id");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("updated_by");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("updated_date");

                    b.HasKey("Id");

                    b.HasIndex("MenuId");

                    b.HasIndex("RoleId");

                    b.ToTable("role_menu_permissions", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("64f03301-c574-46c2-b1e6-2922eaaa826a"),
                            CanCreate = false,
                            CanDelete = false,
                            CanUpdate = false,
                            CanView = true,
                            CreatedBy = "System",
                            CreatedDate = new DateTime(2022, 6, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            MenuId = new Guid("8f735cdf-bd01-4ae3-89c6-b122bdd59b8b"),
                            RoleId = new Guid("9ee09365-b140-4bc0-a5a1-79098ddbeed7")
                        },
                        new
                        {
                            Id = new Guid("07e87c49-180f-4f00-99e2-7322c0638a2d"),
                            CanCreate = false,
                            CanDelete = false,
                            CanUpdate = false,
                            CanView = true,
                            CreatedBy = "System",
                            CreatedDate = new DateTime(2022, 6, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            MenuId = new Guid("f0663ca2-ffb8-42c2-b022-38479c7c84af"),
                            RoleId = new Guid("9ee09365-b140-4bc0-a5a1-79098ddbeed7")
                        },
                        new
                        {
                            Id = new Guid("702e4653-2abc-41f1-86f5-c1543ab7d585"),
                            CanCreate = true,
                            CanDelete = true,
                            CanUpdate = true,
                            CanView = true,
                            CreatedBy = "System",
                            CreatedDate = new DateTime(2022, 6, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            MenuId = new Guid("5026c85e-04f4-4d65-9fd2-bff26ad90013"),
                            RoleId = new Guid("9ee09365-b140-4bc0-a5a1-79098ddbeed7")
                        },
                        new
                        {
                            Id = new Guid("0281ec0d-8fc8-411d-80ab-644a94cf02da"),
                            CanCreate = true,
                            CanDelete = true,
                            CanUpdate = true,
                            CanView = true,
                            CreatedBy = "System",
                            CreatedDate = new DateTime(2022, 6, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            MenuId = new Guid("77118193-d70c-4e36-97a0-683b9e825569"),
                            RoleId = new Guid("9ee09365-b140-4bc0-a5a1-79098ddbeed7")
                        },
                        new
                        {
                            Id = new Guid("437ec283-d081-46f4-9f36-a1ffe8753566"),
                            CanCreate = false,
                            CanDelete = false,
                            CanUpdate = false,
                            CanView = true,
                            CreatedBy = "System",
                            CreatedDate = new DateTime(2022, 6, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            MenuId = new Guid("f45e2f20-e6c3-4d82-b0d9-e91469103672"),
                            RoleId = new Guid("9ee09365-b140-4bc0-a5a1-79098ddbeed7")
                        });
                });

            modelBuilder.Entity("Garuda.Domain.Common.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("created_by");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("created_date");

                    b.Property<string>("DeletedBy")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("deleted_by");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("deleted_date");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("email");

                    b.Property<string>("Fullname")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("fullname");

                    b.Property<DateTime?>("LastLogin")
                        .HasColumnType("datetime2")
                        .HasColumnName("last_login");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("updated_by");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("updated_date");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)")
                        .HasColumnName("username");

                    b.HasKey("Id");

                    b.ToTable("users", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("81314787-537b-474f-999a-9152c9703bbb"),
                            CreatedBy = "System",
                            CreatedDate = new DateTime(2022, 6, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "system@system.co",
                            Fullname = "System",
                            Password = "$2a$11$ijs7c9x9yHz1oeZ95CF76u1CGALKC3sVeMpGyfzA0U7gWlpH7tmhO",
                            Username = "systemadmin"
                        },
                        new
                        {
                            Id = new Guid("fa3876d9-b8ce-4029-9df6-2e8ee94a3d78"),
                            CreatedBy = "System",
                            CreatedDate = new DateTime(2022, 6, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "systemreserve@system.co",
                            Fullname = "System Admin Reserve",
                            Password = "$2a$11$ijs7c9x9yHz1oeZ95CF76u1CGALKC3sVeMpGyfzA0U7gWlpH7tmhO",
                            Username = "systemadminreserve"
                        },
                        new
                        {
                            Id = new Guid("c3e20f8e-92a7-4c19-90a2-7fb66fd1b6b1"),
                            CreatedBy = "System",
                            CreatedDate = new DateTime(2024, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "buyer@platform.com",
                            Fullname = "Buyer User",
                            Password = "$2a$12$7hXoj0eKxTvhwo9qKYZdQOE1aiHaqHdhDlBjSzAqAjSs1u0ILF.EG",
                            Username = "buyer"
                        },
                        new
                        {
                            Id = new Guid("f7a74c57-8968-4b3a-91e5-38b2f6aef91c"),
                            CreatedBy = "System",
                            CreatedDate = new DateTime(2024, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "seller@platform.com",
                            Fullname = "Seller User",
                            Password = "$2a$12$lVXtNCUzJaFgAmJ.sJvSheGHJlZuQG96ZZGReyJn9lxg2WEbuAYDW",
                            Username = "seller"
                        });
                });

            modelBuilder.Entity("Garuda.Domain.Common.Models.UserRole", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("created_by");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("created_date");

                    b.Property<string>("DeletedBy")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("deleted_by");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("deleted_date");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("role_id");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("updated_by");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("updated_date");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("user_id");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId");

                    b.ToTable("user_groups", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("ec211d37-2400-4877-8696-62ac17faeecb"),
                            CreatedBy = "System",
                            CreatedDate = new DateTime(2022, 6, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            RoleId = new Guid("9ee09365-b140-4bc0-a5a1-79098ddbeed7"),
                            UserId = new Guid("81314787-537b-474f-999a-9152c9703bbb")
                        },
                        new
                        {
                            Id = new Guid("12ae4f23-8457-4e71-898a-4d36aa2611b2"),
                            CreatedBy = "System",
                            CreatedDate = new DateTime(2023, 6, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            RoleId = new Guid("91e4aa02-8c2f-4074-9a47-5e33d7ab641c"),
                            UserId = new Guid("c3e20f8e-92a7-4c19-90a2-7fb66fd1b6b1")
                        },
                        new
                        {
                            Id = new Guid("d8ffb78d-185c-4d2a-9ad3-52577dcd9392"),
                            CreatedBy = "System",
                            CreatedDate = new DateTime(2023, 6, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            RoleId = new Guid("f5105f3d-579f-42d8-be30-5b78249cba45"),
                            UserId = new Guid("f7a74c57-8968-4b3a-91e5-38b2f6aef91c")
                        });
                });

            modelBuilder.Entity("Garuda.Domain.Common.Models.UserSession", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("created_by");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("created_date");

                    b.Property<DateTime>("DateExpired")
                        .HasColumnType("datetime2")
                        .HasColumnName("date_expired");

                    b.Property<DateTime?>("DateRevoked")
                        .HasColumnType("datetime2")
                        .HasColumnName("date_revoked");

                    b.Property<string>("DeletedBy")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("deleted_by");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("deleted_date");

                    b.Property<string>("RefreshToken")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .IsUnicode(false)
                        .HasColumnType("varchar(1000)")
                        .HasColumnName("refresh_token");

                    b.Property<string>("Token")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .IsUnicode(false)
                        .HasColumnType("varchar(1000)")
                        .HasColumnName("token");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("updated_by");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("updated_date");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("user_id");

                    b.HasKey("Id");

                    b.ToTable("user_sessions", (string)null);
                });

            modelBuilder.Entity("Garuda.Persistences.Framework.Models.Audits.AuditLog", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id");

                    b.Property<string>("Action")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("action");

                    b.Property<string>("ClassName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("class_name");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("created_by");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("created_date");

                    b.Property<string>("DeletedBy")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("deleted_by");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("deleted_date");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("description");

                    b.Property<string>("NewValue")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("new_value");

                    b.Property<string>("OldValue")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("old_value");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("updated_by");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("updated_date");

                    b.HasKey("Id");

                    b.ToTable("audit_logs", (string)null);
                });

            modelBuilder.Entity("Garuda.Domain.Common.Models.RoleMenuPermission", b =>
                {
                    b.HasOne("Garuda.Domain.Common.Models.Menu", "Menu")
                        .WithMany("RoleMenuPermissions")
                        .HasForeignKey("MenuId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Garuda.Domain.Common.Models.Role", "Role")
                        .WithMany("RoleMenuPermissions")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Menu");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("Garuda.Domain.Common.Models.UserRole", b =>
                {
                    b.HasOne("Garuda.Domain.Common.Models.Role", "Role")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Garuda.Domain.Common.Models.User", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Garuda.Domain.Common.Models.Menu", b =>
                {
                    b.Navigation("RoleMenuPermissions");
                });

            modelBuilder.Entity("Garuda.Domain.Common.Models.Role", b =>
                {
                    b.Navigation("RoleMenuPermissions");

                    b.Navigation("UserRoles");
                });

            modelBuilder.Entity("Garuda.Domain.Common.Models.User", b =>
                {
                    b.Navigation("UserRoles");
                });
#pragma warning restore 612, 618
        }
    }
}
