using Exiled.API.Interfaces;
using PlayerRoles;
using System.Collections.Generic;

namespace SpawnLatecomers
{
    internal class Config : IConfig
    {
        public bool IsEnabled { get; set; } = true;
        public bool Debug { get; set; } = false;
        public float TimeInSeconds { get; set; } = 60;
        public List<RoleTypeId> RoleTypes { get; set; } = new List<RoleTypeId>()
        {
            RoleTypeId.FacilityGuard,
            RoleTypeId.ClassD,
            RoleTypeId.Scientist
        };
    }
}
