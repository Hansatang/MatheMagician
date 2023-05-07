using UnityEngine;

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
    }
}