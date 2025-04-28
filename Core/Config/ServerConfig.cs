using System.ComponentModel;
using Terraria.ModLoader.Config;

namespace LuneLib.Core.Config
{
    public class Server : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ServerSide;

        [Header("Spammy")]

        [DefaultValue(true)]
        public bool FreddyFiveBear { get; set; }

        public override void OnLoaded()
        {
            LuneLib.serverConfig = this;
        }
    }
}