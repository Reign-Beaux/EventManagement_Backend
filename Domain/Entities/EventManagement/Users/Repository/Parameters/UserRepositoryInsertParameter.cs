namespace Domain.Entities.EventManagement.Users.Repository.Parameters
{
    public record UserRepositoryInsertParameter(Guid UserTypeId,
        string Username,
        string Email,
        string Password,
        Guid CreatedBy);
}
