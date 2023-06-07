using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using CitizenFX.Core;
using static CitizenFX.Core.Native.API;

namespace admin.Client
{
    public class GetCoords : BaseScript
    {
        public GetCoords()
        {
            RegisterNuiCallbackType("coords");
            EventHandlers["__cfx_nui:coords"] += new Action<IDictionary<string, object>, CallbackDelegate>(Coords);
        }

        private void Coords(IDictionary<string, object> data, CallbackDelegate cb)
        {

            Vector3 currect_coords = GetEntityCoords(PlayerPedId(), false);

            cb(new
            {
                coords = "{\"x\":"+currect_coords.X+", \"y\": "+currect_coords.Y+", \"z\": "+currect_coords.Z+"}",
            });

        }

    }
}