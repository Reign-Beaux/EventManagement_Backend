namespace Domain.Entities.EventManagement.Users.Repository.Parameters
{
    public class UserInsertParameters
    {
        public Guid UserTypeId { get; set; }
        public string? Username { get; set; }
        public string? Email { get; set; }
        public string? PasswordHash { get; set; }
        public Guid CreatedBy { get; set; }
    }
}
