using Player;
using UnityEngine;

namespace Misc
{
    public class ExpOrb : MonoBehaviour
    {
        private int _worth;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                other.gameObject.GetComponent<PlayerExperience>().AwardExperience(_worth);
                Destroy(gameObject);
            }
        }

        public void SetWorth(int value)
        {
            _worth = value;
        }
    }
}