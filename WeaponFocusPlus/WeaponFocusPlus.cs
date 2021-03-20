using System;
using UnityEngine;
using HarmonyLib;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.Enums;
using Kingmaker.Blueprints.Items.Weapons;
using Kingmaker.Items;
using Kingmaker.UI.Common;
using System.Collections.Generic;
using System.Linq;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.Localization;
using Kingmaker.Blueprints.Root;
using Kingmaker.Blueprints.Root.Strings;

namespace WeaponFocusPlus {

    public static class WeaponFocusPlus {

        static WeaponCategory[] Axes = {
            //WeaponCategory.Bardiche,
            WeaponCategory.Battleaxe,
            //WeaponCategory.DoubleAxe,
            WeaponCategory.DwarvenWaraxe,
            WeaponCategory.Greataxe,
            WeaponCategory.Handaxe,
            WeaponCategory.HeavyPick,
            WeaponCategory.LightPick,
            WeaponCategory.Tongi
            //WeaponCategory.ThrowingAxe
        };
        static WeaponCategory[] Bows = {
            WeaponCategory.Shortbow,
            WeaponCategory.Longbow
        };
        static WeaponCategory[] Close = {
            WeaponCategory.PunchingDagger,
            WeaponCategory.SpikedHeavyShield,
            WeaponCategory.SpikedLightShield,
            //WeaponCategory.UnarmedStrike,
            WeaponCategory.WeaponHeavyShield,
            WeaponCategory.WeaponLightShield
        };
        static WeaponCategory[] Crossbows = {
            WeaponCategory.HandCrossbow,
            WeaponCategory.HeavyCrossbow,
            WeaponCategory.HeavyRepeatingCrossbow,
            WeaponCategory.LightCrossbow,
            WeaponCategory.LightRepeatingCrossbow
        };
        static WeaponCategory[] Double = {
            WeaponCategory.DoubleAxe,
            WeaponCategory.DoubleSword,
            WeaponCategory.HookedHammer,
            //WeaponCategory.Quarterstaff,
            WeaponCategory.Urgrosh
        };
        static WeaponCategory[] HammersMacesFlails = {
            WeaponCategory.Club,
            WeaponCategory.EarthBreaker,
            WeaponCategory.Flail,
            WeaponCategory.Greatclub,
            WeaponCategory.HeavyFlail,
            WeaponCategory.HeavyMace,
            WeaponCategory.LightHammer,
            WeaponCategory.LightMace,
            WeaponCategory.Warhammer
        };
        static WeaponCategory[] HeavyBlades = {
            WeaponCategory.BastardSword,
            //WeaponCategory.DoubleSword,
            WeaponCategory.DuelingSword,
            WeaponCategory.ElvenCurvedBlade,
            WeaponCategory.Estoc,
            WeaponCategory.Falcata,
            WeaponCategory.Falchion,
            WeaponCategory.Greatsword,
            WeaponCategory.Longsword,
            WeaponCategory.Scimitar,
            WeaponCategory.Scythe
        };
        static WeaponCategory[] LightBlades = {
            WeaponCategory.Dagger,
            WeaponCategory.Kukri,
            WeaponCategory.Rapier,
            WeaponCategory.Shortsword,
            WeaponCategory.Sickle,
            WeaponCategory.Starknife
        };
        static WeaponCategory[] Monk = {
            WeaponCategory.Kama,
            WeaponCategory.Nunchaku,
            WeaponCategory.Quarterstaff,
            WeaponCategory.Sai,
            WeaponCategory.Shuriken,
            WeaponCategory.Siangham
        };
        static WeaponCategory[] Natural = {
            WeaponCategory.Claw,
            WeaponCategory.Bite,
            WeaponCategory.Gore,
            WeaponCategory.Tail,
            WeaponCategory.UnarmedStrike
        };
        static WeaponCategory[] Polearms = {
            WeaponCategory.Bardiche,
            WeaponCategory.Fauchard,
            WeaponCategory.Glaive
        };
        static WeaponCategory[] Spears = {
            //WeaponCategory.Javelin,
            WeaponCategory.Longspear,
            WeaponCategory.Shortspear,
            WeaponCategory.Spear,
            WeaponCategory.Trident
        };
        static WeaponCategory[] Thrown = {
            WeaponCategory.Bomb,
            WeaponCategory.Dart,
            WeaponCategory.Javelin,
            WeaponCategory.Sling,
            WeaponCategory.SlingStaff,
            WeaponCategory.ThrowingAxe
        };


