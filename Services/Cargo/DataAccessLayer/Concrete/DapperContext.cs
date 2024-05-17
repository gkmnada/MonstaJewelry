using EntityLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using System.Data;

namespace DataAccessLayer.Concrete
{
    public class DapperContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("");
        }

        public DbSet<CargoCompany> cargo_company { get; set; }
        public DbSet<CargoCustomer> cargo_customer { get; set; }
        public DbSet<CargoDetail> cargo_detail { get; set; }
        public DbSet<CargoOperation> cargo_operation { get; set; }

        public IDbConnection CreateConnection() => new NpgsqlConnection("");
    }
}
