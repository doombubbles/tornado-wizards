using System.Linq;
using BTD_Mod_Helper.Api.Enums;
using BTD_Mod_Helper.Extensions;
using Il2Cpp;
using Il2CppAssets.Scripts.Models.GenericBehaviors;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.Towers.Filters;
using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;
using Il2CppAssets.Scripts.Unity;
using PathsPlusPlus;

namespace TornadoWizards;

public class TempestTornado : UpgradePlusPlus<TornadoWizardPath>
{
    public override int Tier => 5;
    public override string Icon => VanillaSprites.SuperStormUpgradeIcon;
    public override string Portrait => "Wizard5";

    public override int Cost => TornadoWizardsMod.BallLightning
        ? Game.instance.model.GetUpgrade(UpgradeType.Superstorm).cost
        : 50000;

    public override string Description => "The tempest blows more Bloons faster, further, and more often.";

    public override void ApplyUpgrade(TowerModel towerModel)
    {
        var druid = Game.instance.model.GetTower(TowerType.Druid, 5);
        var tornado = druid.GetAttackModel().weapons.First(w => w.name.Contains("Superstorm")).Duplicate();
        tornado.animation = 1;
        
        if (!TornadoWizardsMod.BallLightning)
        {
            tornado.projectile.RemoveBehavior<CreateProjectileOnIntervalModel>();
        }

        tornado.GetDescendants<DamageModel>()
            .ForEach(model => model.immuneBloonProperties &= ~BloonProperties.Purple);
        
        if (towerModel.appliedUpgrades.Contains(UpgradeType.MonkeySense))
        {
            tornado.GetDescendants<FilterInvisibleModel>().ForEach(model => model.isActive = false);
        }

        towerModel.GetAttackModel().AddWeapon(tornado);

        if (IsHighestUpgrade(towerModel))
        {
            towerModel.display = towerModel.GetBehavior<DisplayModel>().display =
                Game.instance.model.GetTower(TowerType.Druid, 5, 0, 0).display;
        }
    }
}