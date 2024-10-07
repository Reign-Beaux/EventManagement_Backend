using Application.UseCases.Users.Commands.InsertUser;
using AutoMapper;
using Domain.Entities.EventManagement.Users.Repository.Parameters;

namespace Application.Mappings
{
    public class UserMappings : Profile
    {
        public UserMappings()
        {
            CreateMap<InsertUserCommand, UserInsertParameters>();
        }
    }
}
