using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using CitizenFX.Core;
using static CitizenFX.Core.Native.API;

namespace admin.Client
{
    public class ServerKick : BaseScript
    {
        public ServerKick()
        {
            RegisterNuiCallbackType("serverKick");
            EventHandlers["__cfx_nui:serverKick"] += new Action<IDictionary<string, object>, CallbackDelegate>(ServerKickNui);
        }

        private void ServerKickNui(IDictionary<string, object> data, CallbackDelegate cb)
        {
            object username;
            object reason;
            
            if (!data.TryGetValue("reason", out reason)) { return; }
            if (!data.TryGetValue("username", out username)) { return; }

            if (username.ToString() == "me")
            {
                TriggerServerEvent("kickPlayer", Exports["core-ztzbx"].playerToken(), Exports["core-ztzbx"].playerUsername(), reason);
            }
            else 
            {
                TriggerServerEvent("kickPlayer", Exports["core-ztzbx"].playerToken(), username, reason);
            }
             
        }

    }
}