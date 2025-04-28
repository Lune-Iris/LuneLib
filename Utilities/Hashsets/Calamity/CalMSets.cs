using System.Collections.Generic;
using Terraria.ModLoader;

namespace LuneLib.Utilities.Hashsets.Calamity
{
    [JITWhenModsEnabled("CalamitasMommy")]
    public static class CalMSets
    {
        private static readonly int tenebrisTileID;

        public static readonly HashSet<int> IsAquaticTile;
        static CalMSets()
        {

            var isCalMLoaded = ModLoader.HasMod("CalamitasMommy");
            IsAquaticTile = isCalMLoaded ? CreateCalMTileSpecificTypes() : [];

            if (ModLoader.TryGetMod("CalamitasMommy", out Mod calamitasmommy))
            {
                tenebrisTileID = calamitasmommy.Find<ModTile>("TenebrisTile").Type;
            }
        }

        private static HashSet<int> CreateCalMTileSpecificTypes() =>
        [

            tenebrisTileID,

        ];

    }
}
