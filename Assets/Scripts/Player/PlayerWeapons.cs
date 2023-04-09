using System.Collections.Generic;
using UnityEngine;
using Weapons;

public class PlayerWeapons : MonoBehaviour
{
    private List<IWeaponSystem> _weaponSystems = new();
    private float _speedEnhancements = 1f;
    private float _powerEnhancements = 1f;
    private float _areaEnhancements = 1f;

    public void AddUpgrade(UpgradeData upgradeData)
    {
        if (upgradeData is EnhancementData enhancementData)
        {
            if (enhancementData.enhancementType == EnhancementTypes.Speed)
            {
                _speedEnhancements += enhancementData.enhancementMultiplier;
            }
            else if (enhancementData.enhancementType == EnhancementTypes.Power)
            {
                _powerEnhancements += enhancementData.enhancementMultiplier;
            }
            else if (enhancementData.enhancementType == EnhancementTypes.Area)
            {
                _areaEnhancements += enhancementData.enhancementMultiplier;
            }

            UpgradeAllStats(_speedEnhancements, _powerEnhancements, _areaEnhancements);
        }
        else if (upgradeData is WeaponData weaponData)
        {
            AddWeapon(weaponData.weaponObject, weaponData.upgradeIndex);
        }

        else if (upgradeData is WeaponUpgradeData weaponUpgradeData)
        {
            int modifyingWeapon = _weaponSystems.FindIndex(x => x.WeaponId == weaponUpgradeData.upgradeIndex);
            _weaponSystems[modifyingWeapon].Stop();
            _weaponSystems.RemoveAt(modifyingWeapon);
            AddWeapon(weaponUpgradeData.UpgradedWeaponObject, weaponUpgradeData.upgradeIndex);
        }
    }

    private void UpgradeAllStats(float speedEnhancements, float powerEnhancements, float areaEnhancements)
    {
        foreach (IWeaponSystem weapon in _weaponSystems)
        {
            weapon.UpgradeAll(speedEnhancements, powerEnhancements, areaEnhancements);
        }
    }


    public void AddWeapon(GameObject weaponObject, int index)
    {
        GameObject instantiatedWeapon = Instantiate(weaponObject, transform.position, Quaternion.identity);
        instantiatedWeapon.transform.parent = gameObject.transform;
        IWeaponSystem weaponSystemToAdd = (IWeaponSystem) instantiatedWeapon.GetComponent(typeof(IWeaponSystem));
        weaponSystemToAdd.WeaponId = index;
        _weaponSystems.Add(weaponSystemToAdd);
        weaponSystemToAdd.Arm(_speedEnhancements, _powerEnhancements, _areaEnhancements);
    }
}