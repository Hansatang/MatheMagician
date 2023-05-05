using SO_Definitions;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Weapons;

namespace UI
{
    /// <summary>
    ///    Class responsible for showing the player his chosen upgrades
    /// </summary>
    public class UpgradeHolder : MonoBehaviour
    {
        public TextMeshProUGUI upgradeLevel;
        public Image upgradeImage;

        public void PopulateWithUpgrade(UpgradeData chosenUpgrade)
        {
            upgradeLevel.text = chosenUpgrade.tier.ToString();
            upgradeImage.sprite = chosenUpgrade.upgradeImage;
        }
    }
}