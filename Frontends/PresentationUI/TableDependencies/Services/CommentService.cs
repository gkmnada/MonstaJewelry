using System.Data.SqlClient;

namespace PresentationUI.TableDependencies.Services
{
    public class CommentService : ICommentService
    {
        private readonly string connectionString;

        public CommentService(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public int GetCommentCount(string id)
        {
            int count = 0;

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT COUNT(*) FROM UserComment WHERE ProductID = @productID";
                var cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@productID", id);
                count = (int)cmd.ExecuteScalar();
            }

            return count;
        }
    }
}
