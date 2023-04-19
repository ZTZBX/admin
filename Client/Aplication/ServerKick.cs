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
            object id;
            object reason;
            
            if (!data.TryGetValue("reason", out reason)) { return; }
            if (!data.TryGetValue("id", out id)) { return; }

            if (id.ToString() == "me")
            {
                TriggerServerEvent("kickPlayer", Exports["core-ztzbx"].playerToken(), GetPlayerServerId(PlayerId()), reason);
            }
            else 
            {
                int current_id = Int32.Parse(id.ToString());
                TriggerServerEvent("kickPlayer", Exports["core-ztzbx"].playerToken(), current_id, reason);
            }

            
        }

    }
}