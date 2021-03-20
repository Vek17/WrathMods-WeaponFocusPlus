using UnityModManagerNet;
using HarmonyLib;
using static UnityModManagerNet.UnityModManager;

namespace WeaponFocusPlus {
    static class Main {

        public static bool Enabled = true;
        public static ModEntry Mod;

        static bool Load(UnityModManager.ModEntry modEntry) {
            var harmony = new Harmony(modEntry.Info.Id);
            Mod = modEntry;
            harmony.PatchAll();
            Main.Log("DEBUG LOGGING ENABLED");
            return true;
        }

        static bool OnToggle(UnityModManager.ModEntry modEntry, bool value) {
            Enabled = value;
            return true;
        }

        [System.Diagnostics.Conditional("DEBUG")]
        public static void Log(string msg) {
            Mod.Logger.Log(msg);
        }
    }
}