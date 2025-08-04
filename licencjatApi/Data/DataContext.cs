using licencjatApi.Models;
using Microsoft.EntityFrameworkCore;

namespace licencjatApi.Data
{
    public class DataContext : DbContext
    {
        public DbSet<MountainHostel> MountainHostels { get; set; }
        public DbSet<Criterion> Criteria { get; set; }
        public DbSet<HostelCriterionValue> HostelCriterionValues { get; set; }
        public DbSet<Parameter> Parameters { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HostelCriterionValue>(e =>
            {
                e.HasIndex(p => new { p.CriterionId, p.MountainHostelId })
                    .IsUnique();

                e.ToTable(tb => tb.HasCheckConstraint("CK_HostelCriterionValue_Value_NonNegative", "Value >= 0"));
            });

            modelBuilder.Entity<MountainHostel>()
                .HasIndex(p => p.Name)
                .IsUnique();

            modelBuilder.Entity<Parameter>()
                .HasIndex(p => p.Key)
                .IsUnique();

            modelBuilder.Entity<Criterion>()
                .HasIndex(p => p.Name)
                .IsUnique();

            modelBuilder.Entity<Parameter>()
                .HasData(new Parameter { Id = 1, Key = "MethodName", Description = "Nazwa metody używanej przez program", Value = "" });
        }
    }
}