using LuneLib.Common.Players.LuneLibPlayer;
using LuneLib.Core.Config;
using LuneLib.Utilities;
using Steamworks;
using System;
using Terraria;
using Terraria.GameContent;
using Terraria.ModLoader;
using static Terraria.GameContent.PlayerEyeHelper;

namespace LuneLib
{
    public partial class LuneLib : Mod
    {
        public static LuneLib instance;
        public static Debug debug;
        public static Client clientConfig;
        public static Server serverConfig;

        public bool
            LuneLibAssetsLoaded,
            CalamityModLoaded,
            InfernumModeLoaded,
            CalValExLoaded,
            CalamitasMommyLoaded,
            ThoriumModLoaded,
            VanillaQoLLoaded,
            SpiritModLoaded,
            StrongerReforgesLoaded,
            BrighterLightLoaded,
            CoyoteframesLoaded,
            ChatSourceLoaded,
            DarkSurfaceLoaded;

        public static CSteamID steamID;

        public override void Load()
        {
            instance = this;
            steamID = SteamUser.GetSteamID();
            LuneLibAssetsLoaded = ModLoader.HasMod("LuneLibAssets");
            CalamityModLoaded = ModLoader.HasMod("CalamityMod");
            InfernumModeLoaded = ModLoader.HasMod("InfernumMode");
            CalValExLoaded = ModLoader.HasMod("CalValEx");
            CalamitasMommyLoaded = ModLoader.HasMod("CalamitasMommy");
            ThoriumModLoaded = ModLoader.HasMod("ThoriumMod");
            VanillaQoLLoaded = ModLoader.HasMod("VanillaQoL");
            SpiritModLoaded = ModLoader.HasMod("SpiritMod");
            StrongerReforgesLoaded = ModLoader.HasMod("StrongerReforges");
            BrighterLightLoaded = ModLoader.HasMod("BrighterLight");
            CoyoteframesLoaded = ModLoader.HasMod("Coyoteframes");
            ChatSourceLoaded = ModLoader.HasMod("ChatSource");
            DarkSurfaceLoaded = ModLoader.HasMod("DarkSurface");
            if (debug.LL)
            { On_PlayerEyeHelper.SetStateByPlayerInfo += PlayerEyeHelper_SetStateByPlayerInfo; }
        }

        public override void Unload()
        {
            instance = null;
            debug = null;
            clientConfig = null;
            serverConfig = null;
        }

        private void PlayerEyeHelper_SetStateByPlayerInfo(On_PlayerEyeHelper.orig_SetStateByPlayerInfo orig, ref PlayerEyeHelper self, Player player)
        {
            orig(ref self, player);

            var modPlayer = player.GetModPlayer<LibPlayer>();

            if (modPlayer.forceEyesClosed)
            {
                try
                {
                    if (!player.OceanMan())
                        self.SwitchToState(EyeState.IsBlind);
                    else
                        self.SwitchToState(EyeState.NormalBlinking);
                }
                catch (Exception e)
                {
                    Logger.Error($"Aw shit… error_ref: {e.Message}");
                }
            }
        }
    }
}
