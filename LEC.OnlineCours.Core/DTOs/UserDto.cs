﻿namespace LEC.OnlineCours.Core.DTOs
{
    public class UserDto
    {
        public int UserId { get; set; }

        public string DisplayName { get; set; } = null!;

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string AdObjId { get; set; } = null!;
        public string? ProfilePictureUrl { get; set; }
        public string? Bio { get; set; }
        public required List<UserRoleDto> UserRoleDto { get; set; }
    }

    public class UserRoleDto
    {
        public int UserRoleId { get; set; }

        public int RoleId { get; set; }
        public string RoleName { get; set; } = null!;
        public int UserId { get; set; }
    }

    public class RoleDto
    {
        public int RoleId { get; set; }

        public string RoleName { get; set; } = null!;
    }
}
