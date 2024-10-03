using Domain.Entities.EventManagement.Users;
using Infraestructure.Interfaces;

namespace Infraestructure.Persistence.EventManagement
{
    public interface IEventManagementUnitOfWork : IUnitOfWork
    {
        public IUserRepository UsersRepository { get; }
    }
}
