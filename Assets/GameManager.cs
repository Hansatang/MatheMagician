using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI clock;
    public int gameTime;

    public void Start()
    {
        StartCoroutine(Time());
    }

    private IEnumerator Time()
    {
        while (true)
        {
            TimeCount();

            yield return new WaitForSeconds(1);
        }
    }

    private void TimeCount()
    {
        gameTime += 1;
        TimeSpan t = TimeSpan.FromSeconds(gameTime);
        clock.text = $"{t.Minutes:D2}:{t.Seconds:D2}";
    }
}