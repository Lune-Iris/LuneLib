using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static LuneLib.Utilities.LuneLibUtils;

namespace LuneLib.Common.Items
{
    public class LLibGlobalItemhooks : GlobalItem
    {
        public override void SetDefaults(Item item)
        {
            if (item.type == ItemID.BottomlessBucket && LL)
            {
                item.useTime = 1;
                item.useAnimation = 1;
            }
            if (item.type == ItemID.SuperAbsorbantSponge && LL)
            {
                item.useTime = 1;
                item.useAnimation = 1;
            }
        }
    }
}