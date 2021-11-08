using Forum.Core;
using Forum.Core.Messages;
using Forum.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Forum.Infra
{
    public class ForumContext : DbContext ,IUnitOfWork
    {

        public ForumContext(DbContextOptions<ForumContext> options):base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Ranking> Rankings { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<Comments> Comments { get; set; }
        public DbSet<Area> Areas { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var property in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e=>e.GetProperties().Where(p=>p.ClrType == typeof(string))))
                property.SetColumnType("varchar(100)");

            //say to EF ignore the Event class
            modelBuilder.Ignore<Event>();

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ForumContext).Assembly);

            foreach (var relationship in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetForeignKeys()))
                relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;

            base.OnModelCreating(modelBuilder);
        }

        public async Task<bool> Commit()
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry=>entry.Entity.GetType().GetProperty("CreationDate") != null))
            {
                if (entry.State == EntityState.Added)
                     entry.Property("CreationDate").CurrentValue = DateTime.Now;

                if (entry.State == EntityState.Modified)
                     entry.Property("CreationDate").IsModified = false;

            }
            return await base.SaveChangesAsync() > 0;
        }
    }
}
