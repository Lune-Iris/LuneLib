using SpiritMod.Items.BossLoot.StarplateDrops;
using SpiritMod.Items.Sets.BismiteSet;
using SpiritMod.Items.Sets.CryoliteSet;
using SpiritMod.Items.Sets.FloranSet;
using SpiritMod.Items.Sets.GraniteSet;
using SpiritMod.Items.Sets.MarbleSet;
using SpiritMod.Items.Sets.SpiritSet;
using System.Collections.Generic;
using Terraria.ModLoader;

namespace LuneLib.Utilities.Hashsets.Spirit
{
    [JITWhenModsEnabled("SpiritMod")]
    public static class SpiritOreSets
    {
        public static readonly HashSet<int> SpiritOreSet;

        static SpiritOreSets()
        {
            if (LuneLib.instance.SpiritModLoaded)
            {
                SpiritOreSet = LuneLib.instance.SpiritModLoaded ? CreateSpiritOreSet() : [];
            }
        }

        private static HashSet<int> CreateSpiritOreSet() =>
        [
            #region prehardmode
            ModContent.TileType<BismiteCrystalTile>(),// no clue which one it is so im adding both
            ModContent.TileType<BismiteCrystalOre>(),
            ModContent.TileType<FloranOreTile>(),
            ModContent.TileType<MarbleOre>(),
            ModContent.TileType<GraniteOre>(),
            ModContent.TileType<Glowstone>(),
            ModContent.TileType<CryoliteOreTile>(),
            #endregion

            #region hardmode
            ModContent.TileType<SpiritOreTile>(),
            #endregion
        ];
    }
}