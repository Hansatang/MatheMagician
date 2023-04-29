using UnityEngine;

namespace Weapons
{
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