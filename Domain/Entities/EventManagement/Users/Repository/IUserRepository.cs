using Domain.Entities.EventManagement.Users.Repository.Parameters;

namespace Domain.Entities.EventManagement.Users.Repository
{
    public interface IUserRepository
    {
        Task<List<User>> Get();
        Task<User?> GetByEmail(string email);
        Task<User?> GetByUsername(string username);
        Task Insert(UserInsertParameters parameters);
        Task Update(User user);
        Task Delete(Guid Id);
    }
}
