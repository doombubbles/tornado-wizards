using System.Linq;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.GenericBehaviors;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;
using Il2CppAssets.Scripts.Unity;
using PathsPlusPlus;

namespace TornadoWizards;

public class ElectricOverload : UpgradePlusPlus<TornadoWizardPath>
{
    public override int Cost => 7000;
    public override int Tier => 4;
    public override string Portrait => "Wizard4";

    public override string Description =>
        "Supercharges the Lightning attack, increasing damage, speed, and splitting.";

    public override void ApplyUpgrade(TowerModel towerModel, int tier)
    {
        var weapon = towerModel.GetAttackModel().weapons.First(w => w.name == "WeaponModel_Lightning");
        weapon.Rate /= 2;
        var lightning = weapon.projectile;
        lightning.GetDamageModel().damage += 4;

        lightning.GetBehavior<LightningModel>().splits++;
        
        if (IsHighestUpgrade(towerModel))
        {
            towerModel.display = towerModel.GetBehavior<DisplayModel>().display =
                Game.instance.model.GetTower(TowerType.Druid, 4, 0, 0).display;
        }
    }
}