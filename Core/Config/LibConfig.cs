using System.ComponentModel;
using Terraria.ModLoader.Config;

namespace LuneLib.Core.Config
{
    public class Debug : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ServerSide;

        [Header("Debug")]

        [DefaultValue(false)]
        [ReloadRequired]
        public bool TestMode { get; set; }

        [DefaultValue(false)]
        [ReloadRequired]
        public bool LL { get; set; }

        public override void OnLoaded()
        {
            LuneLib.debug = this;
        }
    }
}