        internal static WeaponFighterGroup[] GetWeaponGroups(WeaponCategory weaponCategory) {
            List<WeaponFighterGroup> groups = new List<WeaponFighterGroup>();

            if (Array.Exists(Axes, t => t == weaponCategory)) {
                groups.Add(WeaponFighterGroup.Axes);
            }
            if (Array.Exists(Bows, t => t == weaponCategory)) {
                groups.Add(WeaponFighterGroup.Bows);
            }
            if (Array.Exists(Close, t => t == weaponCategory)) {
                groups.Add(WeaponFighterGroup.Close);
            }
            if (Array.Exists(Crossbows, t => t == weaponCategory)) {
                groups.Add(WeaponFighterGroup.Crossbows);
            }
            if (Array.Exists(Double, t => t == weaponCategory)) {
                groups.Add(WeaponFighterGroup.Double);
            }
            if (Array.Exists(HammersMacesFlails, t => t == weaponCategory)) {
                groups.Add(WeaponFighterGroup.Hammers);
            }
            if (Array.Exists(HeavyBlades, t => t == weaponCategory)) {
                groups.Add(WeaponFighterGroup.BladesHeavy);
            }
            if (Array.Exists(LightBlades, t => t == weaponCategory)) {
                groups.Add(WeaponFighterGroup.BladesLight);
            }
            if (Array.Exists(Monk, t => t == weaponCategory)) {
                groups.Add(WeaponFighterGroup.Monk);
            }
            if (Array.Exists(Natural, t => t == weaponCategory)) {
                groups.Add(WeaponFighterGroup.Natural);
            }
            if (Array.Exists(Polearms, t => t == weaponCategory)) {
                groups.Add(WeaponFighterGroup.Polearms);
            }
            if (Array.Exists(Spears, t => t == weaponCategory)) {
                groups.Add(WeaponFighterGroup.Spears);
            }
            if (Array.Exists(Thrown, t => t == weaponCategory)) {
                groups.Add(WeaponFighterGroup.Thrown);
            }
            if (groups.Count == 0) {
                groups.Add(WeaponFighterGroup.None);
            }
            return groups.ToArray();
        }
        internal static string[] GenerateWeaponTypeStrings(WeaponFighterGroup[] weaponGroups) {
            List<string> text = new List<string>();

            if (Array.Exists(weaponGroups, t => t == WeaponFighterGroup.Axes)) {
                text.Add("Axes");
            }
            if (Array.Exists(weaponGroups, t => t == WeaponFighterGroup.Bows)) {
                text.Add("Bows");
            }
            if (Array.Exists(weaponGroups, t => t == WeaponFighterGroup.Close)) {
                text.Add("Closs");
            }
            if (Array.Exists(weaponGroups, t => t == WeaponFighterGroup.Crossbows)) {
                text.Add("Crossbows");
            }
            if (Array.Exists(weaponGroups, t => t == WeaponFighterGroup.Double)) {
                text.Add("Double");
            }
            if (Array.Exists(weaponGroups, t => t == WeaponFighterGroup.Hammers)) {
                text.Add("Hammers");
            }
            if (Array.Exists(weaponGroups, t => t == WeaponFighterGroup.BladesHeavy)) {
                text.Add("Heavy Blades");
            }
            if (Array.Exists(weaponGroups, t => t == WeaponFighterGroup.BladesLight)) {
                text.Add("Light Blades");
            }
            if (Array.Exists(weaponGroups, t => t == WeaponFighterGroup.Monk)) {
                text.Add("Monk");
            }
            if (Array.Exists(weaponGroups, t => t == WeaponFighterGroup.Natural)) {
                text.Add("Natural");
            }
            if (Array.Exists(weaponGroups, t => t == WeaponFighterGroup.Polearms)) {
                text.Add("Polearms");
            }
            if (Array.Exists(weaponGroups, t => t == WeaponFighterGroup.Spears)) {
                text.Add("Spears");
            }
            if (Array.Exists(weaponGroups, t => t == WeaponFighterGroup.Thrown)) {
                text.Add("Thrown");
            }
            return text.ToArray();
        }

