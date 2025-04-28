using System.Collections.Generic;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.UI;
using static LuneLib.Utilities.LuneLibUtils;

namespace LuneLib.Common.Systems
{
    public class LLibSystem : ModSystem
    {
        public override bool IsLoadingEnabled(Mod mod)
        {
            return LuneLib.clientConfig.Days;
        }
        private int
            dayCount = 0,
            TR2A = 255,
            TR1A = 255,
            DCA = 255,
            reset1pos = 325;

        private bool
            wasDay = false,
            day6StartTimerDone = false,
            sent = false,
            _flag0 = true,
            _flag1 = true,
            _flag2 = true,
            _flag3 = true,
            _flag4 = true,
            _flag5 = true,
            _flag6 = true,
            _flag7 = true;

        public override void ModifyInterfaceLayers(List<GameInterfaceLayer> layers)
        {
            if (!LogarithmicComplete.ContainsKey("reset1posK"))
            {
                LogarithmicComplete.Add("reset1posK", false);
            }

            bool isDay = Main.dayTime;
            if (isDay && !wasDay)
            {
                dayCount++;
                sent = false;
                _flag0 = true;
                _flag1 = true;
                _flag2 = true;
                _flag3 = true;
                _flag4 = true;
                _flag5 = true;
                _flag6 = true;
                _flag7 = true;
                reset1pos = 325;
                TR2A = 255;
                TR1A = 255;
                DCA = 255;
                day6StartTimerDone = false;
                LogarithmicComplete["reset1posK"] = false;
            }

            if (_flag0)
            {
                ResetTimer("timertimer");
                _flag0 = false;
            }
            else if (WaitNamed("timertimer", 6000) && !sent)
            {
                sent = true;
            }

            wasDay = isDay;

            if (dayCount > 6)
            {
                dayCount = 1;
            }

            if (_flag5)
            {
                ResetTimer("DCA");
                _flag5 = false;
            }
            if (WaitNamed("DCA", 3000))
            {
                DCA--;
                if (DCA < 0)
                { DCA = 0; }
            }

            if (dayCount != 0 && L.whoAmI == Main.myPlayer && LuneLib.clientConfig.Days && !sent && !WaitNamed("timertimer", 6000))
            {
                ScreenMessage
                (
                    Language.GetTextValue($"Mods.LuneLib.Messages.Chat.Isle.Day{dayCount}"),
                    1.5f, 300, 255, 255, 0, DCA, 0
                );
                if (LuneLib.clientConfig.dayshelptext)
                {
                    ScreenMessage
                    (
                        Language.GetTextValue("Mods.LuneLib.Messages.Chat.Isle.SHUTUPPPPP"),
                        0.75f, 350, 165, 0, 35, DCA, 0
                    );
                }
            }


            if (dayCount == 6)
            {
                if (_flag1)
                {
                    ResetTimer("day6StartTimer");
                    _flag1 = false;
                }
                if (WaitNamed("day6StartTimer", 5000))
                {
                    if (_flag2)
                    {
                        ResetTimer("reset1Timer");
                        _flag2 = false;
                    }
                    if (!WaitNamed("reset1Timer", 9000))
                    {
                        ScreenMessage
                        (
                            Language.GetTextValue("Mods.LuneLib.Messages.Chat.Isle.TheReset1"),
                            1.5f, reset1pos, 7, 242, 242, TR1A, 0
                        );
                        if (_flag6)
                        {
                            ResetTimer("TR1A");
                            _flag6 = false;
                        }
                        if (WaitNamed("TR1A", 6000))
                        {
                            TR1A--;
                            if (TR1A < 0)
                            { TR1A = 0; }
                        }
                        day6StartTimerDone = true;
                    }
                }
                if (day6StartTimerDone)
                {
                    if (_flag3)
                    {
                        ResetTimer("reset2StartTimer2");
                        ResetTimer("reset2Timer");
                        _flag3 = false;
                    }
                    if (WaitNamed("reset2StartTimer2", 4000))
                    {
                        if (!LogarithmicComplete["reset1posK"])
                        {
                            reset1pos = (int)LogarithmicTransition("reset1posK", 325, 290, -2D, 0.05D);
                        }
                        if (_flag4)
                        {
                            ResetTimer("reset2StartTimer3");
                            _flag4 = false;
                        }
                        if (!WaitNamed("reset2StartTimer3", 8000))
                        {
                            ScreenMessage
                            (
                                Language.GetTextValue("Mods.LuneLib.Messages.Chat.Isle.TheReset2"),
                                1.5f, 325, 7, 242, 242, TR2A, 0
                            );
                            if (_flag7)
                            {
                                ResetTimer("TR2A");
                                _flag7 = false;
                            }
                            if (WaitNamed("TR2A", 5000))
                            {
                                TR2A--;
                                if (TR2A < 0)
                                { TR2A = 0; }
                            }
                        }
                    }
                }
            }
        }
    }
}