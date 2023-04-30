using System.Collections.Generic;
using UnityEngine;
using Weapons;

namespace UI
{
    public class UpgradesUI : MonoBehaviour
    {
        public List<UpgradeHolder> upgradeHolders;

        public void UpdateUI(List<UpgradeData> chosenUpgrades)
        {
            for (var i = 0; i < chosenUpgrades.Count; i++)
            {
                upgradeHolders[i].PopulateWithUpgrade(chosenUpgrades[i]);
                upgradeHolders[i].gameObject.SetActive(true);
            }
        }
    }
}