using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapons : MonoBehaviour
{
    private List<IWeaponSystem> _weaponSystems = new();

    void Start()
    {
        ArmWeapons();
    }

    private void ArmWeapons()
    {
        foreach (IWeaponSystem weapon in _weaponSystems)
        {
            weapon.Arm();
        }
    }

    private void StopWeapons()
    {
        foreach (IWeaponSystem weapon in _weaponSystems)
        {
            weapon.Stop();
        }
    }

    private void Upgrade()
    {
        foreach (IWeaponSystem weapon in _weaponSystems)
        {
            weapon.Upgrade(3.0f, 3.0f, 3.0f);
        }
    }

    public void AddWeapon(GameObject weaponObject)
    {
        StopWeapons();
        GameObject go = Instantiate(weaponObject, new Vector3 (0,0,0), Quaternion.identity); 
        go.transform.parent = gameObject.transform;
        IWeaponSystem weaponSystemToAdd = (IWeaponSystem) go.GetComponent(typeof(IWeaponSystem));
        _weaponSystems.Add(weaponSystemToAdd);
        ArmWeapons();
    }
}