        [HarmonyPatch(typeof(FeatureParam), "Equals")]
        [HarmonyPatch(new Type[]
        {
            typeof(FeatureParam)
        })]
        internal static class FeatureParam_Equals_Patch {
            // TODO: Fix multiple weapon groups applying to one weapon at the same time
            internal static void Postfix(FeatureParam __instance, FeatureParam other, ref bool __result) {
                if (Main.Enabled &&
                    !__result &&
                    object.Equals(__instance.Blueprint, (other != null) ? other.Blueprint : null)
                    && __instance.SpellSchool.Equals((other != null) ? other.SpellSchool : null)
                    && __instance.StatType.Equals((other != null) ? other.StatType : null)
                    && __instance.WeaponCategory != null
                    && other != null
                    && other.WeaponCategory != null) {
                    WeaponFighterGroup[] weaponGroups = WeaponFocusPlus.GetWeaponGroups(__instance.WeaponCategory.Value);
                    WeaponFighterGroup[] weaponGroups2 = WeaponFocusPlus.GetWeaponGroups(other.WeaponCategory.Value);

                    if (weaponGroups.Intersect(weaponGroups2).Any() && weaponGroups[0] != WeaponFighterGroup.None) {
                        __result = true;
                    }
                }
            }
        }

        [HarmonyPatch(typeof(UIUtilityItem), "GetHandUse")]
        internal static class UIUtilityItem_GetHandUse_Patch {
            [HarmonyPriority(0)]
            internal static void Postfix(ItemEntity item, ref string __result) {
                if (Main.Enabled) {
                    ItemEntityWeapon itemEntityWeapon = item as ItemEntityWeapon;
                    if (itemEntityWeapon != null) {
                        WeaponFighterGroup[] weaponGroups = GetWeaponGroups(itemEntityWeapon.Blueprint.Category);
                        var text = GenerateWeaponTypeStrings(weaponGroups);
                        if (text.Count() != 0) {
                            var types = text.Aggregate((i, j) => i + "/" + j);
                            __result = __result + " (" + types + ")";
                        }
                    }
                }
            }
        }

