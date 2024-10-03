namespace Domain.Entities.EventManagement.Users
{
    public interface IUserRepository
    {
        Task<User?> GetByEmail(string email);
        Task<User?> GetByUsername(string username);
    }
}
