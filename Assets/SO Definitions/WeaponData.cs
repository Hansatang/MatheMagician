using UnityEngine;

namespace Weapons
{
    /// <summary>
    ///    ScriptableObject responsible for holding the weapon statistics
    /// </summary>
    [CreateAssetMenu(fileName = "New Weapon", menuName = "Scriptable Objects/Upgrade/Weapons")]
    public class WeaponData : UpgradeData
    {
        public GameObject weaponObject;
        public float speed;
        public float area;
        public int power;
    }
}