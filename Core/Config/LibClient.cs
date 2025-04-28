using System.ComponentModel;
using Terraria.ModLoader.Config;

namespace LuneLib.Core.Config
{
    public class Client : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ClientSide;

        [Header("Spammy")]

        [DefaultValue(false)]
        public bool DebugMessages { get; set; }

        [DefaultValue(true)]
        public bool dayshelptext { get; set; }

        [DefaultValue(true)]
        public bool Days { get; set; }

        public override void OnLoaded()
        {
            LuneLib.clientConfig = this;
        }
    }
}