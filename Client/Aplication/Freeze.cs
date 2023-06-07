using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using CitizenFX.Core;
using static CitizenFX.Core.Native.API;

namespace admin.Client
{
    public class Freeze : BaseScript
    {
        public Freeze()
        {
            RegisterNuiCallbackType("freeze");
            EventHandlers["__cfx_nui:freeze"] += new Action<IDictionary<string, object>, CallbackDelegate>(FreezeNui);
        }

        private void FreezeNui(IDictionary<string, object> data, CallbackDelegate cb)
        {
            object username;

            if (!data.TryGetValue("username", out username)) { return; }

            TriggerServerEvent("freezePlayer", Exports["core-ztzbx"].playerToken(), username.ToString());

            cb(new
            {
                data = "ok",
            });
        }

    }
}