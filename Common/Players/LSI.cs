using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static LuneLib.Utilities.LuneLibUtils;

namespace LuneLib.Common.Players
{
    public class LSI : ModPlayer
    {
        public override IEnumerable<Item> AddStartingItems(bool shiton)
        {
            if (LL)
            {
                yield return new Item(ItemID.SuperAbsorbantSponge);
                yield return new Item(ItemID.BottomlessBucket);
            }
        }
    }
}