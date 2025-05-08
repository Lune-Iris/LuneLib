namespace LuneLib;

public partial class LuneLib : Mod
{
    public enum MessageType : byte { SetLuneIndex }

    public override void HandlePacket(BinaryReader reader, int whoAmI)
    {
        MessageType msg = (MessageType)reader.ReadByte();
        if (msg == MessageType.SetLuneIndex)
        {
            byte luneSlot = reader.ReadByte();
            if (Main.netMode == NetmodeID.Server)
            {
                var pkt = GetPacket();
                pkt.Write((byte)MessageType.SetLuneIndex);
                pkt.Write(luneSlot);
                pkt.Send();
            }
            LuneSync.LuneWhoAmI = luneSlot;
        }
    }
}
