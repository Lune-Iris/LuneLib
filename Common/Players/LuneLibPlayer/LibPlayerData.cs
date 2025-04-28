using Terraria.ModLoader;

namespace LuneLib.Common.Players.LuneLibPlayer
{
    public partial class LibPlayer : ModPlayer
    {
        #region All My Mods stuff

        #region Lunes Worse of Life

        public bool BoilFreeze = false; // In-space debuff
        public bool BlizzardFrozen = false; //Frozen Blizzard
        public bool Chilly = false; //in tundra
        public bool LeadPoison = false; // weaing lead armour
        public bool CrimtuptionzoneNight = false; // In crimtuption during night
        public bool HeatStroke = false; // heat stroking my dick i got lotion on my dick man im a freak though for real
        public bool depthwaterPressure = false; // owie not the billionare sub!!1
        public bool LWaterEyes = false; // used for darker waters
        public bool LStormEyeCovered = false; // i think this is for the blizzard and or the sandstorm

        public int currentDepthPressure = 0; // how deep = how many damage taje!!!1

        #endregion

        #region Calamitas Mommy (Lunes Shitty Mod PRIVATE)

        public bool WConvert = false; // Private, just for fun trollling xd x3 :3 nyaa meow ;3 mrrp meeewwww mrrowww meow meow converts all projectiles you shoot to wulfrum blasts beucase i thought id be funny
        public bool LcDepth = false; // Custom crush depth debuff
        public bool LTOceanH = false; // placeholder i forgot

        #endregion

        #endregion

        #region electromagclass

        public float ElectroMagDamageAdd;
        public float ElectroMagDamageMult = 1f;

        #endregion

        public bool LunesSpiritPet = false; // Custom pet

        public override void ResetEffects()
        {
            BoilFreeze = false;
            BlizzardFrozen = false;
            LeadPoison = false;
            CrimtuptionzoneNight = false;
            Chilly = false;
            HeatStroke = false;
            depthwaterPressure = false;
            LWaterEyes = false;
            LStormEyeCovered = false;

            currentDepthPressure = 0;

            LunesSpiritPet = false;
            WConvert = false;
            LcDepth = false;
            LTOceanH = false;
        }
    }
}
