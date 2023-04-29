using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Weapons;

namespace UI
{
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