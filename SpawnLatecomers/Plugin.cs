using Exiled.API.Features;
using Exiled.Events.EventArgs.Player;
using System;
using System.Collections.Generic;

namespace SpawnLatecomers
{
    internal class Plugin : Plugin<Config>
    {
        private static Random rnd = new Random();
        private HashSet<string> joinedplayers = new HashSet<string>();

        public override Version Version { get; } = new Version("1.0.0");
        public override Version RequiredExiledVersion { get; } = new Version("9.5.1");
        public override string Author { get; } = "minect86";
        public override string Name { get; } = "Spawn Latecomers";

        public override void OnEnabled()
        {
            Exiled.Events.Handlers.Player.Verified += PlayerJoin;
            Exiled.Events.Handlers.Server.WaitingForPlayers += WaitingForPlayers;
            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            Exiled.Events.Handlers.Player.Verified -= PlayerJoin;
            Exiled.Events.Handlers.Server.WaitingForPlayers -= WaitingForPlayers;
            base.OnDisabled();
        }

        private void WaitingForPlayers()
        {
            if (Config.Debug)
                Log.Debug("joinedplayers.Clear()");
            joinedplayers.Clear();
        }

        private void PlayerJoin(VerifiedEventArgs ev)
        {
            if (Round.IsLobby)
            {
                joinedplayers.Add(ev.Player.UserId);
                if (Config.Debug)
                    Log.Debug($"Player: {ev.Player.Nickname} ({ev.Player.UserId}) add to joinedplayers list");
            }
            else
            {
                if (!joinedplayers.Contains(ev.Player.UserId) && Round.ElapsedTime <= TimeSpan.FromSeconds(Config.TimeInSeconds))
                {
                    joinedplayers.Add(ev.Player.UserId);
                    ev.Player.Role.Set(Config.RoleTypes[rnd.Next(Config.RoleTypes.Count)]);
                    if (Config.Debug)
                        Log.Debug($"Spawning latecomer: {ev.Player.Nickname} ({ev.Player.UserId})");
                }
            }
        }
    }
}