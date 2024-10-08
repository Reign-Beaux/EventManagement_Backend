﻿using Application.Consts;
using Domain.Entities.EventManagement.Users.Repository;
using Domain.UnitOfWork;
using Infraestructure.Abstractions;
using Infraestructure.Persistence.EventManagement.Repositories;
using Microsoft.Extensions.Configuration;

namespace Infraestructure.Persistence.EventManagement
{
    public class EventManagementUnitOfWork : UnitOfWorkAbstraction, IEventManagementUnitOfWork
    {
        public IUserRepository UsersRepository { get; }

        public EventManagementUnitOfWork(IConfiguration configuration) : base(configuration.GetConnectionString(ConnectionStrings.EventManagement)!)
        {
            UsersRepository = new UserRepository(_dbTransaction);
        }
    }
}
