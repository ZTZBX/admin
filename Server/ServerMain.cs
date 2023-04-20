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
            EventHandlers["kickPlayer"] += new Action<Player, string, int, string>(kickPlayer);
            EventHandlers["updatePlayers"] += new Action<Player, string>(UpdatePlayers);
   
        }

        private void UpdatePlayers([FromSource] Player user, string info)
        {
            dynamic playersUsernames = Exports["core-ztzbx"].getPlayersUsernames();
             
            TriggerClientEvent(user, "updatePlayers", playersUsernames);
        }
        
        private void kickPlayer([FromSource] Player user, string token, int id, string reason)
        {
            bool isAdmin = Exports["core-ztzbx"].playerAdmin(token);

            if (isAdmin)
            {
                DropPlayer(Players[id].Handle, reason);
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