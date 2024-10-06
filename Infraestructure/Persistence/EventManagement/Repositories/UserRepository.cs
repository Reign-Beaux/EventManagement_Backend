using Domain.Entities.EventManagement.Users;
using Domain.Entities.EventManagement.Users.Repository;
using Domain.ValueObjects;
using Infraestructure.Abstractions;

namespace Infraestructure.Persistence.EventManagement.Repositories
{
    public sealed class UserRepository(IDbTransaction dbTransaction) : RepositoryAbstraction(dbTransaction), IUserRepository
    {

        public async Task<List<User>> Get()
        {
            var spString = "usp_Users_GET";
            return (await _dbConnection.QueryAsync<User>(
                spString,
                commandType: CommandType.StoredProcedure,
                transaction: _dbTransaction)).ToList();
        }

        public async Task<User?> GetByEmail(string email)
        {
            var spString = "usp_Users_GET";
            return await _dbConnection.QuerySingleOrDefaultAsync<User>(
                spString,
                new { Email = email },
                commandType: CommandType.StoredProcedure,
                transaction: _dbTransaction);
        }

        public async Task<User?> GetByUsername(string username)
        {
            var spString = "usp_Users_GET";
            return await _dbConnection.QuerySingleOrDefaultAsync<User>(
                spString,
                new { Username = username },
                commandType: CommandType.StoredProcedure,
                transaction: _dbTransaction);
        }

        public async Task Insert(User user)
        {
            var spString = "usp_Users_GET";
            await _dbConnection.ExecuteAsync(spString, )
        }

        public Task Update(User user)
        {
            throw new NotImplementedException();
        }
        public Task Delete(Guid Id)
        {
            throw new NotImplementedException();
        }
    }
}
