using Alta.Networking;
using Alta.Networking.Servers;
using MelonLoader;
using MateriaLib;
using HarmonyLib;
using System.Reflection;

[assembly: MelonInfo(typeof(ForceDurability.Core), "ForceDurability", "1.0.0", "CGNik", null)]
[assembly: MelonGame("Alta", "A Township Tale")]

namespace ForceDurability
{
    public class GetMultiplierPatch
    {
        internal static void Postfix(PhysicalMaterial physicalMaterial, ref float __result)
        {
            if (physicalMaterial == null)
            {
                __result = 1f;
                return;
            }

            __result = physicalMaterial.DurabilityMultiplier;
            return;
        }
    }

    public class Core : MelonMod
    {
        public override void OnInitializeMelon()
        {
            LoggerInstance.Msg("Initialized.");
            ServerHandler.Initialized += ServerInitialized;
            MateriaLib.Main.PostSetupMaterial += PostSetupMaterial;
        }

        private void ServerInitialized(ServerHandler handler)
        {
            Type materialDurability = AccessTools.TypeByName("MateriaLib.MaterialDurability");
            HarmonyInstance.Patch(AccessTools.Method(materialDurability, "GetMultiplier"), postfix: new HarmonyMethod(typeof(GetMultiplierPatch), nameof(GetMultiplierPatch.Postfix)));
        }

        private void PostSetupMaterial()
        {
            foreach (LibMaterial material in LibMaterial.NewMaterials)
            {
                material.useDurabilityMultiplier = true;
            }

            MateriaLib.Main.vanillaDurability.Value = true;
            MelonPreferences.Save();
        }
    }
}