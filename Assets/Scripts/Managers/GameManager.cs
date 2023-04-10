using System.Collections;
using UnityEngine;

namespace Managers
{
    public class GameManager : MonoBehaviour
    {
        public GameUI gameUI;
        public static bool GamePaused;
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
            gameUI.UpdateClock(gameTime);
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                GamePaused = !GamePaused;
            }
        }
    }
}