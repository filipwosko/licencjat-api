using licencjat_api.Models;
using Microsoft.EntityFrameworkCore;

namespace licencjat_api.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<MountainHostel> MountainHostels { get; set; }

        public DbSet<Criterion> Criteria { get; set; }

        public DbSet<HostelCriterionValue> HostelCriterionValues { get; set; }
    }
}
