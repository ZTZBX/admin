using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using CitizenFX.Core;
using static CitizenFX.Core.Native.API;

namespace admin.Client
{
    public class Noclip : BaseScript
    {
        public Noclip()
        {
            RegisterNuiCallbackType("noclip");
            EventHandlers["__cfx_nui:noclip"] += new Action<IDictionary<string, object>, CallbackDelegate>(NoclipNui);
            EventHandlers["onClientResourceStart"] += new Action<string>(OnClientResourceStart);
        }

        private void OnClientResourceStart(string resourceName)
        {
            RunNoClip();
        }

        private Vector3 Position()
        {
            Vector3 myPos = GetEntityCoords(GetPlayerPed(-1), true);
            return myPos;
        }

        private Vector3 CameraPos()
        {

            Vector3 result = new Vector3();
            float heading = GetGameplayCamRelativeHeading() + GetEntityHeading(GetPlayerPed(-1));
            float pitch = GetGameplayCamRelativePitch();

            float x = (float)-Math.Sin(heading * (float)Math.PI / 180.0f);
            float y = (float)Math.Cos(heading * (float)Math.PI / 180.0);
            float z = (float)Math.Sin(pitch * (float)Math.PI / 180.0);

            float len = (float)Math.Sqrt(x * x + y * y + z * z);

            if (len != 0)
            {
                x = x / len;
                x = x / len;
                z = z / len;
            }

            result.X = x;
            result.Y = y;
            result.Z = z;

            return result;

        }

        async void RunNoClip()
        {


            int player = PlayerId();
            int ped = GetPlayerPed(player);
            Vector3 currentPos;
            Vector3 camera;
            float speed;
            float x;
            float y;
            float z;

            float cx;
            float cy;
            float cz;

            float noclip_speed = 1.5f;


            while (true)
            {


                await Delay(0);

                if (!NuiStatus.noClip) { continue; }
                ped = GetPlayerPed(-1);
                currentPos = Position();
                camera = CameraPos();
                x = currentPos.X;
                y = currentPos.Y;
                z = currentPos.Z;
                cx = camera.X;
                cy = camera.Y;
                cz = camera.Z;
                speed = noclip_speed;

                SetEntityVisible(GetPlayerPed(-1), false, false);
                SetEntityVelocity(ped, 0.0001f, 0.0001f, 0.0001f);

                // front
                if (IsControlPressed(0, 32))
                {
                    x = x + speed * cx;
                    y = y + speed * cy;
                    z = z + speed * cz;
                }

                // rear
                if (IsControlPressed(0, 269))
                {
                    x = x - speed * cx;
                    y = y - speed * cy;
                    z = z - speed * cz;
                }

                // right
                if (IsControlPressed(0, 269))
                {
                    x = x - 1;
                }

                // left
                if (IsControlPressed(0, 34))
                {
                    x = x - 1;
                }

                // right
                if (IsControlPressed(0, 9))
                {
                    x = x + 1;
                }

                // up
                if (IsControlPressed(0, 203))
                {
                    z = z + 1;
                }

                // down
                if (IsControlPressed(0, 210))
                {
                    z = z - 1;
                }

                // speed up
                if (IsControlPressed(0, 21))
                {
                    noclip_speed = 3.0f;
                }
                else
                {
                    noclip_speed = 1.5f;
                }

                SetEntityCoordsNoOffset(ped, x, y, z, true, true, true);

            }

        }

        private void NoclipNui(IDictionary<string, object> data, CallbackDelegate cb)
        {
            if (NuiStatus.noClip) { NuiStatus.noClip = false; SetEntityVisible(GetPlayerPed(-1), true, false); }
            else { NuiStatus.noClip = true; }
        }

    }
}