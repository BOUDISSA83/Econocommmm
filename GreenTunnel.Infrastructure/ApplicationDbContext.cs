﻿

using GreenTunnel.Core.Entities;
using GreenTunnel.Core.Interfaces;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GreenTunnel.Infrastructure
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {
        public string CurrentUserId { get; set; }
        public DbSet<Factory> Factories { get; set; }
        public DbSet<Workplace> Workplaces { get; set; }
        public DbSet<Workspace> Workspaces { get; set; }
        public DbSet<Moulds> Moulds { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Description> Descriptions { get; set; }
        public DbSet<InputType> InputTypes { get; set; }
        public DbSet<Test> Tests { get; set; }
        public DbSet<TestType> TestTypes { get; set; }
        public DbSet<Compliance> Compliances { get; set; }

        public ApplicationDbContext(DbContextOptions options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            const string priceDecimalType = "decimal(18,2)";

            builder.Entity<ApplicationUser>().HasMany(u => u.Claims).WithOne().HasForeignKey(c => c.UserId).IsRequired().OnDelete(DeleteBehavior.Cascade);
            builder.Entity<ApplicationUser>().HasMany(u => u.Roles).WithOne().HasForeignKey(r => r.UserId).IsRequired().OnDelete(DeleteBehavior.Cascade);

            builder.Entity<ApplicationRole>().HasMany(r => r.Claims).WithOne().HasForeignKey(c => c.RoleId).IsRequired().OnDelete(DeleteBehavior.Cascade);
            builder.Entity<ApplicationRole>().HasMany(r => r.Users).WithOne().HasForeignKey(r => r.RoleId).IsRequired().OnDelete(DeleteBehavior.Cascade);
          
            //builder.Entity<Test>().Property(p => p.Name).HasMaxLength(256).IsRequired();
            //builder.Entity<TestType>().Property(p => p.Name).HasMaxLength(200).IsRequired();


            //builder.Entity<Compliance>().Property(p => p.Name).HasMaxLength(100).IsRequired();
            //builder.Entity<Compliance>().Property(p => p.Type).HasMaxLength(100).IsRequired();
            //builder.Entity<Compliance>().Property(p => p.status).HasMaxLength(100).IsRequired();
        }

        public override int SaveChanges()
        {
            UpdateAuditEntities();
            return base.SaveChanges();
        }

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            UpdateAuditEntities();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            UpdateAuditEntities();
            return base.SaveChangesAsync(cancellationToken);
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            UpdateAuditEntities();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        private void UpdateAuditEntities()
        {
            var modifiedEntries = ChangeTracker.Entries()
                .Where(x => x.Entity is IAuditableEntity && (x.State == EntityState.Added || x.State == EntityState.Modified));

            foreach (var entry in modifiedEntries)
            {
                var entity = (IAuditableEntity)entry.Entity;
                var now = DateTime.UtcNow;

                if (entry.State == EntityState.Added)
                {
                    entity.CreatedDate = now;
                    entity.CreatedBy = CurrentUserId;
                }
                else
                {
                    base.Entry(entity).Property(x => x.CreatedBy).IsModified = false;
                    base.Entry(entity).Property(x => x.CreatedDate).IsModified = false;
                }

                entity.UpdatedDate = now;
                entity.UpdatedBy = CurrentUserId;
            }
        }
    }
}