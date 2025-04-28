using LuneLib.Utilities.Hashsets.Vanilla;
using SpiritMod.Items.Armor.AstronautVanity;
using SpiritMod.Items.BossLoot.StarplateDrops.StarArmor;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace LuneLib.Common.Players.LuneLibPlayer
{
    public partial class LibPlayer : ModPlayer
    {
        #region Is Wearing Armor Type?

        #region Lead Armor

        public static bool WearingFullLead { get; set; }
        public static bool WearingTwoLeadPieces { get; set; }
        public static bool WearingOneLeadPiece { get; set; }
        public static bool WearingAnyLead { get; set; }

        public int PiecesLeadArmour()
        {
            int leadCount = 0;

            int[] leadArmorIDs = [ItemID.LeadHelmet, ItemID.LeadChainmail, ItemID.LeadGreaves];
            for (int i = 0; i < 3; i++)
            {
                if (Array.Exists(leadArmorIDs, id => Player.armor[i].type == id))
                {
                    leadCount++;
                }
            }

            return leadCount;
        }

        #endregion

        #region Is weaing any armour

        public static bool WearingFullArmour { get; set; }
        public static bool WearingTwoArmourPieces { get; set; }
        public static bool WearingOneArmourPiece { get; set; }
        public static bool WearingAnyArmour { get; set; }


        public int PiecesArmour()
        {
            int armourCount = 0;

            for (int i = 0; i < 3; i++)
            {
                if (Player.armor[i].type != ItemID.None)
                {
                    armourCount++;
                }
            }

            return armourCount;
        }

        #endregion

        #region Eskimo

        public static bool WearingFullEskimo { get; set; }
        public static bool WearingTwoEskimoPieces { get; set; }
        public static bool WearingOneEskimoPiece { get; set; }
        public static bool WearingAnyEskimo { get; set; }

        public int PiecesEskimoArmour()
        {
            int eskimoCount = 0;

            int[] eskimoIDs = [ItemID.EskimoHood, ItemID.EskimoCoat, ItemID.EskimoPants, ItemID.PinkEskimoHood, ItemID.PinkEskimoCoat, ItemID.PinkEskimoPants];
            for (int i = 0; i < 3; i++)
            {
                if (Array.Exists(eskimoIDs, id => Player.armor[i].type == id))
                {
                    eskimoCount++;
                }
            }

            return eskimoCount;
        }

        #endregion

        #region Tungsten armour

        public static bool WearingFullTungsten { get; set; }
        public static bool WearingTwoTungstenPieces { get; set; }
        public static bool WearingOneTungstenPiece { get; set; }
        public static bool WearingAnyTungsten { get; set; }

        public int PiecesTungstenArmour()
        {
            int TungstenCount = 0;

            int[] TungstenIDs = [ItemID.TungstenHelmet, ItemID.TungstenChainmail, ItemID.TungstenGreaves];
            for (int i = 0; i < 3; i++)
            {
                if (Array.Exists(TungstenIDs, id => Player.armor[i].type == id))
                {
                    TungstenCount++;
                }
            }

            return TungstenCount;
        }

        #endregion

        #region astalite

        public static bool WearingAstraliteVisor { get; set; }
        public static bool WearingFullAstralite { get; set; }
        public static bool WearingTwoAstralitePieces { get; set; }
        public static bool WearingOneAstralitePiece { get; set; }
        public static bool WearingAnyAstralite { get; set; }

        [JITWhenModsEnabled("SpiritMod")]
        public int PiecesAstraliteArmour()
        {
            int AstraliteCount = 0;

            if (Player.armor[0].type == ModContent.ItemType<StarMask>())
            {
                AstraliteCount++;
                WearingAstraliteVisor = true;
            }
            else
            {
                WearingAstraliteVisor = false;
            }

            if (Player.armor[1].type == ModContent.ItemType<StarPlate>())
            {
                AstraliteCount++;
            }

            if (Player.armor[2].type == ModContent.ItemType<StarLegs>())
            {
                AstraliteCount++;
            }

            return AstraliteCount;
        }

        #endregion

        #region astronaut

        public static bool WearingAstroHelm { get; set; }
        public static bool WearingFullAstro { get; set; }
        public static bool WearingTwoAstroPieces { get; set; }
        public static bool WearingOneAstroPiece { get; set; }
        public static bool WearingAnyAstro { get; set; }

        [JITWhenModsEnabled("SpiritMod")]
        public int PiecesAstroArmour()
        {
            int astroCount = 0;

            if (Player.armor[0].type == ModContent.ItemType<AstronautHelm>())
            {
                astroCount++;
                WearingAstroHelm = true;
            }
            else
            {
                WearingAstroHelm = false;
            }

            if (Player.armor[1].type == ModContent.ItemType<AstronautBody>())
            {
                astroCount++;
            }

            if (Player.armor[2].type == ModContent.ItemType<AstronautLegs>())
            {
                astroCount++;
            }

            return astroCount;
        }

        #endregion

        #region fishbowl

        public static bool IsWearingFishBowl { get; set; }

        public bool WearingFishBowl() => Player.armor[0].type == ItemID.FishBowl;

        #endregion

        public static bool WearingFullMetal { get; set; }
        public static bool WearingTwoMetalPieces { get; set; }
        public static bool WearingOneMetalPiece { get; set; }
        public static bool WearingAnyMetal { get; set; }

        public int IsWearingMetal()
        {
            int num = 0;
            for (int i = 0; i < 3; i++)
            {
                if (VanillaMetallicSets.MetallicArmourSets.Contains(Player.armor[i].type)) { num++; }
            }
            return num;
        }

        #region Register

        public override void PostUpdateEquips()
        {
            int leadCount = PiecesLeadArmour();

            WearingFullLead = leadCount == 3;
            WearingTwoLeadPieces = leadCount == 2;
            WearingOneLeadPiece = leadCount == 1;
            WearingAnyLead = leadCount > 0;

            int armourCount = PiecesArmour();

            WearingFullArmour = armourCount == 3;
            WearingTwoArmourPieces = armourCount == 2;
            WearingOneArmourPiece = armourCount == 1;
            WearingAnyArmour = armourCount > 0;

            int eskimoCount = PiecesEskimoArmour();

            WearingFullEskimo = eskimoCount == 3;
            WearingTwoEskimoPieces = eskimoCount == 2;
            WearingOneEskimoPiece = eskimoCount == 1;
            WearingAnyEskimo = eskimoCount > 0;

            IsWearingFishBowl = WearingFishBowl();

            int TungstenCount = PiecesTungstenArmour();

            WearingFullTungsten = TungstenCount == 3;
            WearingTwoTungstenPieces = TungstenCount == 2;
            WearingOneTungstenPiece = TungstenCount == 1;
            WearingAnyTungsten = TungstenCount > 0;

            if (LuneLib.instance.SpiritModLoaded)
            {
                int astraliteCount = PiecesAstraliteArmour();

                WearingFullAstro = astraliteCount == 3;
                WearingTwoAstroPieces = astraliteCount == 2;
                WearingOneAstroPiece = astraliteCount == 1;
                WearingAnyAstro = astraliteCount > 0;

                int astroCount = PiecesAstroArmour();

                WearingFullAstro = astroCount == 3;
                WearingTwoAstroPieces = astroCount == 2;
                WearingOneAstroPiece = astroCount == 1;
                WearingAnyAstro = astroCount > 0;
            }
        }

        #endregion

        #endregion
    }
}
