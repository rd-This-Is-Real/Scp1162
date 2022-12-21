using Exiled.API.Interfaces;
using System.Collections.Generic;

namespace Scp1162
{
    public sealed class Config : IConfig
    {
        public bool IsEnabled { get; set; } = true;

        public bool CanHurt { get; set; } = true;

        public string HurtHint { get; set; } = "<color=red>Do not use SCP-1162 without item in hand!</color>";

        public int HurtDamage { get; set; } = 15;

        public string InteractingHint { get; set; } = "<color=yellow>You have used SCP-1162 and got another item!</color>";

        public List<ItemType> AllowedItems { get; set; } = new List<ItemType>
        {
            ItemType.KeycardO5,
            ItemType.SCP500,
            ItemType.MicroHID,
            ItemType.KeycardNTFCommander,
            ItemType.KeycardContainmentEngineer,
            ItemType.SCP268,
            ItemType.GunCOM15,
            ItemType.SCP207,
            ItemType.Adrenaline,
            ItemType.GunCOM18,
            ItemType.KeycardFacilityManager,
            ItemType.Medkit,
            ItemType.KeycardNTFLieutenant,
            ItemType.KeycardGuard,
            ItemType.GrenadeHE,
            ItemType.KeycardZoneManager,
            ItemType.KeycardGuard,
            ItemType.Radio,
            ItemType.GrenadeFlash,
            ItemType.KeycardScientist,
            ItemType.KeycardJanitor,
            ItemType.Coin,
            ItemType.Flashlight
        };
    }
}
