namespace Application.DTOs.Users
{
    public record class InsertUserDTO(Guid UserTypeId,
        string Username,
        string Email,
        string Password,
        Guid CreatedBy);
}
