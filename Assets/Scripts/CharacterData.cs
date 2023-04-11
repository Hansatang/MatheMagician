using UnityEngine;
using Weapons;

[CreateAssetMenu(fileName = "New Character", menuName = "Scriptable Objects/Characters")]
public class CharacterData : ScriptableObject
{
    public string characterName;
    public int characterHealth;
    public float characterSpeed;
    public Sprite characterSprite;
    public GameObject characterObject;
    public UpgradeData startingWeapon;
}