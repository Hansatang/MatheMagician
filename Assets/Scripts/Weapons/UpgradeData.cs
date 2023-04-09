using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Upgrade", menuName = "Scriptable Objects/Upgrade")]
public class UpgradeData : ScriptableObject
{
    public int upgradeIndex;
    public string upgradeName;
    public string upgradeDescription;
    public Sprite upgradeImage;
    public UpgradeData nextUpgrade;
   
}