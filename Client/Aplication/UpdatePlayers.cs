using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using CitizenFX.Core;
using static CitizenFX.Core.Native.API;

namespace admin.Client
{
    public class UpdatePlayers : BaseScript
    {
        public UpdatePlayers()
        {
            RegisterNuiCallbackType("getplayers");
            EventHandlers["__cfx_nui:getplayers"] += new Action<IDictionary<string, object>, CallbackDelegate>(Getplayers);

            EventHandlers["updatePlayers"] += new Action<dynamic>(UpdatePlayersAction);
        }

        private void UpdatePlayersAction(dynamic playersUernames)
        {
            foreach (string playerUsername in playersUernames)
            {
                if (!PlayersMeta.usernames.Contains(playerUsername)){PlayersMeta.usernames.Add(playerUsername);}
            }
        }

        private void Getplayers(IDictionary<string, object> data, CallbackDelegate cb)
        {

            List<string> list_of_stringged_list = new List<string>();

            foreach(string playerUsername in PlayersMeta.usernames)
            {
                list_of_stringged_list.Add("\""+playerUsername+"\"");

            }
            string list_string = string.Join(",", list_of_stringged_list);

            cb(new
            {
                data = "{\"players\": ["+list_string+"] }",
            });

            return;

        }


    }
}