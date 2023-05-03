using System.Collections.Generic;
using UnityEngine;
using Weapons;

namespace Player
{
    public class PlayerWeapons : MonoBehaviour
    {
        private float _areaEnhancements = 1f;
        private float _powerEnhancements = 1f;
        private float _speedEnhancements = 1f;
        private readonly List<WeaponSystem> _weaponSystems = new();

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
            var modifyingWeapon =
                _weaponSystems.FindIndex(x => x.weaponId == weaponData.previousUpgrade.upgradeIndex);
            if (modifyingWeapon != -1)
            {
                _weaponSystems[modifyingWeapon].Stop();
                _weaponSystems.RemoveAt(modifyingWeapon);
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


        private void CreateWeaponLauncher(WeaponData weaponObject)
        {
            var instantiatedWeapon =
                Instantiate(weaponObject.weaponObject, transform.position, Quaternion.identity);
            instantiatedWeapon.transform.parent = gameObject.transform;
            var weaponSystemToAdd = (WeaponSystem) instantiatedWeapon.GetComponent(typeof(WeaponSystem));
            weaponSystemToAdd.SetEnhancedStats(weaponObject.speed, weaponObject.area, weaponObject.power);
            _weaponSystems.Add(weaponSystemToAdd);
            weaponSystemToAdd.UpgradeAll(_speedEnhancements, _powerEnhancements, _areaEnhancements);
            weaponSystemToAdd.Arm();
        }
    }
}