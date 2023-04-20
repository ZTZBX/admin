using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using CitizenFX.Core;
using static CitizenFX.Core.Native.API;

namespace admin.Client
{
    public class BanPlayer : BaseScript
    {
        public BanPlayer()
        {
            RegisterNuiCallbackType("banplayer");
            EventHandlers["__cfx_nui:banplayer"] += new Action<IDictionary<string, object>, CallbackDelegate>(BanPlayerNui);
        }

        private void BanPlayerNui(IDictionary<string, object> data, CallbackDelegate cb)
        {
            object username;

            if (!data.TryGetValue("username", out username)) { return; }
            string token = Exports["core-ztzbx"].banPlayer(username.ToString());
        }

    }
}