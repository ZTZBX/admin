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