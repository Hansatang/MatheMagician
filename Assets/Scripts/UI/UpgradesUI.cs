using System.Collections.Generic;
using SO_Definitions;
using UnityEngine;
using Weapons;

namespace UI
{
    /// <summary>
    ///    Class responsible for populating the UpgradeHolders
    /// </summary>
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