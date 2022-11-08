using Assets.Scripts.Models;
using Assets.Scripts.Models.GenericBehaviors;
using Assets.Scripts.Models.Towers;
using Assets.Scripts.Models.Towers.Behaviors;
using Assets.Scripts.Models.Towers.Behaviors.Abilities;
using Assets.Scripts.Models.Towers.Behaviors.Abilities.Behaviors;
using Assets.Scripts.Models.Towers.Behaviors.Attack;
using Assets.Scripts.Models.Towers.Behaviors.Attack.Behaviors;
using Assets.Scripts.Models.Towers.Filters;
using Assets.Scripts.Models.Towers.Projectiles;
using Assets.Scripts.Models.Towers.Projectiles.Behaviors;
using Assets.Scripts.Models.Towers.TowerFilters;
using Assets.Scripts.Models.Towers.Weapons;
using Assets.Scripts.Models.Towers.Weapons.Behaviors;
using Assets.Scripts.Models.TowerSets;
using Assets.Scripts.Unity;
using Assets.Scripts.Unity.Display;
using Assets.Scripts.Utils;
using BTD_Mod_Helper;
using BTD_Mod_Helper.Api;
using BTD_Mod_Helper.Api.Display;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using Harmony;
using MelonLoader;
using System;
using System.Collections.Generic;
using System.Linq;
using EverythingFree;
using UnhollowerBaseLib;
using Assets.Scripts.Models.Towers.Mods;
using BTD_Mod_Helper.Api.Enums;
using BTD_Mod_Helper.Api.Helpers;
using Il2CppSystem.Collections.Generic;
using BTD_Mod_Helper.Api.ModOptions;
using BTD_Mod_Helper.Api.Data;

[assembly: MelonInfo(typeof(EverythingFree.EverythingFree), ModHelperData.Name, ModHelperData.Version, ModHelperData.RepoOwner)]
[assembly: MelonGame("Ninja Kiwi", "BloonsTD6")]

namespace EverythingFree
{
    public class EverythingFree : BloonsTD6Mod
    {
        public override void OnApplicationStart()
        {
            MelonLogger.Msg(ConsoleColor.Red, "All upgrades and towers are now free!");
        }
        public override void OnNewGameModel(GameModel gameModel, Il2CppSystem.Collections.Generic.List<ModModel> mods)
        {
            if (Settings.FreeUpgrades == true)
            {
                foreach (var upgradeModel in gameModel.upgrades)
                {
                    upgradeModel.cost = 0;
                }
            }
            if (Settings.FreeTowers == true)
            {
                foreach (var towerModel in gameModel.towers)
                {
                    towerModel.cost = 0;
                }
            }
        }
    }
    public class Settings : ModSettings
    {
        public static readonly ModSettingBool FreeTowers = new(true)
        {
            displayName = "Makes towers free!",
            button = true,
        };
        public static readonly ModSettingBool FreeUpgrades = new(true)
        {
            displayName = "Makes upgrades free!",
            button = true,
        };
    }
}
