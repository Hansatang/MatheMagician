using System.Collections.Generic;
using Player;
using UI;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;
using Weapons;
using Random = System.Random;

namespace Managers
{
    /// <summary>
    ///    Class responsible for holding the possible upgrades and adding them to playerWeapons
    /// </summary>
    public class LevelUpManager : MonoBehaviour
    {
        //Upgrades Containers
        [SerializeField] private List<UpgradeData> possibleUpgrades = new();
        [SerializeField] private List<UpgradeData> chosenUpgrades = new();

        //Necessary Components
        public UpgradesUI upgradesUI;
        public LevelUpController levelUpController;
        public PlayerWeapons playerWeapons;

        public UnityEvent levelUpPause;
        public UnityEvent levelUpUnpause;

        /// <summary>
        ///     Method for randomly selecting 3 upgrades, that are being used by the UI for selection
        /// </summary>
        private void PopulateLevelUpOptions()
        {
            var random = new Random();
            var option1Index = random.Next(0, possibleUpgrades.Count);
            var option2Index = random.Next(0, possibleUpgrades.Count);
            var option3Index = random.Next(0, possibleUpgrades.Count);

            levelUpController.PopulateUI(possibleUpgrades[option1Index], possibleUpgrades[option2Index],
                possibleUpgrades[option3Index]);
        }


        public void LevelUp()
        {
            PopulateLevelUpOptions();
            levelUpPause?.Invoke();
        }

        /// <summary>
        ///     Method to pass the selected upgrade to playerWeaponsObject
        /// </summary>
        public void AddUpgrade(int upgradeDataIndex)
        {
            var selected = possibleUpgrades.Find(x => x.upgradeIndex == upgradeDataIndex);
            CheckNextUpgrade(selected);

            chosenUpgrades.Remove(selected.previousUpgrade);
            chosenUpgrades.Add(selected);
            possibleUpgrades.Remove(selected);
            upgradesUI.UpdateUI(chosenUpgrades);
            playerWeapons.AddUpgrade(selected);
            levelUpUnpause?.Invoke();
        }

        private void CheckNextUpgrade(UpgradeData selected)
        {
            if (selected.nextUpgrade != null)
                if (selected.neededToUnlockUpgrade == null ||
                    possibleUpgrades.Find(x => x == selected.neededToUnlockUpgrade))
                    possibleUpgrades.Add(selected.nextUpgrade);
        }
    }
}