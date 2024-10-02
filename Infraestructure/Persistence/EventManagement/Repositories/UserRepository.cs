using Domain.Entities.Users;
using Infraestructure.Abstractions;

namespace Infraestructure.Persistence.EventManagement.Repositories
{
    public class UserRepository(IDbTransaction dbTransaction) : RepositoryAbstraction(dbTransaction), IUserRepository
    {
    }
}
