using UnityEngine;

public class BackGroundTile : MonoBehaviour
{
    [SerializeField] private Vector2Int tilePosition;

    private void Start()
    {
        GetComponentInParent<WorldBackground>().AddTile(gameObject,tilePosition);
    }
}
