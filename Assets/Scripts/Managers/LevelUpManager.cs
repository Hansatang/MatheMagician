using System.Collections.Generic;
using Player;
using UI;
using UnityEngine;
using Weapons;
using Random = System.Random;

namespace Managers
{
    public class LevelUpManager : MonoBehaviour
    {
        //Upgrades Containers
        [SerializeField] private List<UpgradeData> possibleUpgrades = new();
        [SerializeField] private List<UpgradeData> chosenUpgrades = new();

        //Necessary Components
        public LevelUpController levelUpController;
        public PlayerWeapons playerWeapons;

        /// <summary>
        /// Method for randomly selecting 3 upgrades, that are being used by the UI for selection
        /// </summary>
        private void PopulateLevelUpOptions()
        {
            Random random = new Random();
            int option1Index = random.Next(0, possibleUpgrades.Count);
            int option2Index = random.Next(0, possibleUpgrades.Count);
            int option3Index = random.Next(0, possibleUpgrades.Count);

            levelUpController.PopulateUI(possibleUpgrades[option1Index], possibleUpgrades[option2Index],
                possibleUpgrades[option3Index]);
            
        }

        /// <summary>
        /// Method to pass the selected upgrade to playerWeaponsObject
        /// </summary>
        public void AddUpgrade(int upgradeDataIndex)
        {
            UpgradeData selected = possibleUpgrades.Find(x => x.upgradeIndex == upgradeDataIndex);
            if (selected.nextUpgrade != null)
            {
                possibleUpgrades.AddRange(selected.nextUpgrade);
            }

            chosenUpgrades.Add(selected);
            possibleUpgrades.Remove(selected);
            playerWeapons.AddUpgrade(selected);
        }

        public void LevelUp()
        {
            PopulateLevelUpOptions();
            PauseManager.LevelUpPaused = true;
        }
    }
}