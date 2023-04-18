using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using CitizenFX.Core;
using static CitizenFX.Core.Native.API;

namespace admin.Client
{
    public class NUI : BaseScript
    {
        public NUI()
        {
            RegisterNuiCallbackType("exit");
            EventHandlers["__cfx_nui:exit"] += new Action<IDictionary<string, object>, CallbackDelegate>(Exit);
        }

        private void Exit(IDictionary<string, object> data, CallbackDelegate cb)
        {
            ClientMain.AdminNui(false);
            NuiStatus.active = false;
        }

    }
}