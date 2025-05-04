using LuneLib.Utilities;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.Events;
using Terraria.ID;
using Terraria.ModLoader;
using static LuneLib.Utilities.LuneLibUtils;

namespace LuneLib.Common.Players.LuneLibPlayer
{
    public partial class LibPlayer : ModPlayer
    {
        public override void OnEnterWorld()
        {
            IsLune = Player.LuneL();
        }

        public void LunesEyes()
        {
            bool shouldForceOpen = Player.LuneL() && Player.OceanMan();

            bool shouldCloseEyes = Player.LuneL() && !shouldForceOpen;

            if (forceEyesClosed != shouldCloseEyes)
            {
                forceEyesClosed = shouldCloseEyes;
                SyncEyeState(Player.whoAmI, forceEyesClosed);
            }
        }

        public override void PostUpdate()
        {
            LunesEyes();

            float value = 0f;
            float amount = 0.1f;
            if (Player.LibPlayer().LStormEyeCovered && Player.whoAmI == Main.myPlayer)
            {
                value = 0.8f;
                amount = 0.1f;
            }
            ScreenObstruction.screenObstruction = MathHelper.Lerp(ScreenObstruction.screenObstruction, value, amount);
        }

        public void SyncEyeState(int whoAmI, bool closed)
        {
            if (Main.netMode == NetmodeID.SinglePlayer)
                return;

            ModPacket packet = Mod.GetPacket();
            packet.Write((byte)LuneLib.PacketType.SyncEyes);
            packet.Write((byte)whoAmI);
            packet.Write(closed);
            packet.Send();
        }
    }
}
