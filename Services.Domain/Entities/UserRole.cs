﻿using Services.Domain.Abstraction;
using Services.Domain.Base;
using Services.Domain.Models;

namespace Services.Domain.Entities
{
    public sealed record UserRole : Entity<Guid>, ITrackableCreate, ITrackableUpdate
    {
        private UserRole(Guid userId, Guid roleId)
        {
            UserId = userId;
            RoleId = roleId;
        }

        public Guid UserId { get; set; }
        public Guid RoleId { get; set; }
        public DateTime CreateOn { get; set; }
        public DateTime? UpdateOn { get; set; }
        public User User { get; set; } = new();
        public Role Role { get; set; } = new();

        public static UserRole Create(Guid userId, Guid roleId) => new UserRole(userId, roleId);

        public void SetCreateOn() => CreateOn = DateTime.UtcNow;

        public void SetUpdateOn() => UpdateOn = DateTime.UtcNow;
    }
}
