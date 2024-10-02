using Domain.Abstractions;

namespace Domain.Entities.Users
{
    public class User : EntityAbstraction
    {
        public Guid UserTypeId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public bool IsEmailConfirmed { get; set; }
        public bool IsActive { get; set; }
    }
}
