using LuneLib.Utilities;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.Events;
using Terraria.ModLoader;
using static LuneLib.Utilities.LuneLibUtils;

namespace LuneLib.Common.Players.LuneLibPlayer;

public partial class LibPlayer : ModPlayer
{
    public override void PostUpdate() => ReduceVisionInStorms();

    public void ReduceVisionInStorms()
    {
        float value = 0f;
        float amount = 0.1f;
        if (Player.LibPlayer().LStormEyeCovered && Player.whoAmI == Main.myPlayer)
        {
            value = 0.8f;
            amount = 0.1f;
        }
        ScreenObstruction.screenObstruction = MathHelper.Lerp(ScreenObstruction.screenObstruction, value, amount);
    }
}
