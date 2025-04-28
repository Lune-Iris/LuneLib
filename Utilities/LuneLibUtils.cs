using CalamityMod.BiomeManagers;
using LuneLib.Common.NPCs.LuneLibNpc;
using LuneLib.Common.Players.LuneLibPlayer;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using Terraria;
using Terraria.GameContent;
using Terraria.Localization;
using Terraria.ModLoader;

using static LuneLib.LuneLib;

namespace LuneLib.Utilities
{
    public static class LuneLibUtils
    {
        #region fields and properties go ehre plss -w-

        /// <summary>
        /// L is just Main.CurrentPlayer
        /// </summary>
        public static Player L => Main.CurrentPlayer;

        /// <summary>
        /// Local Player
        /// </summary>
        public static Player LP => Main.LocalPlayer;

        /// <summary>
        /// Checks if it's my SteamID
        /// </summary>
        public static bool LL => LuneL(L);
        public static bool LE => LuneE(L);

        public static bool ZoneOcean => L.ZoneBeach;

        [JITWhenModsEnabled("CalamityMod")]
        public static bool ZoneSunkenSea => L.InModBiome(ModContent.GetInstance<SunkenSeaBiome>());

        [JITWhenModsEnabled("CalamityMod")]
        public static bool ZoneSulphur => L.InModBiome(ModContent.GetInstance<SulphurousSeaBiome>());

        [JITWhenModsEnabled("CalamityMod")]
        public static bool ZoneAbyssLayer1 => L.InModBiome(ModContent.GetInstance<AbyssLayer1Biome>());

        [JITWhenModsEnabled("CalamityMod")]
        public static bool ZoneAbyssLayer2 => L.InModBiome(ModContent.GetInstance<AbyssLayer2Biome>());

        [JITWhenModsEnabled("CalamityMod")]
        public static bool ZoneAbyssLayer3 => L.InModBiome(ModContent.GetInstance<AbyssLayer3Biome>());

        [JITWhenModsEnabled("CalamityMod")]
        public static bool ZoneAbyssLayer4 => L.InModBiome(ModContent.GetInstance<AbyssLayer4Biome>());

        [JITWhenModsEnabled("CalamityMod")]
        public static bool ZoneAbyss => ZoneAbyssLayer1 || ZoneAbyssLayer2 || ZoneAbyssLayer3 || ZoneAbyssLayer4;

        [JITWhenModsEnabled("CalamityMod")]
        public static bool ZoneAquatic => ZoneSulphur || ZoneOcean || ZoneSunkenSea;

        private static Texture2D messageBackground;
        #endregion

        #region help
        public static readonly Dictionary<int, Stopwatch> timers = [];

        public static bool Wait(int milliseconds)
        {
            if (!timers.ContainsKey(milliseconds))
            {
                timers[milliseconds] = new Stopwatch();
                timers[milliseconds].Start();
            }

            var stopwatch = timers[milliseconds];

            if (stopwatch.ElapsedMilliseconds >= milliseconds)
            {
                stopwatch.Restart();
                return true;
            }

            return false;
        }

        public static readonly Dictionary<string, Stopwatch> timersnmd = [];

        public static bool WaitNamed(string name, int milliseconds)
        {
            if (!timersnmd.ContainsKey(name))
            {
                timersnmd[name] = new Stopwatch();
                timersnmd[name].Start();
            }

            var stopwatch = timersnmd[name];

            if (stopwatch.ElapsedMilliseconds >= milliseconds)
            {
                if (stopwatch.IsRunning)
                {
                    stopwatch.Stop();
                }
                return true;
            }

            return false;
        }
        public static void ResetTimer(string name)
        {
            if (timersnmd.ContainsKey(name))
            {
                timersnmd[name].Restart();
            }
        }

        public static int TimeLeftNamed(string name, int milliseconds)
        {
            if (!timersnmd.ContainsKey(name))
            {
                return milliseconds;
            }
            var stopwatch = timersnmd[name];
            if (!stopwatch.IsRunning)
            {
                return 0;
            }
            int elapsed = (int)stopwatch.ElapsedMilliseconds;
            return Math.Max(0, milliseconds - elapsed);
        }


        private static void MessageBackground()
        {
            if (messageBackground == null)
            {
                messageBackground = new Texture2D(Main.graphics.GraphicsDevice, 1, 1);
                messageBackground.SetData([Color.White]);
            }
        }

