using Domain.Entities.Users;
using Infraestructure.Abstractions;

namespace Infraestructure.Persistence.EventManagement.Repositories
{
    public sealed class UserRepository(IDbTransaction dbTransaction) : RepositoryAbstraction(dbTransaction), IUserRepository
    {
        public async Task<User> GetByEmail(string email)
        {
            var spString = "usp_Users_GET";
            return await _dbConnection.QuerySingleOrDefaultAsync<User>(
                spString,
                new { Email = email },
                commandType: CommandType.StoredProcedure,
                transaction: _dbTransaction);
        }

        public async Task<User> GetByUsername(string username)
        {
            var spString = "usp_Users_GET";
            return await _dbConnection.QuerySingleOrDefaultAsync<User>(
                spString,
                new { Username = username },
                commandType: CommandType.StoredProcedure,
                transaction: _dbTransaction);
        }
    }
}
