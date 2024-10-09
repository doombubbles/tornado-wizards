using System;
using System.Linq;
using BTD_Mod_Helper.Api.Enums;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.Towers.Filters;
using Il2CppAssets.Scripts.Unity;
using PathsPlusPlus;

namespace TornadoWizards;

public class SummonWhirlwind : UpgradePlusPlus<TornadoWizardPath>
{
    public override int Cost => 1700;
    public override int Tier => 3;
    public override string Icon => VanillaSprites.DruidoftheStormUpgradeIcon;
    public override string Portrait => "Wizard3";

    public override string Description =>
        "Whirlwind blows bloons off the path away from the exit. However, removes ice and glue from the bloons.";

    public override void ApplyUpgrade(TowerModel towerModel, int tier)
    {
        var druid = Game.instance.model.GetTower(TowerType.Druid, Math.Min(tier, 5));
        var tornado = druid.GetAttackModels().First(model => model.name.Contains("Tornado")).Duplicate();
        tornado.weapons[0].animation = 1;
        if (towerModel.appliedUpgrades.Contains(UpgradeType.MonkeySense))
        {
            tornado.GetDescendants<FilterInvisibleModel>().ForEach(model => model.isActive = false);
        }

        tornado.range = towerModel.range;

        towerModel.AddBehavior(tornado);
    }
}