        /// <summary>
        /// Shows a message on your screen.
        /// </summary>
        /// <param name="input"></param>
        /// <param name="textSize"></param>
        /// <param name="textHeight"></param>
        /// <param name="textR"></param>
        /// <param name="textG"></param>
        /// <param name="textB"></param>
        /// <param name="bgA"></param>
        /// <param name="bgR"></param>
        /// <param name="bgG"></param>
        /// <param name="bgB"></param>
        public static void ScreenMessage(
            string input,
            float textSize,
            int textHeight,
            int textR = 0, int textG = 0, int textB = 0, int textA = 255,
            int bgA = 255, int bgR = 0, int bgG = 0, int bgB = 0)
        {
            MessageBackground();

            Main.spriteBatch.Begin(
                SpriteSortMode.Deferred,
                BlendState.AlphaBlend,
                SamplerState.PointClamp,
                DepthStencilState.None,
                RasterizerState.CullCounterClockwise,
                null,
                Main.UIScaleMatrix);

            Color textColor = new Color(textR, textG, textB) * (textA / 255f);
            Color backgroundColor = new Color(bgR, bgG, bgB, bgA);

            DynamicSpriteFont font = FontAssets.MouseText.Value;
            Vector2 textPosition = new Vector2(Main.screenWidth / 2, Main.screenHeight / 2 + textHeight);
            Vector2 stringSize = font.MeasureString(input) * textSize;
            textPosition.X -= stringSize.X / 2;

            if (bgA != 0)
            {
                Rectangle backgroundRectangle = new Rectangle(0, 0, Main.screenWidth + 32, Main.screenHeight + 32);
                Main.spriteBatch.Draw(messageBackground, backgroundRectangle, backgroundColor);
            }

            Main.spriteBatch.DrawString(font, input, textPosition, textColor, 0f, Vector2.Zero, textSize, SpriteEffects.None, 0f);
            Main.spriteBatch.End();
        }


        public static LocalizedText GetText(string key)
        {
            return Language.GetOrRegister($"Mods.LuneLib.{key}");
        }

        public static readonly Dictionary<string, double> VelocityKeys = [], Results = [];
        public static readonly Dictionary<string, bool> LogarithmicComplete = [];
        private static readonly Dictionary<string, DateTime> LastUpdateTime = [];

        /// <summary>
        /// Don't use this unless youre schizophrenic like me. It's just that annoying to use...
        /// Logarithmically transitions one number to another
        /// Use LogarithmicComplete[key] to check if the transition is done
        /// 
        /// key is a unique string you have to give
        /// </summary>
        /// <param name="key"></param>
        /// <param name="startPosition"></param>
        /// <param name="targetPosition"></param>
        /// <param name="initialVelocity"></param>
        /// <param name="friction"></param>
        /// <returns></returns>
        public static double LogarithmicTransition(string key, int startPosition, int targetPosition, double initialVelocity, double friction)
        {
            double frameTime = 1.0 / 60.0; // stupid fucking High FPS Support messed with me :sob:
            DateTime currentTime = DateTime.UtcNow;

            if (!LastUpdateTime.ContainsKey(key))
                LastUpdateTime[key] = currentTime;

            if ((currentTime - LastUpdateTime[key]).TotalSeconds < frameTime)
                return Results.ContainsKey(key) ? Results[key] : startPosition; // i dont WANNA use trygetvalue so SHUT THE FUCK UP

            LastUpdateTime[key] = currentTime;

            if (!LogarithmicComplete.ContainsKey(key) || !LogarithmicComplete[key])
            {
                if (!VelocityKeys.ContainsKey(key))
                {
                    VelocityKeys[key] = initialVelocity;
                }
                if (!Results.ContainsKey(key))
                {
                    Results[key] = startPosition;
                }
            }

            if (Results[key] > targetPosition)
            {
                double distance = targetPosition - Results[key];
                double adjustedVelocity = VelocityKeys[key] * ((distance / (targetPosition - startPosition)) + 0.0001D); // just so it doesnt get stuck we add 0.0001 yea you get it
                Results[key] += adjustedVelocity;
                if (Results[key] < targetPosition)
                    Results[key] = targetPosition;
                VelocityKeys[key] -= friction;
                return Results[key];
            }
            else if (!LogarithmicComplete[key])
            {
                VelocityKeys.Remove(key);
                Results.Remove(key);
                LogarithmicComplete[key] = true;
                return targetPosition;
            }
            return targetPosition;
        }

        #endregion

        #region LL
        /// <summary>
        /// Checks if it's my SteamID
        /// </summary>
        /// <param name="player"></param>
        /// <returns></returns>
        public static bool LuneL(this Player player)
        {
            if (steamID.ToString() == "76561198818748376" && debug.LL && !debug.TestMode && !player.dead)
                return true;
            else if (player.name == "fish" && debug.LL && debug.TestMode)
                return true;
            return false;
        }
        #endregion

        #region LE
        /// <summary>
        /// Checks if it's a past artists SteamID
        /// </summary>
        /// <param name="player"></param>
        /// <returns></returns>
        public static bool LuneE(this Player player) => steamID.ToString() == "76561198348118589" && debug.LL && player.whoAmI == Main.myPlayer;
        #endregion

        #region player
        public static LibPlayer LibPlayer(this Player player) => player.GetModPlayer<LibPlayer>();
        #endregion

        #region npc
        public static LibNpcData LibNPC(this NPC npc) => npc.GetGlobalNPC<LibNpcData>();
        #endregion

        #region checks
        public static bool OceanMan(this Player player) => Collision.DrownCollision(player.position, player.width, player.height, player.gravDir);

        #endregion

        public static float ToPercentage(int value)
        {
            if (value < 0) value = 0;
            if (value > 100) value = 100;
            return value / 100;
        }
        public static void FuckingShit(string message)
        {
            if (clientConfig.DebugMessages)
            {
                string header = "LuneLib: ";
                if (Main.dedServ)
                {
                    Console.WriteLine(header + message);
                }
                else
                {
                    if (Main.gameMenu)
                    {
                        instance.Logger.Debug(header + Main.myPlayer + ": " + message);
                    }
                    else
                    {
                        Main.NewText(header + message);
                    }
                }
            }
        }
    }
}
