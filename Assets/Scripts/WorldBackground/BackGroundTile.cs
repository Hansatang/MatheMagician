using UnityEngine;

namespace WorldBackground
{
    public class BackGroundTile : MonoBehaviour
    {
        [SerializeField] private Vector2Int tilePosition;

        private void Start()
        {
            GetComponentInParent<BackgroundWorld>().AddTile(gameObject, tilePosition);
        }
    }
}