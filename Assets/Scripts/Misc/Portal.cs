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
        public PortalArrow portalArrow;

        private void Start()
        {
            _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
            GameObject player = GameObject.Find("Player");
            
            Instantiate(portalArrow, player.transform.position, Quaternion.identity,
                player.transform).SetPortal(gameObject);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.gameObject.CompareTag("Player")) return;

            _gameManager.Victory();
        }
    }
}