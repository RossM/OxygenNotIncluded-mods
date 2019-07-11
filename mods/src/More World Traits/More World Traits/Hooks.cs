using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Harmony;
using ProcGenGame;
using System.Reflection;
using ProcGen;
using System.Runtime.CompilerServices;

namespace More_World_Traits
{
    public static class WorldGenSettings_ctor_Patch
    {
        public static void Postfix(string worldName, List<string> traits, WorldGenSettings __instance)
        {
        }

        public static void Patch(HarmonyInstance harmony)
        {
            MethodInfo postfix = typeof(WorldGenSettings_ctor_Patch).GetMethod("Postfix");
            var constructor = typeof(WorldGenSettings).GetConstructor(new[] { typeof(string), typeof(List<string>) });

            Debug.LogFormat("postfix: {0}", postfix);

            harmony.Patch(constructor, postfix: new HarmonyMethod(postfix));
        }
    }

    public static class PatchMain
    {
        // This function is called by the ONI modloader
        public static void PostPatch(HarmonyInstance harmony)
        {
            Debug.Log("In PostPatch");
            try
            {
                TerrainCell_GetTemperatureRange_Patch.Patch(harmony);

                WorldGenSettings_ctor_Patch.Patch(harmony);
            }
            catch (Exception e)
            {
                Debug.Log(e);
                throw e;
            }
        }

    }

    public static class TerrainCell_GetTemperatureRange_Patch
    {
        // Allows modifying the overall temperature of a world
        public static void Postfix(WorldGen worldGen, ref float min, ref float range)
        {
        }

        public static void Patch(HarmonyInstance harmony)
        {
            var postfix = typeof(TerrainCell_GetTemperatureRange_Patch).GetMethod("Postfix");

            var refFloat = typeof(float).MakeByRefType();
            var original = typeof(TerrainCell).GetMethod("GetTemperatureRange", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance, null, new[] { typeof(WorldGen), refFloat, refFloat }, null);

            harmony.Patch(original, postfix: new HarmonyMethod(postfix));
        }

    }
}
