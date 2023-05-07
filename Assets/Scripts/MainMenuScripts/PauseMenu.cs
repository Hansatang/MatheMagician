using UnityEngine;

namespace MainMenuScripts
{
    /// <summary>
    ///    Class responsible for Pause Menu
    /// </summary>
    public class PauseMenu : MonoBehaviour
    {
       
        public GameObject menuPanel;
        public GameObject helpPanel;
        public GameObject optionsPanel;

        public void SetActivePauseMenu(bool active)
        {
            if (active)
            {
                menuPanel.SetActive(true);
            }
            else
            {
                menuPanel.SetActive(false);
                optionsPanel.SetActive(false);
                helpPanel.SetActive(false);
            }
        }

        public void ActivateHelpPanel()
        {
            helpPanel.SetActive(true);
        }

       
    }
}