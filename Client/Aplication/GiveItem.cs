using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using CitizenFX.Core;
using static CitizenFX.Core.Native.API;

namespace admin.Client
{
    public class GiveItem : BaseScript
    {
        public GiveItem()
        {
            RegisterNuiCallbackType("give_item_to_me");
            EventHandlers["__cfx_nui:give_item_to_me"] += new Action<IDictionary<string, object>, CallbackDelegate>(GiveItemToMe);

            RegisterNuiCallbackType("get_items_meta_data");
            EventHandlers["__cfx_nui:get_items_meta_data"] += new Action<IDictionary<string, object>, CallbackDelegate>(GetItemsMetaData);
        }

        private void GetItemsMetaData(IDictionary<string, object> data, CallbackDelegate cb)
        {
            cb(new
            {
                data = Exports["inventory"].getItemMeta(),
            });
        }


        private void GiveItemToMe(IDictionary<string, object> data, CallbackDelegate cb)
        {
            object item;
            object quantity;

            if (!data.TryGetValue("item", out item)) { return; }
            if (!data.TryGetValue("quantity", out quantity)) { return; }
            TriggerServerEvent("giveItemToMe", Exports["core-ztzbx"].playerToken(), item.ToString(), Int32.Parse(quantity.ToString()));

            cb(new
            {
                data = "ok",
            });
        }

    }
}