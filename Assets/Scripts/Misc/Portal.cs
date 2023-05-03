using UnityEngine;

namespace Misc
{
    /// <summary>
    ///    Class responsible for Victory portal behaviour, which upon entering wins the game
    /// </summary>
    public class Portal : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                Debug.Log("Victory");
            }
        }
    }
}