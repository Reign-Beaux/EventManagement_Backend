﻿using Domain.Abstractions;

namespace Domain.Entities.EventManagement.Users
{
    public class User : EntityAbstraction
    {
        public Guid UserTypeId { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public bool IsEmailConfirmed { get; set; }
        public bool IsActive { get; set; }
    }
}
