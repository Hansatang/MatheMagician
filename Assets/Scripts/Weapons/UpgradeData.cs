using UnityEngine;

namespace Weapons
{
    /// <summary>
    ///    ScriptableObject baseline for upgrades, contains general statistics
    /// </summary>
    [CreateAssetMenu(fileName = "New Upgrade", menuName = "Scriptable Objects/Upgrade")]
    public class UpgradeData : ScriptableObject
    {
        public int upgradeIndex;
        public string upgradeName;
        public string upgradeDescription;
        public int tier;
        public Sprite upgradeImage;
        public UpgradeData nextUpgrade;
        public UpgradeData previousUpgrade;
        public UpgradeData neededToUnlockUpgrade;
    }
}