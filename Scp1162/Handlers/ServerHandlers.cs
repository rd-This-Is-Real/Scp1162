using Exiled.API.Enums;
using Exiled.API.Features;
using Exiled.API.Features.Items;
using Mirror;
using UnityEngine;

namespace Scp1162.Handlers
{
    internal sealed class ServerHandlers
    {
        public void OnRoundStarted()
        {
            Pickup pickup = Item.Create(ItemType.SCP500).Spawn(Vector3.zero);

            GameObject obj = pickup.GameObject;
            Transform transform = obj.transform;
            Rigidbody rigidbody = obj.GetComponent<Rigidbody>();

            NetworkServer.UnSpawn(obj);

            transform.SetParent(Room.Get(RoomType.Lcz173).transform);

            rigidbody.isKinematic = true;

            transform.localPosition = new (31.467f, 17.864f, 10.833f);
            transform.localRotation = Quaternion.Euler(0, 1, 90);
            transform.localScale = Vector3.one * 10;

            NetworkServer.Spawn(obj);

            if (Server.SessionVariables.ContainsKey("SCP-1162"))
            {
                Server.SessionVariables["SCP-1162"] = pickup.Serial;
            }
            else
            {
                Server.SessionVariables.Add("SCP-1162", pickup.Serial);
            }
        }
    }
}