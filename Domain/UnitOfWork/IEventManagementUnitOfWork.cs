using Domain.Entities.EventManagement.Users;

namespace Domain.UnitOfWork
{
    public interface IEventManagementUnitOfWork
    {
        public IUserRepository UsersRepository { get; }
        public void Commit();
    }
}
