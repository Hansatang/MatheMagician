using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon", menuName = "Scriptable Objects/Weapons")]
public class WeaponData : ScriptableObject
{
    public int weaponIndex;
    public string weaponName;
    public string weaponDescription;
    public float weaponDamage;
    public Sprite weaponImage;
    public GameObject weaponObject;
}