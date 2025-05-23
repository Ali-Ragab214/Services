﻿using Services.Domain.Abstraction;
using Services.Domain.Base;
using Services.Domain.Entities;

namespace Services.Domain.Models
{
    public sealed record Role : Entity<Guid>, ITrackableCreate, ITrackableUpdate
    {
        public Role() { }

        private Role(string name) => Name = name;

        private Role(Guid id, string name)
        {
            Name = name;
            Id = id;
            CreateOn = DateTime.UtcNow;
        }

        public string Name { get; set; }
        public DateTime CreateOn { get; set; }
        public DateTime? UpdateOn { get; set; }

        public static Role Create(string name) => new(name);

        public static Role Create(Guid id, string name) => new(id, name);

        public void SetCreateOn() => CreateOn = DateTime.UtcNow;

        public void SetUpdateOn() => UpdateOn = DateTime.UtcNow;

        public IReadOnlyCollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
        public IReadOnlyCollection<RolePermission> RolePermissions { get; set; } =
            new List<RolePermission>();
    }
}
