using System;
using Terraria;
using Terraria.ModLoader;

namespace LuneLib.Utilities
{
    public static class LuneShopUtils
    {
        public static NPCShop AddModItemToShop(NPCShop shop, Mod mod, string itemName, int price)
        {
            if (mod != null)
                if (mod.TryFind(itemName, out ModItem item))
                    shop.Add(new Item(item.Type) { shopCustomPrice = price });
            return shop;
        }

        public static NPCShop AddModItemToShop(NPCShop shop, Mod mod, string itemName, int price, params Condition[] condition)
        {
            if (mod != null)
                if (mod.TryFind(itemName, out ModItem item))
                    shop.Add(new Item(item.Type) { shopCustomPrice = price }, condition);
            return shop;
        }

        public static NPCShop AddModItemToShop(NPCShop shop, Mod mod, string itemName, int price, Func<bool> predicate)
        {
            if (mod != null)
                if (mod.TryFind(itemName, out ModItem item))
                    shop.Add(new Item(item.Type) { shopCustomPrice = price }, new Condition("", predicate));
            return shop;
        }

        public static NPCShop AddModItemToShop<T>(NPCShop shop, int price) where T : ModItem
        {
            shop.Add(new Item(ModContent.ItemType<T>()) { shopCustomPrice = price });
            return shop;
        }

        public static NPCShop AddModItemToShop<T>(NPCShop shop, int price, params Condition[] condition) where T : ModItem
        {
            shop.Add(new Item(ModContent.ItemType<T>()) { shopCustomPrice = price }, condition);
            return shop;
        }

        public static NPCShop AddModItemToShop<T>(NPCShop shop, int price, Func<bool> predicate) where T : ModItem
        {
            shop.Add(new Item(ModContent.ItemType<T>()) { shopCustomPrice = price }, new Condition("", predicate));
            return shop;
        }

        public static void OpenShop(ref string Shop, string shop, ref bool visible)
        {
            Shop = shop;
            visible = false;
            NPC npc = Main.npc[Main.LocalPlayer.talkNPC];
            string _ = "";
            npc.ModNPC.SetChatButtons(ref _, ref _);
        }
    }
}
