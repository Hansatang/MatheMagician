using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class LevelUpController : MonoBehaviour
{
    [SerializeField] private List<ScriptableObject> serializableObjects = new List<ScriptableObject>();
    [SerializeField] private List<ScriptableObject> serializableChosenObjects = new List<ScriptableObject>();
    public static bool gamePausedLevelUp;
    public HolderBehaviour firstHolder;
    public HolderBehaviour secondHolder;
    public HolderBehaviour thirdHolder;
    public GameObject levelUpMenu;
    public PlayerWeapons playerWeapons;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (gamePausedLevelUp)
            {
                Resume();
            }
            else
            {
                OpenLevelUpWindow();
            }
        }
    }

    private void OpenLevelUpWindow()
    {
        levelUpMenu.SetActive(true);
        Time.timeScale = 0f;
        gamePausedLevelUp = true;
        PopulateLevelUpOptions();
    }

    private void PopulateLevelUpOptions()
    {
        Random random = new Random();
        int start1 = random.Next(0, serializableObjects.Count);
        int start2 = random.Next(0, serializableObjects.Count);
        int start3 = random.Next(0, serializableObjects.Count);

        firstHolder.Populate(serializableObjects[start1]);
        secondHolder.Populate(serializableObjects[start2]);
        thirdHolder.Populate(serializableObjects[start3]);
    }

    public void Resume()
    {
        levelUpMenu.SetActive(false);
        Time.timeScale = 1f;
        gamePausedLevelUp = false;
    }

    public void AddUpgrade(UpgradeData upgradeData)
    {
        if (upgradeData.nextUpgrade != null)
        {
            serializableObjects.Add(upgradeData.nextUpgrade);
        }
        serializableObjects.Remove(upgradeData);
        playerWeapons.AddUpgrade(upgradeData);
        Resume();
    }
}