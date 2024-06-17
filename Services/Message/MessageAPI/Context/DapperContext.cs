using MessageAPI.Entities;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using System.Data;

namespace MessageAPI.Context
{
    public class DapperContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Server=localhost;Port=5434;Database=message_database;User Id=postgres;Password=Mamakasml06;");
        }

        public DbSet<UserMessage> user_message { get; set; }

        public IDbConnection CreateConnection() => new NpgsqlConnection("Server=localhost;Port=5434;Database=message_database;User Id=postgres;Password=Mamakasml06;");
    }
}
