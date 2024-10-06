namespace Domain.Entities.EventManagement.Users.Repository
{
    public interface IUserRepository
    {
        Task<List<User>> Get();
        Task<User?> GetByEmail(string email);
        Task<User?> GetByUsername(string username);
        Task Insert(User user);
        Task Update(User user);
        Task Delete(Guid Id);
    }
}
