using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Harmony;
using System.Reflection;

namespace More_World_Traits
{
    [HarmonyPatch(typeof(EntityConfigManager))]
    [HarmonyPatch("LoadGeneratedEntities")]
    public static class EntityConfigManager_LoadGeneratedEntities_Patch
    {
        static void Prefix()
        {
            Strings.Add("STRINGS.WORLD_TRAITS.LUSH.NAME", "Lush");
            Strings.Add("STRINGS.WORLD_TRAITS.LUSH.DESCRIPTION", "This world supports an unusual variety of plant and animal life.");

            Strings.Add("STRINGS.WORLD_TRAITS.CHASMS.NAME", "Chasms");
            Strings.Add("STRINGS.WORLD_TRAITS.CHASMS.DESCRIPTION", "Large chasms cut through this world.");

            Strings.Add("STRINGS.WORLD_TRAITS.CRYOVOLCANOES.NAME", "Cryovolcanoes");
            Strings.Add("STRINGS.WORLD_TRAITS.CRYOVOLCANOES.DESCRIPTION", "Super-cold volcanoes spew liquid carbon dioxide.");

            Strings.Add("STRINGS.WORLD_TRAITS.GASPOCKETS.NAME", "Gas Pockets");
            Strings.Add("STRINGS.WORLD_TRAITS.CRYOVOLCANOES.DESCRIPTION", "This world contains pockets of highly-compressed gas.");
        }
    }
}