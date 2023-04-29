using MelonLoader;
using BTD_Mod_Helper;
using Il2CppAssets.Scripts.Models.Towers;
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
    public override int UpgradeCount => 5;
}