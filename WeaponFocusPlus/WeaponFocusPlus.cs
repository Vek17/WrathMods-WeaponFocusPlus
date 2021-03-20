using System;
using HarmonyLib;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.Enums;
using Kingmaker.Blueprints.Items.Weapons;
using Kingmaker.Items;
using Kingmaker.UI.Common;
using System.Collections.Generic;
using System.Linq;
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
                text.Add("Close");
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

        [HarmonyPatch(typeof(FeatureParam), "Equals", new Type[] { typeof(FeatureParam) })]
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
    }
}
