using Domain.Entities.Users;

namespace Domain.UnitOfWork
{
    public interface IEventManagementUnitOfWork
    {
        public IUserRepository UsersRepository { get; }
        public void Commit();
    }
}
