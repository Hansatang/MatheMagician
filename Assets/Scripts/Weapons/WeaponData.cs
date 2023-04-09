using System.Collections.Generic;
using UnityEngine;

namespace Weapons
{
    [CreateAssetMenu(fileName = "New Weapon", menuName = "Scriptable Objects/Upgrade/Weapons")]
    public class WeaponData : UpgradeData
    {
        public GameObject weaponObject;
    }
}