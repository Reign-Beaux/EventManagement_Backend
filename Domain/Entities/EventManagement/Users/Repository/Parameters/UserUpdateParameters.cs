namespace Domain.Entities.EventManagement.Users.Repository.Parameters
{
    public record UserUpdateParameters(Guid Id,
        Guid UserTypeId,
        string Username,
        string Email,
        string PasswordHash,
        Guid UpdatedBy);
}
