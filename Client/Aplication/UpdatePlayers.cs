using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using CitizenFX.Core;
using static CitizenFX.Core.Native.API;

namespace admin.Client
{
    public class UpdatePlayers : BaseScript
    {

        private List<string> list_of_stringged_list = new List<string>();
        private string list_string;

        public UpdatePlayers()
        {
            RegisterNuiCallbackType("getplayers");
            EventHandlers["__cfx_nui:getplayers"] += new Action<IDictionary<string, object>, CallbackDelegate>(Getplayers);

            EventHandlers["updatePlayers"] += new Action<dynamic>(UpdatePlayersAction);
        }

        private void UpdatePlayersAction(dynamic playersUernames)
        {

            PlayersMeta.usernames.Clear();

            foreach (string playerUsername in playersUernames)
            {
                PlayersMeta.usernames.Add(playerUsername);
            }
        }

        private void Getplayers(IDictionary<string, object> data, CallbackDelegate cb)
        {

            list_of_stringged_list.Clear();

            foreach(string playerUsername in PlayersMeta.usernames)
            {
                list_of_stringged_list.Add("\""+playerUsername+"\"");

            }

            list_string = string.Join(",", list_of_stringged_list);

            cb(new
            {
                data = "{\"players\": ["+list_string+"] }",
            });

            return;

        }


    }
}