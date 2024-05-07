using CommentAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace CommentAPI.Context
{
    public class CommentContext : DbContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public CommentContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("DefaultConnection");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }

        public DbSet<UserComment> UserComment { get; set; }
    }
}
