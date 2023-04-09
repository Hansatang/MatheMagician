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
            int modifyingWeapon = _weaponSystems.FindIndex(x => x.WeaponId == weaponData.upgradeIndex);
            if (modifyingWeapon != -1)
            {
                _weaponSystems[modifyingWeapon].Stop();
                _weaponSystems.RemoveAt(modifyingWeapon);
            }
            AddWeapon(weaponData);
        }
    }

    private void UpgradeAllStats(float speedEnhancements, float powerEnhancements, float areaEnhancements)
    {
        foreach (IWeaponSystem weapon in _weaponSystems)
        {
            weapon.UpgradeAll(speedEnhancements, powerEnhancements, areaEnhancements);
        }
    }


    public void AddWeapon(WeaponData weaponObject)
    {
        GameObject instantiatedWeapon = Instantiate(weaponObject.weaponObject, transform.position, Quaternion.identity);
        instantiatedWeapon.transform.parent = gameObject.transform;
        IWeaponSystem weaponSystemToAdd = (IWeaponSystem) instantiatedWeapon.GetComponent(typeof(IWeaponSystem));
        weaponSystemToAdd.WeaponId = weaponObject.upgradeIndex;
        _weaponSystems.Add(weaponSystemToAdd);
        weaponSystemToAdd.Arm(_speedEnhancements, _powerEnhancements, _areaEnhancements);
    }
}