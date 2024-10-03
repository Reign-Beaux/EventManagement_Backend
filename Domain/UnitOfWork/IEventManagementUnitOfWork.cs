using Domain.Entities.EventManagement.Users;

namespace Domain.UnitOfWork
{
    public interface IEventManagementUnitOfWork : IUnitOfWork
    {
        public IUserRepository UsersRepository { get; }
    }
}
