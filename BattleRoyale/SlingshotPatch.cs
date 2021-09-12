using Netcode;
using StardewValley.Projectiles;
using System;

namespace BattleRoyale
{
    class SlingshotPatch1 : Patch
    {
        protected override PatchDescriptor GetPatchDescriptor() => new PatchDescriptor(typeof(BasicProjectile), null, new Type[0]);

        public static void Postfix(BasicProjectile __instance)
        {
            var r = ModEntry.BRGame.ModHelper.Reflection;
            r.GetField<NetBool>(__instance, "damagesMonsters").SetValue(new NetBool(false));
            r.GetField<NetInt>(__instance, "damageToFarmer").SetValue(new NetInt(15));
        }
    }



    /*class SlingshotPatch6 : Patch
    {
        protected override PatchDescriptor GetPatchDescriptor() => new PatchDescriptor(typeof(Projectile), "isColliding");

        public static void Postfix(Projectile __instance, GameLocation location, ref bool __result)
        {
            if (!__result)
            {
                //  x / Game1.tileSize, y / Game1.tileSize
                var center = __instance.getBoundingBox().Center;
                var centerTile = new Vector2((int)(center.X / Game1.tileSize), (int)(center.Y / Game1.tileSize));
                if (location.objects.TryGetValue(centerTile, out StardewValley.Object obj) && obj.Name.ToLower().Contains("fence"))
                {
                    __result = true;
                }
            }
        }
    }*/






}
