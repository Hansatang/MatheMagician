using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapons : MonoBehaviour
{
    private List<IWeaponSystem> _weaponSystems = new();

    private void Upgrade()
    {
        foreach (IWeaponSystem weapon in _weaponSystems)
        {
            weapon.Upgrade(3.0f, 3.0f, 3.0f);
        }
    }

    public void AddWeapon(GameObject weaponObject)
    {
        GameObject go = Instantiate(weaponObject, transform.position, Quaternion.identity);
        go.transform.parent = gameObject.transform;
        IWeaponSystem weaponSystemToAdd = (IWeaponSystem) go.GetComponent(typeof(IWeaponSystem));
        _weaponSystems.Add(weaponSystemToAdd);
        weaponSystemToAdd.Arm();
    }
}