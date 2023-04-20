using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using CitizenFX.Core;
using static CitizenFX.Core.Native.API;

namespace admin.Client
{
    public class Invincible : BaseScript
    {
        public Invincible()
        {
            RegisterNuiCallbackType("invincible");
            EventHandlers["__cfx_nui:invincible"] += new Action<IDictionary<string, object>, CallbackDelegate>(InvincibleNui);
            EventHandlers["onClientResourceStart"] += new Action<string>(OnClientResourceStart);
        }

        private void OnClientResourceStart(string resourceName)
        {
            InfiniteHealth();
        }

        async void InfiniteHealth()
        {
            while (true)
            {
                await Delay(0);
                if (!NuiStatus.Invincible) { continue; }
                SetEntityHealth(GetPlayerPed(-1), 200);
            }
        }

        private void InvincibleNui(IDictionary<string, object> data, CallbackDelegate cb)
        {
            if (NuiStatus.Invincible) { NuiStatus.Invincible = false;}
            else { NuiStatus.Invincible = true; }
        }

    }
}