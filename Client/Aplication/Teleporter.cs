using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using CitizenFX.Core;
using static CitizenFX.Core.Native.API;

namespace admin.Client
{
    public class Teleporter : BaseScript
    {
        public Teleporter()
        {
            RegisterNuiCallbackType("tpa");
            EventHandlers["__cfx_nui:tpa"] += new Action<IDictionary<string, object>, CallbackDelegate>(TpaNui);

            RegisterNuiCallbackType("tpme");
            EventHandlers["__cfx_nui:tpme"] += new Action<IDictionary<string, object>, CallbackDelegate>(TpmeNui);
        }

        private void TpaNui(IDictionary<string, object> data, CallbackDelegate cb)
        {
            object username;

            if (!data.TryGetValue("username", out username)) { return; }

            TriggerServerEvent("teleportToPlayer", Exports["core-ztzbx"].playerToken(), username);
        }

        private void TpmeNui(IDictionary<string, object> data, CallbackDelegate cb)
        {
            object username;

            if (!data.TryGetValue("username", out username)) { return; }

            TriggerServerEvent("teleportPlayerToMe", Exports["core-ztzbx"].playerToken(), username);
        }

    }
}