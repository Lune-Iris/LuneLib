using CalamityMod.Tiles.Ores;
using CalamityMod.Tiles.SunkenSea;
using System.Collections.Generic;
using Terraria.ModLoader;

namespace LuneLib.Utilities.Hashsets.Calamity
{
    [JITWhenModsEnabled("CalamityMod")]
    public static class CalOreSets
    {
        public static readonly HashSet<int> CalOreSet;

        static CalOreSets()
        {
            if (LuneLib.instance.CalamityModLoaded)
            {
                CalOreSet = LuneLib.instance.CalamityModLoaded ? CreateCalOreSet() : [];
            }
        }

        private static HashSet<int> CreateCalOreSet() =>
        [
            #region prehardmode
            ModContent.TileType<SeaPrism>(),
            ModContent.TileType<AerialiteOre>(),
            #endregion

            #region hardmode
            ModContent.TileType<AerialiteOreDisenchanted>(),
            ModContent.TileType<InfernalSuevite>(),
            ModContent.TileType<CryonicOre>(),
            ModContent.TileType<HallowedOre>(),
            ModContent.TileType<PerennialOre>(),
            ModContent.TileType<ScoriaOre>(),
            ModContent.TileType<AstralOre>(),
            #endregion

            #region postmoonguy
            ModContent.TileType<ExodiumOre>(),
            ModContent.TileType<UelibloomOre>(),
            ModContent.TileType<AuricOre>(),
            #endregion
        ];
    }
}