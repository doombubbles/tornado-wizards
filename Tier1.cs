using BTD_Mod_Helper.Api.Enums;
using BTD_Mod_Helper.Extensions;
using Il2Cpp;
using Il2CppAssets.Scripts.Models.GenericBehaviors;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Weapons;
using Il2CppAssets.Scripts.Unity;
using Il2CppSystem.Linq;
using PathsPlusPlus;

namespace TornadoWizards;

public class MysticDisruption : UpgradePlusPlus<TornadoWizardPath>
{
    public override int Cost => 400;
    public override int Tier => 1;
    public override string Icon => VanillaSprites.PurpleBloonsIcon;
    public override string Portrait => "Wizard1";

    public override string Description => "Attacks slightly faster, and magic can now pop purple Bloons.";

    public override void ApplyUpgrade(TowerModel towerModel, int tier)
    {
        foreach (var weaponModel in towerModel.GetDescendants<WeaponModel>().ToArray())
        {
            weaponModel.Rate /= 1.1f;
        }

        foreach (var damageModel in towerModel.GetDescendants<DamageModel>().ToArray())
        {
            damageModel.immuneBloonProperties &= ~BloonProperties.Purple;
        }

        if (IsHighestUpgrade(towerModel))
        {
            towerModel.display = towerModel.GetBehavior<DisplayModel>().display =
                Game.instance.model.GetTower(TowerType.WizardMonkey, 0, 0, 1).display;
        }
    }
}