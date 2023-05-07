using UnityEngine;

namespace UI
{
    /// <summary>
    ///    Class responsible for help canvas that is used showing instruction
    /// </summary>
    public class HelpCanvas : MonoBehaviour
    {
        public GameObject helpPanel;

        void Start()
        {
            if (PlayerPrefs.GetInt("SawHelp") == 0)
            {
                helpPanel.SetActive(true);
            }
        }

        public void CloseHelp()
        {
            PlayerPrefs.SetInt("SawHelp", 1);
            PlayerPrefs.Save();
        }
    }
}