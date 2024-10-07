using Domain.Entities.EventManagement.Users;
using Domain.Entities.EventManagement.Users.Repository;
using Domain.Entities.EventManagement.Users.Repository.Parameters;
using Infraestructure.Abstractions;

namespace Infraestructure.Persistence.EventManagement.Repositories
{
    public sealed class UserRepository(IDbTransaction dbTransaction) : RepositoryAbstraction(dbTransaction), IUserRepository
    {

        public async Task<List<User>> Get()
            => await QueryAsync<User>(spString: "usp_Users_GET");

        public async Task<User?> GetByEmail(string email)
            => await QuerySingleOrDefaultAsync<User>(spString: "usp_Users_GET", parameters: new { Email = email });

        public async Task<User?> GetByUsername(string username)
            => await QuerySingleOrDefaultAsync<User>(spString: "usp_Users_GET", parameters: new { Username = username });

        public async Task Insert(UserInsertParameters parameters)
            => await ExecuteAsync(spString: "usp_Users_INS", parameters);

        public async Task Update(UserUpdateParameters parameters)
            => await ExecuteAsync(spString: "usp_Users_UPD", parameters);

        public async Task Delete(Guid id)
            => await ExecuteAsync(spString: "usp_Users_DEL", parameters: new { Id = id });
    }
}
