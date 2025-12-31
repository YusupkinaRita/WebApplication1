using Microsoft.EntityFrameworkCore;

namespace WebApplication1
{
    public class AppContext(DbContextOptions<AppContext> options) : DbContext(options)
    {
        public DbSet<Account> Accounts { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity =>
            {
                entity.HasKey(a => a.Id);
                entity.Property(a => a.Login).IsRequired().HasMaxLength(50);
                entity.Property(a => a.Name).IsRequired().HasMaxLength(100);
                entity.Property(a => a.PasswordHash).IsRequired();
                entity.HasIndex(a => a.Login).IsUnique(); // Уникальный логин
            });
            base.OnModelCreating(modelBuilder);
        }
    }
}
