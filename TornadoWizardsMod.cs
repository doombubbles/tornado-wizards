using MelonLoader;
using BTD_Mod_Helper;
using BTD_Mod_Helper.Api.Enums;
using BTD_Mod_Helper.Extensions;
using Il2Cpp;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.Towers.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Projectiles;
using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;
using PathsPlusPlus;
using TornadoWizards;

[assembly: MelonInfo(typeof(TornadoWizardsMod), ModHelperData.Name, ModHelperData.Version, ModHelperData.RepoOwner)]
[assembly: MelonGame("Ninja Kiwi", "BloonsTD6")]

namespace TornadoWizards;

public class TornadoWizardsMod : BloonsTD6Mod
{
}

public class TornadoWizardPath : PathPlusPlus
{
    public override string Tower => TowerType.WizardMonkey;
    public override int UpgradeCount => 6;
}

public class Category6 : UpgradePlusPlus<TornadoWizardPath>
{
    public override int Tier => 6;

    public override int Cost => 100000;

    public override string Icon => VanillaSprites.SuperStormUpgradeIcon;

    public override string Description => "6x attack speed";

    public override void ApplyUpgrade(TowerModel towerModel)
    {
        towerModel.range *= 1.6f;
        
        foreach (var attackModel in towerModel.GetAttackModels())
        {
            attackModel.range *= 1.6f;
        }

        foreach (var weaponModel in towerModel.GetWeapons())
        {
            weaponModel.Rate /= 6;
        }
    }
}

public class KingOfDarknessPath : PathPlusPlus
{
    public override string Tower => TowerType.WizardMonkey;

    public override int UpgradeCount => 6;

    public override int ExtendVanillaPath => Bottom;
}

public class KingOfDarkness : UpgradePlusPlus<KingOfDarknessPath>
{
    public override int Tier => 6;
    
    public override int Cost => 75000;

    public override string Icon => VanillaSprites.SoulbindUpgradeIcon;

    public override string Description => "Da king is back baby";

    public override string? Portrait => VanillaSprites.Wizard005;

    public override void ApplyUpgrade(TowerModel towerModel)
    {
        towerModel.range *= 1.25f;
        foreach (var attackModel in towerModel.GetAttackModels())
        {
            attackModel.range *= 1.25f;
        }
        
        var buffModel = towerModel.GetBehavior<PrinceOfDarknessZombieBuffModel>();
        buffModel.damageIncrease += 4;
        
        towerModel.GetDescendants<ProjectileModel>().ForEach(model =>
        {
            model.pierce *= 2;
            model.radius *= 2;
            model.scale *= 2;
        });
        
        towerModel.GetDescendants<DamageModel>().ForEach(model =>
        {
            model.damage *= 2;
            model.immuneBloonPropertiesOriginal = model.immuneBloonProperties = BloonProperties.None;
        });
    }
}