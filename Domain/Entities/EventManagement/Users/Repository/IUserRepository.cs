using Domain.Entities.EventManagement.Users.Repository.Parameters;

namespace Domain.Entities.EventManagement.Users.Repository
{
    public interface IUserRepository
    {
        Task<List<User>> GetAll();
        Task<User?> GetByEmail(string email);
        Task<User?> GetById(Guid id);
        Task<User?> GetByUsername(string username);
        Task Insert(UserInsertParameters parameters);
        Task Update(UserUpdateParameters user);
        Task Delete(Guid id);
    }
}
