using System;
using System.Threading.Tasks;
using CitizenFX.Core;
using static CitizenFX.Core.Native.API;

namespace admin.Client
{
    public class ClientMain : BaseScript
    {
        public ClientMain()
        {
            EventHandlers["onClientResourceStart"] += new Action<string>(OnClientResourceStart);
            EventHandlers["openAdminNui"] += new Action<string>(OpenAdminNui);
        }

        private void OpenAdminNui(string info)
        {
            TriggerServerEvent("updatePlayers", "");
            ClientMain.AdminNui(true);
            NuiStatus.active = true;
        }

        private void OnClientResourceStart(string resourceName)
        {
            NuiStatus.active = false;
            OpenNuiEvent();
        }

        private async void OpenNuiEvent()
        {



            while (true)
            {
                await Delay(0);

                if (IsControlJustReleased(0, 212))
                {

                    if (!NuiStatus.active)
                    {
                        TriggerServerEvent("checkAdmin", Exports["core-ztzbx"].playerToken());
                        await Delay(2);
                    }
                    
                }
            }
        }

        static public void AdminNui(bool state)
        {
            string jsonString = "";
            if (state) { jsonString = "{\"showAdmin\": true }"; SetNuiFocus(true, true); SetNuiFocus(true, true); }
            if (!state) { jsonString = "{\"showAdmin\": false }"; SetNuiFocus(false, false); SetNuiFocus(false, false); }

            SendNuiMessage(jsonString);
        }
    }
}