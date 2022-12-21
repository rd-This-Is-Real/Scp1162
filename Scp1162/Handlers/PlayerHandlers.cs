using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exiled.API.Enums;
using Exiled.API.Features;
using Exiled.Events.EventArgs;
using UnityEngine;

namespace Scp1162.Handlers
{
    internal sealed class PlayerHandlers
    {
        private readonly IReadOnlyCollection<ItemType> _allowedItems;
        private readonly string _hintText;
        private readonly bool _hurtAllowed;
        private readonly string _hurtHint;
        private readonly float _hurtDamage;

        public PlayerHandlers(List<ItemType> items, string hint, bool hurtAllowed, string hurtHint, float hurtDamage)
        {
            _allowedItems = items.AsReadOnly();
            _hintText = hint;
            _hurtAllowed = hurtAllowed;
            _hurtHint = hurtHint;
            _hurtDamage = hurtDamage;
        }

        public void OnPickingUpItem(PickingUpItemEventArgs ev)
        {
            if (!Server.TryGetSessionVariable("SCP-1162", out ushort serial) || ev.Pickup.Serial != serial || !ev.IsAllowed)
            {
                return;
            }

            ev.IsAllowed = false;

            if (ev.Player.CurrentItem != null)
            {
                ev.Player.RemoveHeldItem(true);

                ev.Player.AddItem(_allowedItems.ElementAt(Random.Range(0, _allowedItems.Count)));
                ev.Player.ShowHint(_hintText);
            }
            else if (_hurtAllowed)
            {
                ev.Player.Hurt(_hurtDamage, DamageType.Scp);
                ev.Player.EnableEffect(EffectType.Burned, 3);
                    
                ev.Player.ShowHint(_hurtHint);
            }
        }
    }
}
