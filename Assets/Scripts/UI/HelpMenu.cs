using UnityEngine;

namespace UI
{
    /// <summary>
    ///    Class responsible for help canvas that is used showing instruction
    /// </summary>
    public class HelpMenu : MonoBehaviour
    {
        public void CloseHelp()
        {
            PlayerPrefs.SetInt("SawHelp", 1);
            PlayerPrefs.Save();
        }
    }
}