using GameManager;
using UnityEngine;
using UnityEngine.Events;

namespace UI
{
    public class LevelUpController : MonoBehaviour
    {
        
        public HolderBehaviour firstHolder;
        public HolderBehaviour secondHolder;
        public HolderBehaviour thirdHolder;
        public GameObject levelUpMenu;
        public UnityEvent<int> upgradeSelectionEvent;


        private void OpenLevelUpWindow()
        {
            levelUpMenu.SetActive(true);
            Time.timeScale = 0f;
        }

        public void PopulateUI(ScriptableObject sOb1,ScriptableObject sOb2,ScriptableObject sOb3)
        {
            firstHolder.Populate(sOb1);
            secondHolder.Populate(sOb2);
            thirdHolder.Populate(sOb3);
            OpenLevelUpWindow();
        }

        private void Resume()
        {
            levelUpMenu.SetActive(false);
            Time.timeScale = 1f;
        }

        public void AddUpgrade(int upgradeDataIndex)
        {
            upgradeSelectionEvent.Invoke(upgradeDataIndex);
            Resume();
        }
    }
}