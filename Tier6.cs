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

public class Sharknado : UpgradePlusPlus<TornadoWizardPath>
{
    public override int Cost => 100000;
    public override int Tier => 6;
    public override string Icon => VanillaSprites.MegalodonUpgradeIcon;
    public override string Portrait => "Wizard5";

    public override string Description => "Sharknado lol.";

    public override void ApplyUpgrade(TowerModel towerModel)
    {
        
    }
}