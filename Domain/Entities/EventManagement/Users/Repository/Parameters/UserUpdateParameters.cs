namespace Domain.Entities.EventManagement.Users.Repository.Parameters
{
    public class UserUpdateParameters
    {
        public Guid Id { get; set; }
        public Guid UserTypeId { get; set; }
        public string? Username { get; set; }
        public string? Email { get; set; }
        public string? PasswordHash { get; set; }
        public Guid UpdatedBy { get; set; }
    }
}
