using System.Collections.Generic;
using SO_Definitions;
using UnityEngine;
using Weapons;

namespace Player
{
    /// <summary>
    ///    Class responsible for holding and modifying the player weapons
    /// </summary>
    public class PlayerWeapons : MonoBehaviour
    {
        private readonly List<WeaponSystem> _weaponSystems = new();

        private float _areaEnhancements = 1f;
        private float _powerEnhancements = 1f;
        private float _speedEnhancements = 1f;

        /// <summary>
        ///    Check the type of upgrade and acts based on it
        /// </summary>
        public void AddUpgrade(UpgradeData upgradeData)
        {
            switch (upgradeData)
            {
                case EnhancementData enhancementData:
                {
                    ModifyEnhancements(enhancementData);
                    break;
                }
                case WeaponData weaponData:
                {
                    ModifyWeaponSystems(weaponData);
                    break;
                }
            }
        }

        private void ModifyWeaponSystems(WeaponData weaponData)
        {
            if (weaponData.previousUpgrade != null)
            {
                var modifyingWeapon =
                    _weaponSystems.FindIndex(x => x.weaponId == weaponData.previousUpgrade.upgradeIndex);
                if (modifyingWeapon != -1)
                {
                    _weaponSystems[modifyingWeapon].Stop();
                    _weaponSystems.RemoveAt(modifyingWeapon);
                }
            }

            CreateWeaponLauncher(weaponData);
        }

        private void ModifyEnhancements(EnhancementData enhancementData)
        {
            switch (enhancementData.enhancementType)
            {
                case EnhancementTypes.Speed:
                    _speedEnhancements = enhancementData.enhancementMultiplier;
                    break;
                case EnhancementTypes.Power:
                    _powerEnhancements = enhancementData.enhancementMultiplier;
                    break;
                case EnhancementTypes.Area:
                    _areaEnhancements = enhancementData.enhancementMultiplier;
                    break;
            }

            UpgradeAllWeapons(_speedEnhancements, _powerEnhancements, _areaEnhancements);
        }

        private void UpgradeAllWeapons(float speedEnhancements, float powerEnhancements, float areaEnhancements)
        {
            foreach (var weapon in _weaponSystems)
                weapon.UpgradeAll(speedEnhancements, powerEnhancements, areaEnhancements);
        }

        /// <summary>
        ///    First it creates the weapon Launcher, the it's being added to the active weapons, so upgrades can be done in a for loop
        /// Second it set the already obtained stats upgrades to the weapon
        /// </summary>
        private void CreateWeaponLauncher(WeaponData weaponObject)
        {
            var instantiatedWeapon =
                Instantiate(weaponObject.weaponObject, transform.position, Quaternion.identity);
            instantiatedWeapon.transform.parent = gameObject.transform;
            var weaponSystemToAdd = (WeaponSystem) instantiatedWeapon.GetComponent(typeof(WeaponSystem));

            weaponSystemToAdd.SetBaseStats(weaponObject.speed, weaponObject.area, weaponObject.power);
            weaponSystemToAdd.SetID(weaponObject.upgradeIndex);
            weaponSystemToAdd.Arm();
            weaponSystemToAdd.UpgradeAll(_speedEnhancements, _powerEnhancements, _areaEnhancements);

            _weaponSystems.Add(weaponSystemToAdd);
        }
    }
}