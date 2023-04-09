using UnityEngine;

namespace Weapons
{
    [CreateAssetMenu(fileName = "New Weapon Upgrade", menuName = "Scriptable Objects/Upgrade/WeaponsUpgrade")]
    public class WeaponUpgradeData : UpgradeData
    {
        public GameObject UpgradedWeaponObject;
    }
}