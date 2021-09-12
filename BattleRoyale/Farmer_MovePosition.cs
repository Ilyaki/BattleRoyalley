using Microsoft.Xna.Framework;
using StardewValley;
namespace BattleRoyale
{
    class Farmer_MovePosition : Patch
    {
        // I always want to trigger that a farmer's invuln timer should decrease
        protected override PatchDescriptor GetPatchDescriptor() => new PatchDescriptor(typeof(Farmer), "MovePosition");

        public static void Postfix(GameTime time, ref Farmer __instance)
        {
            if (__instance.temporarilyInvincible)
            {
                __instance.temporaryInvincibilityTimer += time.ElapsedGameTime.Milliseconds;
                if (__instance.temporaryInvincibilityTimer > 1200)
                {
                    __instance.temporarilyInvincible = false;
                    __instance.temporaryInvincibilityTimer = 0;
                }
            }
        }
    }
}
