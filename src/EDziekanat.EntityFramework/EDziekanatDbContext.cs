using System;
using EDziekanat.Core.DeansOffices;
using EDziekanat.Core.Departments;
using EDziekanat.Core.Messages;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EDziekanat.Core.Permissions;
using EDziekanat.Core.Roles;
using EDziekanat.Core.Users;

namespace EDziekanat.EntityFramework
{
    public class EDziekanatDbContext : IdentityDbContext<User, Role, Guid, UserClaim, UserRole, UserLogin, RoleClaim, UserToken>
    {
        public EDziekanatDbContext(DbContextOptions options)
            : base(options)
        {

        }

        public DbSet<Permission> Permissions { get; set; }
        public DbSet<RolePermission> RolePermissions { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<DeansOffice> DeansOffices { get; set; }
        public DbSet<Operation> Operations { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Message> Messages { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Permission>()
                .ToTable("Permission")
                .HasData(SeedData.BuildPermissions());

            modelBuilder.Entity<Role>().ToTable("Role")
                .HasData(SeedData.BuildApplicationRoles());

            modelBuilder.Entity<User>().ToTable("User")
                .HasData(SeedData.BuildApplicationUsers());

            modelBuilder.Entity((Action<EntityTypeBuilder<RolePermission>>)(b =>
            {
                b.ToTable("RolePermission");
                b.HasKey(rp => new { rp.RoleId, rp.PermissionId });

                b.HasOne(rp => rp.Role)
                    .WithMany(r => r.RolePermissions)
                    .HasForeignKey(pt => pt.RoleId);

                b.HasOne(rp => rp.Permission)
                    .WithMany(p => p.RolePermissions)
                    .HasForeignKey(rp => rp.PermissionId);

                b.HasData(SeedData.BuildRolePermissions());
            }));

            modelBuilder.Entity((Action<EntityTypeBuilder<UserRole>>)(b =>
            {
                b.ToTable("UserRole");

                b.HasOne(ur => ur.User)
                    .WithMany(u => u.UserRoles)
                    .HasForeignKey(ur => ur.UserId);

                b.HasOne(ur => ur.Role)
                    .WithMany(r => r.UserRoles)
                    .HasForeignKey(ur => ur.RoleId);

                b.HasData(SeedData.BuildApplicationUserRoles());
            }));

            modelBuilder.Entity<UserClaim>().ToTable("UserClaim");
            modelBuilder.Entity<UserLogin>().ToTable("UserLogin");
            modelBuilder.Entity<RoleClaim>().ToTable("RoleClaim");
            modelBuilder.Entity<UserToken>().ToTable("UserToken");

            modelBuilder.Entity<User>()
                .HasOne<DeansOffice>(e => e.DeansOffice)
                .WithMany(d => d.Users)
                .HasForeignKey(u => u.DeansOfficeId)
                .IsRequired(false);

            modelBuilder.Entity<Operation>()
                .HasOne<DeansOffice>(o => o.DeansOffice)
                .WithMany(d => d.Operations)
                .HasForeignKey(o => o.DeansOfficeId);

            modelBuilder.Entity<Reservation>()
                .HasOne<User>(r => r.Student)
                .WithMany(u => u.Reservations)
                .HasForeignKey(u => u.StudentId)
                .IsRequired(false);

            modelBuilder.Entity<Reservation>()
                .HasOne<DeansOffice>(r => r.DeansOffice)
                .WithMany(d => d.Reservations)
                .HasForeignKey(u => u.DeansOfficeId);

            modelBuilder.Entity<Message>()
                .HasOne<User>(m => m.User)
                .WithMany(u => u.Messages)
                .HasForeignKey(u => u.StudentId);

            modelBuilder.Entity<Message>()
                .HasOne<DeansOffice>(m => m.DeansOffice)
                .WithMany(u => u.Messages)
                .HasForeignKey(u => u.DeansOfficeId);

            modelBuilder.Entity<DeansOffice>()
                .HasOne<Department>(d => d.Department)
                .WithMany(u => u.DeansOffices)
                .HasForeignKey(u => u.DepartmentId);
        }
    }
}
