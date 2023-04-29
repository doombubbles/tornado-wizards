using System.Linq;
using BTD_Mod_Helper.Api.Enums;
using BTD_Mod_Helper.Extensions;
using Il2Cpp;
using Il2CppAssets.Scripts.Models.GenericBehaviors;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.Towers.Filters;
using Il2CppAssets.Scripts.Unity;
using PathsPlusPlus;

namespace TornadoWizards;

public class LightningBolt : UpgradePlusPlus<TornadoWizardPath>
{
    public override int Cost => 1020;
    public override int Tier => 2;
    public override string Portrait => "Wizard2";

    public override string Description => "Unleashes the power of lightning to zap many Bloons at once in a chain.";

    public override void ApplyUpgrade(TowerModel towerModel, int tier)
    {
        var druid = Game.instance.model.GetTower(TowerType.Druid, tier);
        var lightning = druid.GetAttackModel().weapons.First(w => w.name == "WeaponModel_Lightning").Duplicate();
        lightning.animation = 1;
        lightning.projectile.GetDamageModel().immuneBloonProperties &= ~BloonProperties.Purple;
        if (towerModel.appliedUpgrades.Contains(UpgradeType.MonkeySense))
        {
            lightning.GetDescendants<FilterInvisibleModel>().ForEach(model => model.isActive = false);
        }

        towerModel.GetAttackModel().AddWeapon(lightning);
        
        if (IsHighestUpgrade(towerModel))
        {
            towerModel.display = towerModel.GetBehavior<DisplayModel>().display =
                Game.instance.model.GetTower(TowerType.WizardMonkey, 0, 0, 1).display;
        }
    }
}