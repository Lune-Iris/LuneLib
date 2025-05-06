using LuneLib.Utilities;
using Steamworks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace LuneLib.Common.Players.LuneLibPlayer
{
    public class LuneSync : ModPlayer
    {
        public static int LuneWhoAmI = -1;

        public override void PostUpdate()
        {
            if (LuneLibUtils.Wait(1000))
            { 
                Main.NewText($"PlayerID: {Player.whoAmI} || Who is Lune: {LuneWhoAmI} || Am I Lune: {AmILuneBySteamID()} || SteamID: {SteamUser.GetSteamID()}"); 
            }
        }

        public override void SyncPlayer(int toWho, int fromWho, bool newPlayer)
        {
            var pkt = Mod.GetPacket();
            pkt.Write((byte)LuneLib.MessageType.SetLuneIndex);
            pkt.Write((byte)LuneWhoAmI);
            pkt.Send(toWho, fromWho);
        }

        public bool AmILuneBySteamID()
        {
            CSteamID id = SteamUser.GetSteamID();
            return id.m_SteamID == 76561198818748376UL;
        }

        public override void OnEnterWorld()
        {
            if (Main.netMode != NetmodeID.SinglePlayer && Main.myPlayer == Player.whoAmI && AmILuneBySteamID())
            {
                var pkt = Mod.GetPacket();
                pkt.Write((byte)LuneLib.MessageType.SetLuneIndex);
                pkt.Write((byte)Player.whoAmI);
                pkt.Send();
            }
        }
    }
}