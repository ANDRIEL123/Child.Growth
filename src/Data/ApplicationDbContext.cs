using Child.Growth.src.Entities;
using Microsoft.EntityFrameworkCore;

namespace Child.Growth.src.Data
{
    public class ApplicationDbContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options,
            IConfiguration configuration
        ) : base(options)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                string connectionString = _configuration.GetConnectionString("DefaultConnection");
                optionsBuilder.UseSqlServer(connectionString, options =>
                {
                    options.EnableRetryOnFailure();
                });
            }
        }

        public DbSet<Users> Users { get; set; }
    }
}