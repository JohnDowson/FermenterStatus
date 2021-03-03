using BepInEx;
using HarmonyLib;
using System.Linq;

namespace FermenterStatus
{
    [BepInPlugin("com.github.johndowson.fermenterstatus", "FermenterStatus", "1.0.0")]
    public class FermenterStatus : BaseUnityPlugin
    {
        private static readonly Harmony harmony = new(typeof(FermenterStatus).GetCustomAttributes(typeof(BepInPlugin), false)
            .Cast<BepInPlugin>()
            .First()
            .GUID);

#pragma warning disable IDE0051 // Remove unused private members
        private void Awake()
        {
            harmony.PatchAll();
        }

        private void OnDestroy()
        {
            harmony.UnpatchSelf();
        }

        [HarmonyPatch(typeof(Fermenter), "GetHoverText")]
        public static class FermentationPercentage_Patch
        {
            public static string Postfix(string __result, Fermenter __instance)
            {
                string contentName = __instance.GetContentName();
                string resultIfFermenting = Localization.instance.Localize(__instance.m_name + " ( " + contentName + ", $piece_fermenter_fermenting )");
                if (__result == resultIfFermenting)
                {
                    __result = Localization.instance.Localize(__instance.m_name +
                        " ( " + contentName +
                        ", $piece_fermenter_fermenting " +
                        __instance.GetFermentationPercentage() + "%" +
                        " )");
                }
                return __result;
            }

        }
    }
}