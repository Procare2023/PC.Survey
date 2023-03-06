using Microsoft.EntityFrameworkCore;
using PC.Services.Core.Models;

namespace PC.Services.DL.DbContext
{
    public class AppDBContext : AuditableIdentityContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options)
        : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            //change AspNet Users tables names
            var entityTypes = modelBuilder.Model.GetEntityTypes();
            foreach (var entityType in entityTypes)
                modelBuilder.Entity(entityType.ClrType)
                       .ToTable(entityType.GetTableName().Replace("AspNet", ""));
        }

        public DbSet<UserPassword> UserPassword { get; set; }
        public DbSet<UserTransaction> UserTransaction { get; set; }
    }
}
