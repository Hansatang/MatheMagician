using UnityEngine;

public class BackGroundTile : MonoBehaviour
{
    [SerializeField] private Vector2Int tilePosition;

    private void Start()
    {
        GetComponentInParent<WorldScript>().AddTile(gameObject,tilePosition);
    }
}
