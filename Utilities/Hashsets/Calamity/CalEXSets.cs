using CalValEX.NPCs.Critters;
using System.Collections.Generic;

using Terraria.ModLoader;

namespace LuneLib.Utilities.Hashsets.Calamity
{
    [JITWhenModsEnabled("CalValEX")]
    public static class CalEXSets
    {
        #region Abyssal Npcs

        public static readonly HashSet<int> AbyssalNPCs;

        static CalEXSets()
        {
            var isCalValExLoaded = ModLoader.HasMod("CalValEX");
            AbyssalNPCs = isCalValExLoaded ? CreateCalValExNpcSpecificTypes() : [];
        }

        private static HashSet<int> CreateCalValExNpcSpecificTypes() =>
        [
            #region CalValEX Mod NPCs

                #region Sulphurous Sea NPCs

                    //acid rain specific
                    ModContent.NPCType<Vaporofly>(),
                    ModContent.NPCType<Orthobab>(),

                #endregion

                #region Layer4

                    ModContent.NPCType<Isopod>(),

                #endregion

            #endregion
        ];

        #endregion
    }
}