        [HarmonyPatch(typeof(StatsStrings), "GetText", new Type[] {typeof(WeaponCategory)})]
        internal static class StatsStrings_GetParamName_Patch {
            [HarmonyPriority(0)]
            internal static void Postfix(WeaponCategory stat, ref string __result) {
                if (Main.Enabled) {
                    var preName = __result;
                    var weaponGroups = GenerateWeaponTypeStrings(GetWeaponGroups(stat));
                    var postName = (weaponGroups.Count() != 0) ? $"{weaponGroups.Aggregate((i, j) => i + "/" + j)} - {preName}" : preName;
                    __result = postName;
                }
            }
        }
        /*
        [HarmonyPatch(typeof(FeatureUIData), "GetParamName")]
        internal static class FeatureUIData_GetParamName_Patch {
            [HarmonyPriority(0)]
            internal static void Postfix(FeatureParam param, ref string __result) {
                if (Main.Enabled) {
                    if (param.WeaponCategory != null) {
                        var preName = __result;
                        var weaponGroups = GenerateWeaponTypeStrings(GetWeaponGroups(param.WeaponCategory.Value));
                        var postName = (weaponGroups.Count() != 0) ? $"{weaponGroups.Aggregate((i, j) => i + "/" + j)} - {preName}" : preName;
                        __result = postName;
                    }
                }
            }
        }
        */
        /*
        [HarmonyPatch(typeof(ResourcesLibrary), "InitializeLibrary")]
        static class ResourcesLibrary_InitializeLibrary_Patch {
            static bool Initialized;
            static bool Prefix() {
                if (Initialized) {
                    return false;
                }
                else {
                    return true;
                }
            }
            static void Postfix() {
                if (Initialized) return;
                Initialized = true;
                patchFeats();
            }
            static void patchFeats() {

                Dictionary<string, string> strings = LocalizationManager.CurrentPack.Strings;

                var bundle = (AssetBundle)AccessTools.Field(typeof(ResourcesLibrary), "s_BlueprintsBundle")
                .GetValue(null);
                
                var feats = bundle.LoadAllAssets<BlueprintFeature>();
                List<BlueprintFeature> weaponFeats = new List<BlueprintFeature>();
                foreach (var feat in feats) {
                    try {
                        if (feat.GetComponent<WeaponFocus>()) {
                            weaponFeats.Add(feat);
                        }
                    }
                    catch { }
                }
                foreach (var feat in weaponFeats) {
                    var preName = feat.Name;
                    var featName = preName.Split('(', ')')[0];
                    var weaponName = preName.Split('(', ')')[1];
                    //var weaponGroups = GetWeaponGroups(feat.GetComponent<WeaponFocus>().WeaponType.Category);
                    try {
                        var weaponGroups = GenerateWeaponTypeStrings(GetWeaponGroups(feat.GetComponent<WeaponFocus>().WeaponType.Category));
                        var postName = (weaponGroups.Count() != 0) ? $"{featName}({weaponGroups.Aggregate((i, j) => i + "/" + j)}) - ({weaponName})" : preName;
                        //var postName = $"{featName} ({weaponGroups}) - ({weaponName})";
                        
                        string b;
                        if (strings.TryGetValue(feat.m_DisplayName.Key, out b)) {
                            if (postName != b) {
                                Main.Log($"b: {b}");
                                strings[feat.m_DisplayName.Key] = postName;
                                b = postName;
                                Main.Log($"b: {b}");
                                Main.Log($"value: {strings[feat.m_DisplayName.Key]}");
                            }
                        }
                        
                        Main.Log($"name: {feat.name}");
                        Main.Log($"Name: {feat.Name}");
                        //Main.Log($"Localization Manager: {LocalizationManager.CurrentPack.GetText(feat.m_DisplayName.Key)}");
                        //Main.Log($"Localization Manager: {feat.m_DisplayName.LoadString(LocalizationManager.CurrentPack, LocalizationManager.CurrentLocale)}");
                        LocalizedString newName = CreateString(feat.m_DisplayName.Key, postName);
                        feat.m_DisplayName = newName;
                        feat.name = postName;
                        Main.Log($"name: {feat.name}");
                        Main.Log($"Name: {feat.Name}");
                        Main.Log($"{preName} -> {postName}");
                        
                    }
                    catch {
                        Main.Log($"BROKE: {feat.name }");
                    }
                }
            }
            */

        public static LocalizedString CreateString(string key, string value) {
            // See if we used the text previously.
            // (It's common for many features to use the same localized text.
            // In that case, we reuse the old entry instead of making a new one.)
            LocalizedString localized;
            /*if (textToLocalizedString.TryGetValue(value, out localized))
            {
                return localized;
            }*/
            var strings = LocalizationManager.CurrentPack.Strings;
            String oldValue;
            if (strings.TryGetValue(key, out oldValue) && value != oldValue) {
            #if DEBUG   
                Main.Log($"Info: duplicate localized string `{key}`, different text.");
            #endif
            }
            strings[key] = value;
            localized = new LocalizedString();
            localized.m_Key = key;
            //textToLocalizedString[value] = localized;
            return localized;
        }

        //}
    }
}
