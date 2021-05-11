﻿// <auto-generated />
using System;
using EDziekanat.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EDziekanat.EntityFramework.Migrations
{
    [DbContext(typeof(EDziekanatDbContext))]
    partial class EDziekanatDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EDziekanat.Core.DeansOffices.DeansOffice", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("DepartmentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.ToTable("DeansOffices");
                });

            modelBuilder.Entity("EDziekanat.Core.DeansOffices.Operation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("DeansOfficeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DeansOfficeId");

                    b.ToTable("Operations");
                });

            modelBuilder.Entity("EDziekanat.Core.DeansOffices.Reservation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("DeansOfficeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("StudentId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("DeansOfficeId");

                    b.HasIndex("StudentId");

                    b.ToTable("Reservations");
                });

            modelBuilder.Entity("EDziekanat.Core.Departments.Department", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("EDziekanat.Core.Messages.Message", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("DeansOfficeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("StudentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Text")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DeansOfficeId");

                    b.HasIndex("StudentId");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("EDziekanat.Core.Permissions.Permission", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("DisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Permission");

                    b.HasData(
                        new
                        {
                            Id = new Guid("2a1ccb43-fa4f-48ce-b601-d3ab4d611b32"),
                            DisplayName = "Administration access",
                            Name = "Permissions_Administration"
                        },
                        new
                        {
                            Id = new Guid("28126ffd-51c2-4201-939c-b64e3df43b9d"),
                            DisplayName = "Member access",
                            Name = "Permissions_Member_Access"
                        },
                        new
                        {
                            Id = new Guid("86d804bd-d022-49a5-821a-d2240478aac4"),
                            DisplayName = "User read",
                            Name = "Permissions_User_Read"
                        },
                        new
                        {
                            Id = new Guid("8f3de3ec-3851-4ba9-887a-2119f18ae744"),
                            DisplayName = "User create",
                            Name = "Permissions_User_Create"
                        },
                        new
                        {
                            Id = new Guid("068a0171-a141-4eb2-854c-88e43ef9ab7f"),
                            DisplayName = "User update",
                            Name = "Permissions_User_Update"
                        },
                        new
                        {
                            Id = new Guid("70b5c5c3-2267-4f7c-b0f9-7ecc952e04a6"),
                            DisplayName = "User delete",
                            Name = "Permissions_User_Delete"
                        },
                        new
                        {
                            Id = new Guid("80562f50-8a7d-4bcd-8971-6d856bbcbb7f"),
                            DisplayName = "Role read",
                            Name = "Permissions_Role_Read"
                        },
                        new
                        {
                            Id = new Guid("d4d7c0e3-efcf-4dd2-86e7-17d69fda8c75"),
                            DisplayName = "Role create",
                            Name = "Permissions_Role_Create"
                        },
                        new
                        {
                            Id = new Guid("ea003a99-4755-4c19-b126-c5cffbc65088"),
                            DisplayName = "Role update",
                            Name = "Permissions_Role_Update"
                        },
                        new
                        {
                            Id = new Guid("8f76de0b-114a-4df8-a93d-cec927d06a3c"),
                            DisplayName = "Role delete",
                            Name = "Permissions_Role_Delete"
                        });
                });

            modelBuilder.Entity("EDziekanat.Core.Roles.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsSystemDefault")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("Role");

                    b.HasData(
                        new
                        {
                            Id = new Guid("f22bce18-06ec-474a-b9af-a9de2a7b8263"),
                            ConcurrencyStamp = "20ca059c-47e8-44d2-820c-e374d4c6a2c3",
                            IsSystemDefault = true,
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = new Guid("11d14a89-3a93-4d39-a94f-82b823f0d4ce"),
                            ConcurrencyStamp = "064c3ccf-6605-420e-9cdf-65d8413986d0",
                            IsSystemDefault = true,
                            Name = "Employee",
                            NormalizedName = "EMPLOYEE"
                        },
                        new
                        {
                            Id = new Guid("a8856d4e-779c-4a49-8378-6b584c3d38fb"),
                            ConcurrencyStamp = "70eab500-7e8a-406e-b544-47a93963ac1f",
                            IsSystemDefault = true,
                            Name = "Student",
                            NormalizedName = "STUDENT"
                        });
                });

            modelBuilder.Entity("EDziekanat.Core.Roles.RoleClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("RoleClaim");
                });

            modelBuilder.Entity("EDziekanat.Core.Roles.RolePermission", b =>
                {
                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PermissionId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("RoleId", "PermissionId");

                    b.HasIndex("PermissionId");

                    b.ToTable("RolePermission");

                    b.HasData(
                        new
                        {
                            RoleId = new Guid("f22bce18-06ec-474a-b9af-a9de2a7b8263"),
                            PermissionId = new Guid("2a1ccb43-fa4f-48ce-b601-d3ab4d611b32")
                        },
                        new
                        {
                            RoleId = new Guid("f22bce18-06ec-474a-b9af-a9de2a7b8263"),
                            PermissionId = new Guid("28126ffd-51c2-4201-939c-b64e3df43b9d")
                        },
                        new
                        {
                            RoleId = new Guid("f22bce18-06ec-474a-b9af-a9de2a7b8263"),
                            PermissionId = new Guid("86d804bd-d022-49a5-821a-d2240478aac4")
                        },
                        new
                        {
                            RoleId = new Guid("f22bce18-06ec-474a-b9af-a9de2a7b8263"),
                            PermissionId = new Guid("8f3de3ec-3851-4ba9-887a-2119f18ae744")
                        },
                        new
                        {
                            RoleId = new Guid("f22bce18-06ec-474a-b9af-a9de2a7b8263"),
                            PermissionId = new Guid("068a0171-a141-4eb2-854c-88e43ef9ab7f")
                        },
                        new
                        {
                            RoleId = new Guid("f22bce18-06ec-474a-b9af-a9de2a7b8263"),
                            PermissionId = new Guid("70b5c5c3-2267-4f7c-b0f9-7ecc952e04a6")
                        },
                        new
                        {
                            RoleId = new Guid("f22bce18-06ec-474a-b9af-a9de2a7b8263"),
                            PermissionId = new Guid("80562f50-8a7d-4bcd-8971-6d856bbcbb7f")
                        },
                        new
                        {
                            RoleId = new Guid("f22bce18-06ec-474a-b9af-a9de2a7b8263"),
                            PermissionId = new Guid("d4d7c0e3-efcf-4dd2-86e7-17d69fda8c75")
                        },
                        new
                        {
                            RoleId = new Guid("f22bce18-06ec-474a-b9af-a9de2a7b8263"),
                            PermissionId = new Guid("ea003a99-4755-4c19-b126-c5cffbc65088")
                        },
                        new
                        {
                            RoleId = new Guid("f22bce18-06ec-474a-b9af-a9de2a7b8263"),
                            PermissionId = new Guid("8f76de0b-114a-4df8-a93d-cec927d06a3c")
                        },
                        new
                        {
                            RoleId = new Guid("11d14a89-3a93-4d39-a94f-82b823f0d4ce"),
                            PermissionId = new Guid("28126ffd-51c2-4201-939c-b64e3df43b9d")
                        });
                });

            modelBuilder.Entity("EDziekanat.Core.Users.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("DeansOfficeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("DeansOfficeId");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("User");

                    b.HasData(
                        new
                        {
                            Id = new Guid("c41a7761-6645-4e2c-b99d-f9e767b9ac77"),
                            AccessFailedCount = 5,
                            ConcurrencyStamp = "3d527fe6-d18c-41ad-ae75-a572ba6701e2",
                            Email = "admin@mail.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "ADMIN@MAIL.COM",
                            NormalizedUserName = "ADMIN",
                            PasswordHash = "AM4OLBpptxBYmM79lGOX9egzZk3vIQU3d/gFCJzaBjAPXzYIK3tQ2N7X4fcrHtElTw==",
                            PhoneNumberConfirmed = false,
                            TwoFactorEnabled = false,
                            UserName = "Admin"
                        },
                        new
                        {
                            Id = new Guid("4b6d9e45-626d-489a-a8cf-d32d36583af4"),
                            AccessFailedCount = 5,
                            ConcurrencyStamp = "7e042b1e-ac3b-4209-951b-2842747a2d85",
                            Email = "employee@mail.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "EMPLOYEE@MAIL.COM",
                            NormalizedUserName = "PRACOWNIK DZIEKANATU",
                            PasswordHash = "AM4OLBpptxBYmM79lGOX9egzZk3vIQU3d/gFCJzaBjAPXzYIK3tQ2N7X4fcrHtElTw==",
                            PhoneNumberConfirmed = false,
                            TwoFactorEnabled = false,
                            UserName = "Pracownik dziekanatu"
                        },
                        new
                        {
                            Id = new Guid("065e903e-6f7b-42b8-b807-0c4197f9d1bc"),
                            AccessFailedCount = 5,
                            ConcurrencyStamp = "5b8eeb3b-8a69-42c6-bd79-dc772767d68c",
                            Email = "student@mail.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "STUDENT@MAIL.COM",
                            NormalizedUserName = "STUDENT",
                            PasswordHash = "AM4OLBpptxBYmM79lGOX9egzZk3vIQU3d/gFCJzaBjAPXzYIK3tQ2N7X4fcrHtElTw==",
                            PhoneNumberConfirmed = false,
                            TwoFactorEnabled = false,
                            UserName = "Student"
                        });
                });

            modelBuilder.Entity("EDziekanat.Core.Users.UserClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserClaim");
                });

            modelBuilder.Entity("EDziekanat.Core.Users.UserLogin", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("UserLogin");
                });

            modelBuilder.Entity("EDziekanat.Core.Users.UserRole", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("UserRole");

                    b.HasData(
                        new
                        {
                            UserId = new Guid("c41a7761-6645-4e2c-b99d-f9e767b9ac77"),
                            RoleId = new Guid("f22bce18-06ec-474a-b9af-a9de2a7b8263")
                        },
                        new
                        {
                            UserId = new Guid("4b6d9e45-626d-489a-a8cf-d32d36583af4"),
                            RoleId = new Guid("11d14a89-3a93-4d39-a94f-82b823f0d4ce")
                        },
                        new
                        {
                            UserId = new Guid("065e903e-6f7b-42b8-b807-0c4197f9d1bc"),
                            RoleId = new Guid("a8856d4e-779c-4a49-8378-6b584c3d38fb")
                        });
                });

            modelBuilder.Entity("EDziekanat.Core.Users.UserToken", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("UserToken");
                });

            modelBuilder.Entity("EDziekanat.Core.DeansOffices.DeansOffice", b =>
                {
                    b.HasOne("EDziekanat.Core.Departments.Department", "Department")
                        .WithMany("DeansOffices")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EDziekanat.Core.DeansOffices.Operation", b =>
                {
                    b.HasOne("EDziekanat.Core.DeansOffices.DeansOffice", "DeansOffice")
                        .WithMany("Operations")
                        .HasForeignKey("DeansOfficeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EDziekanat.Core.DeansOffices.Reservation", b =>
                {
                    b.HasOne("EDziekanat.Core.DeansOffices.DeansOffice", "DeansOffice")
                        .WithMany("Reservations")
                        .HasForeignKey("DeansOfficeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EDziekanat.Core.Users.User", "Student")
                        .WithMany("Reservations")
                        .HasForeignKey("StudentId");
                });

            modelBuilder.Entity("EDziekanat.Core.Messages.Message", b =>
                {
                    b.HasOne("EDziekanat.Core.DeansOffices.DeansOffice", "DeansOffice")
                        .WithMany("Messages")
                        .HasForeignKey("DeansOfficeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EDziekanat.Core.Users.User", "User")
                        .WithMany("Messages")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EDziekanat.Core.Roles.RoleClaim", b =>
                {
                    b.HasOne("EDziekanat.Core.Roles.Role", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EDziekanat.Core.Roles.RolePermission", b =>
                {
                    b.HasOne("EDziekanat.Core.Permissions.Permission", "Permission")
                        .WithMany("RolePermissions")
                        .HasForeignKey("PermissionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EDziekanat.Core.Roles.Role", "Role")
                        .WithMany("RolePermissions")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EDziekanat.Core.Users.User", b =>
                {
                    b.HasOne("EDziekanat.Core.DeansOffices.DeansOffice", "DeansOffice")
                        .WithMany("Employees")
                        .HasForeignKey("DeansOfficeId");
                });

            modelBuilder.Entity("EDziekanat.Core.Users.UserClaim", b =>
                {
                    b.HasOne("EDziekanat.Core.Users.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EDziekanat.Core.Users.UserLogin", b =>
                {
                    b.HasOne("EDziekanat.Core.Users.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EDziekanat.Core.Users.UserRole", b =>
                {
                    b.HasOne("EDziekanat.Core.Roles.Role", "Role")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EDziekanat.Core.Users.User", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EDziekanat.Core.Users.UserToken", b =>
                {
                    b.HasOne("EDziekanat.Core.Users.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
