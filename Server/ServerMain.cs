using System;
using System.Threading.Tasks;
using CitizenFX.Core;
using static CitizenFX.Core.Native.API;


namespace admin.Server
{
    public class ServerMain : BaseScript
    {
        public ServerMain()
        {
            EventHandlers["checkAdmin"] += new Action<Player, string>(CheckAdmin);
            EventHandlers["kickPlayer"] += new Action<Player, string, string, string>(kickPlayer);
            EventHandlers["updatePlayers"] += new Action<Player, string>(UpdatePlayers);
            EventHandlers["teleportToPlayer"] += new Action<Player, string, string>(TeleportToPlayer);
            EventHandlers["teleportPlayerToMe"] += new Action<Player, string, string>(TeleportPlayerToMe);
            EventHandlers["freezePlayer"] += new Action<Player, string, string>(FreezePlayer);
        }

        private void FreezePlayer([FromSource] Player user, string token, string username)
        {
            bool isAdmin = Exports["core-ztzbx"].playerAdmin(token);

            if (isAdmin)
            {
                
                Exports["core-ztzbx"].freezePlayerSwitch(username);
            }
        }

        private void TeleportToPlayer([FromSource] Player user, string token, string username)
        {
            bool isAdmin = Exports["core-ztzbx"].playerAdmin(token);

            if (isAdmin)
            {
                int PlayerTargetNetworkId = Exports["core-ztzbx"].getPlayerNetworkIdFromUsername(username);
                Vector3 playerCoords = GetEntityCoords(NetworkGetEntityFromNetworkId(PlayerTargetNetworkId));
                SetEntityCoords(user.Character.NetworkId, playerCoords.X, playerCoords.Y, playerCoords.Z, false, false, false, false);
            }
        }

        private void TeleportPlayerToMe([FromSource] Player user, string token, string username)
        {
            bool isAdmin = Exports["core-ztzbx"].playerAdmin(token);

            if (isAdmin)
            {
                int PlayerTargetNetworkId = Exports["core-ztzbx"].getPlayerNetworkIdFromUsername(username);
                Vector3 playerCoords = GetEntityCoords(NetworkGetEntityFromNetworkId(user.Character.NetworkId));
                SetEntityCoords(PlayerTargetNetworkId, playerCoords.X, playerCoords.Y, playerCoords.Z, false, false, false, false);
            }
        }

        private void UpdatePlayers([FromSource] Player user, string info)
        {
            dynamic playersUsernames = Exports["core-ztzbx"].getPlayersUsernames();
            TriggerClientEvent(user, "updatePlayers", playersUsernames);
        }

        private void kickPlayer([FromSource] Player user, string token, string username, string reason)
        {
            bool isAdmin = Exports["core-ztzbx"].playerAdmin(token);

            if (isAdmin)
            {
                DropPlayer(Exports["core-ztzbx"].getPlayerHandleFromUsername(username), reason);
            }
        }

        private void CheckAdmin([FromSource] Player user, string token)
        {
            bool isAdmin = Exports["core-ztzbx"].playerAdmin(token);

            if (isAdmin)
            {
                TriggerClientEvent(user, "openAdminNui", "NO");
            }
        }

    }
}