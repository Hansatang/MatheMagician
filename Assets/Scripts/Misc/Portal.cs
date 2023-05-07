using Managers;
using UnityEngine;

namespace Misc
{
    /// <summary>
    ///    Class responsible for Victory portal behaviour, which upon entering wins the game
    /// </summary>
    public class Portal : MonoBehaviour
    {
        private GameManager _gameManager;

        private void Start()
        {
            _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.gameObject.CompareTag("Player")) return;

            _gameManager.Victory();
        }
    }
}