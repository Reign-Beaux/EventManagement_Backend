﻿namespace Domain.Entities.EventManagement.Users.Repository.Parameters
{
    public record UserInsertParameters(Guid UserTypeId,
        string Username,
        string Email,
        string PasswordHash,
        Guid CreatedBy);
}
