using Dapper;
using MessageAPI.Context;
using MessageAPI.Dtos.UserMessageDto;

namespace MessageAPI.Services.UserMessageServices
{
    public class MessageService : IMessageService
    {
        private readonly DapperContext _dapperContext;

        public MessageService(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }

        public async Task CreateMessageAsync(CreateMessageDto createMessageDto)
        {
            string query = "insert into user_message (name, email, subject, message, created_at, status) values (@name, @email, @subject, @message, @created_at, @status)";
            var parameters = new DynamicParameters();
            parameters.Add("@name", createMessageDto.name);
            parameters.Add("@email", createMessageDto.email);
            parameters.Add("@subject", createMessageDto.subject);
            parameters.Add("@message", createMessageDto.message);
            parameters.Add("@created_at", DateTime.Now);
            parameters.Add("@status", false);
            using (var connection = _dapperContext.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task DeleteMessageAsync(int id)
        {
            string query = "delete from user_message where message_id = @message_id";
            var parameters = new DynamicParameters();
            parameters.Add("@message_id", id);
            using (var connection = _dapperContext.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<GetMessageDto> GetMessageAsync(int id)
        {
            string query = "select * from user_message where message_id = @message_id";
            var parameters = new DynamicParameters();
            parameters.Add("@message_id", id);
            using (var connection = _dapperContext.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<GetMessageDto>(query, parameters);
                return values;
            }
        }

        public async Task<List<ResultMessageDto>> ListMessageAsync()
        {
            string query = "select * from user_message";
            using (var connection = _dapperContext.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultMessageDto>(query);
                return values.ToList();
            }
        }

        public async Task UpdateMessageAsync(UpdateMessageDto updateMessageDto)
        {
            string query = "update user_message set name = @name, email = @email, subject = @subject, message = @message, status = @status where message_id = @message_id";
            var parameters = new DynamicParameters();
            parameters.Add("@name", updateMessageDto.name);
            parameters.Add("@email", updateMessageDto.email);
            parameters.Add("@subject", updateMessageDto.subject);
            parameters.Add("@message", updateMessageDto.message);
            parameters.Add("@status", updateMessageDto.status);
            parameters.Add("@message_id", updateMessageDto.message_id);
            using (var connection = _dapperContext.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}
