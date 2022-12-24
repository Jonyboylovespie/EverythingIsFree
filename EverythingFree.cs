using Assets.Scripts.Models;
using BTD_Mod_Helper;
using MelonLoader;
using System;
using EverythingFree;
using Assets.Scripts.Models.Towers.Mods;
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
