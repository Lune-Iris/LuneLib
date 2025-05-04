using LuneLib.Common.Players.LuneLibPlayer;
using System.IO;
using Terraria;
using Terraria.ModLoader;

namespace LuneLib
{
    public partial class LuneLib : Mod
    {
        public enum PacketType : byte
        {
            SyncEyes
        }

        public override void HandlePacket(BinaryReader reader, int whoAmI)
        {
            PacketType type = (PacketType)reader.ReadByte();
            switch (type)
            {
                case PacketType.SyncEyes:
                    byte playerIndex = reader.ReadByte();
                    bool closed = reader.ReadBoolean();
                    if (playerIndex >= 0 && playerIndex < Main.maxPlayers)
                    {
                        Main.player[playerIndex].GetModPlayer<LibPlayer>().forceEyesClosed = closed;
                    }
                break;
            }
        }
    }
}
