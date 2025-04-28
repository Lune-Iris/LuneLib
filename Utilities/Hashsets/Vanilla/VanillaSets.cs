using System.Collections.Generic;
using Terraria.ID;

namespace LuneLib.Utilities.Hashsets.Vanilla
{
    public static class VanillaSets
    {

        public static readonly HashSet<int> AbyssalProjectiles;

        public static readonly HashSet<int> AbyssalNPCs;

        public static readonly HashSet<int> AquaticBosses;

        static VanillaSets()
        {

            AbyssalProjectiles = CreateVanillaProjSpecificTypes();

            AbyssalNPCs = CreateVanillaNpcSpecificTypes();

            AquaticBosses = CreateVanillaBossSpecificTypes();

        }

        private static HashSet<int> CreateVanillaProjSpecificTypes() =>
        [

            #region

                ProjectileID.EyeBeam,
                ProjectileID.SharknadoBolt,
                ProjectileID.Sharknado,
                ProjectileID.Cthulunado,
                ProjectileID.MartianTurretBolt,
                ProjectileID.RainNimbus,

            #endregion

        ];

        private static HashSet<int> CreateVanillaNpcSpecificTypes() =>
        [

            #region Vanilla NPCs

                NPCID.BlueJellyfish,
                NPCID.BloodJelly,
                NPCID.Crab,
                NPCID.DetonatingBubble,
                NPCID.Dolphin,
                NPCID.DukeFishron,
                NPCID.GoldSeahorse,
                NPCID.GreenJellyfish,
                NPCID.PinkJellyfish,
                NPCID.SeaSnail,
                NPCID.SeaTurtle,
                NPCID.Seahorse,
                NPCID.Shark,
                NPCID.Sharkron,
                NPCID.Squid,
                NPCID.AnglerFish,
                NPCID.Arapaima,
                NPCID.BloodFeeder,
                NPCID.CorruptGoldfish,
                NPCID.FlyingFish,
                NPCID.FungoFish,
                NPCID.Piranha,
                NPCID.SeaSnail,
                NPCID.Sharkron,
                NPCID.Sharkron2,
                NPCID.Squid,
                NPCID.CrimsonGoldfish,
                NPCID.Goldfish,
                NPCID.GoldfishWalker,

            #endregion

        ];

        private static HashSet<int> CreateVanillaBossSpecificTypes() =>
        [

            #region

                NPCID.DukeFishron,

            #endregion

        ];
    }
}
