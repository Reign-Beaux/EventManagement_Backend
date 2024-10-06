using Domain.Entities.EventManagement.Users.Repository;

namespace Domain.UnitOfWork
{
    public interface IEventManagementUnitOfWork : IUnitOfWork
    {
        public IUserRepository UsersRepository { get; }
    }
}
