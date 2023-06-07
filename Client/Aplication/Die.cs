using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using CitizenFX.Core;
using static CitizenFX.Core.Native.API;

namespace admin.Client
{
    public class PlayerKill : BaseScript
    {
        public PlayerKill()
        {
            RegisterNuiCallbackType("kill");
            EventHandlers["__cfx_nui:kill"] += new Action<IDictionary<string, object>, CallbackDelegate>(Kill);
        }

        private void Kill(IDictionary<string, object> data, CallbackDelegate cb)
        {
            SetEntityHealth(GetPlayerPed(-1), 0);

            cb(new
            {
                data = "ok",
            });
        }

    }
}