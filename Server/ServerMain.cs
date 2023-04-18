using System;
using System.Threading.Tasks;
using CitizenFX.Core;

namespace admin.Server
{
    public class ServerMain : BaseScript
    {
        public ServerMain()
        {
            EventHandlers["checkAdmin"] += new Action<Player, string>(CheckAdmin);
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