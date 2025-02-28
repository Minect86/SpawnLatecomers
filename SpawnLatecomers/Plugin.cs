using Exiled.API.Features;
using Exiled.Events.EventArgs.Player;
using MEC;
using System;
using System.Collections.Generic;

namespace SpawnLatecomers
{
    internal class Plugin : Plugin<Config>
    {
        public override void OnEnabled()
        {
            Exiled.Events.Handlers.Player.Joined += PlayerJoin;
            base.OnEnabled();
        }
        public override void OnDisabled()
        {
            Exiled.Events.Handlers.Player.Joined -= PlayerJoin;
            base.OnDisabled();
        }

        private Random rnd = new Random();
        private HashSet<Player> joinedplayers = new HashSet<Player>();

        private void PlayerJoin(JoinedEventArgs ev)
        {
            if (Round.IsLobby)
                joinedplayers.Add(ev.Player);

            if (!Round.IsLobby && !joinedplayers.Contains(ev.Player) && (Round.ElapsedTime <= TimeSpan.FromSeconds(Config.TimeInSeconds)))
            {
                joinedplayers.Add(ev.Player);
                SpawnPlayer(ev.Player);
            }

            Timing.CallDelayed(Config.TimeInSeconds + 1, () =>
            {
                joinedplayers.Clear();
            });
        }

        private void SpawnPlayer(Player pl)
        {
            pl.Role.Set(Config.RoleTypes[rnd.Next(Config.RoleTypes.Count)]);
        }
    }
}
