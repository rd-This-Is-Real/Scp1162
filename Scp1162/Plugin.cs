using System;
using Exiled.Events.Handlers;
using Scp1162.Handlers;

namespace Scp1162
{
    public sealed class Plugin : Exiled.API.Features.Plugin<Config>
    {
        private PlayerHandlers _playerHandlers;
        private ServerHandlers _serverHandlers;

        public override string Name => "Scp1162";

        public override string Prefix => "scp_1162";

        public override string Author => "This is Real?#8993";

        public override Version Version { get; } = new(1, 0, 0);

        public override Version RequiredExiledVersion { get; } = new(5, 3, 0);

        public override void OnEnabled()
        {
            _serverHandlers = new();
            _playerHandlers = new (Config.AllowedItems, Config.InteractingHint, Config.CanHurt, Config.HurtHint, Config.HurtDamage);

            Server.RoundStarted += _serverHandlers.OnRoundStarted;

            Player.PickingUpItem += _playerHandlers.OnPickingUpItem;

            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            Player.PickingUpItem -= _playerHandlers.OnPickingUpItem;

            Server.RoundStarted -= _serverHandlers.OnRoundStarted;

            _playerHandlers = null;
            _serverHandlers = null;

            base.OnDisabled();
        }

        public override void OnRegisteringCommands() { }

        public override void OnUnregisteringCommands() { }
    }
}
