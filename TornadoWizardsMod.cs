using MelonLoader;
using BTD_Mod_Helper;
using BTD_Mod_Helper.Api.Enums;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.Towers.Behaviors;
using Il2CppAssets.Scripts.Utils;
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

public class WizardBottomPath : PathPlusPlus
{
    public override string Tower => TowerType.WizardMonkey;
    public override int UpgradeCount => 6;
    public override int ExtendVanillaPath => Bottom;
}

public class EmperorOfDarkness : UpgradePlusPlus<WizardBottomPath>
{
    public override int Cost => 50000;
    public override int Tier => 6;

    public override string Icon => VanillaSprites.SoulbindUpgradeIcon;
    public override string? Portrait => VanillaSprites.Wizard005;

    public override string Description => "Global zombie buff better";

    public override void ApplyUpgrade(TowerModel towerModel)
    {
        var buffModel = towerModel.GetBehavior<PrinceOfDarknessZombieBuffModel>();
        buffModel.damageIncrease += 4;
    }
}