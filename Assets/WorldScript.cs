using UnityEngine;

public class WorldScript : MonoBehaviour
{
    [SerializeField] private Transform _playerTransform;
    Vector2Int _currentTilePosition = new(0, 0);
    [SerializeField] Vector2Int playerTilePosition;
    private Vector2Int _onTileGridPlayerPosition;
    GameObject[,] terrainTiles;

    [SerializeField] private int terrainTileHorizontalCount;
    [SerializeField] private int terrainTileVerticalCount;
    [SerializeField] private float tileSize = 40f;
    [SerializeField] int fieldOfVisionHeight = 3;
    [SerializeField] int fieldOfVisionWidth = 3;

    private void Awake()
    {
        terrainTiles = new GameObject[terrainTileHorizontalCount, terrainTileVerticalCount];
    }

    public void AddTile(GameObject tileGameObject, Vector2Int tilePosition)
    {
        terrainTiles[tilePosition.x, tilePosition.y] = tileGameObject;
    }

    private void Update()
    {
        playerTilePosition.x = (int) (_playerTransform.position.x / tileSize);
        playerTilePosition.y = (int) (_playerTransform.position.y / tileSize);

        playerTilePosition.x -= _playerTransform.position.x < 0 ? 1 : 0;
        playerTilePosition.y -= _playerTransform.position.y < 0 ? 1 : 0;

        Debug.Log(playerTilePosition.y + " POLE " + playerTilePosition.x);
        Debug.Log(_currentTilePosition.y + " Current " + _currentTilePosition.x);
        if (_currentTilePosition != playerTilePosition)
        {
            _currentTilePosition = playerTilePosition;

            _onTileGridPlayerPosition.x = CalculatePositionOnAxisWithWrap(_onTileGridPlayerPosition.x, true);
            _onTileGridPlayerPosition.y = CalculatePositionOnAxisWithWrap(_onTileGridPlayerPosition.y, false);
            UpdateTilesOnScreen();
        }
    }

    private void UpdateTilesOnScreen()
    {
        for (int pov_x = -(fieldOfVisionWidth / 2); pov_x <= fieldOfVisionWidth / 2; pov_x++)
        {
            for (int pov_y = -(fieldOfVisionHeight / 2); pov_y <= fieldOfVisionHeight / 2; pov_y++)
            {
                int tileToUpdate_x = CalculatePositionOnAxisWithWrap(playerTilePosition.x + pov_x, true);
                int tileToUpdate_y = CalculatePositionOnAxisWithWrap(playerTilePosition.y + pov_y, false);

                GameObject tile = terrainTiles[tileToUpdate_x, tileToUpdate_y];
                tile.transform.position =
                    CalculateTilePosition(playerTilePosition.x + pov_x, playerTilePosition.y + pov_y);
            }
        }
    }

    private Vector3 CalculateTilePosition(int povX, int povY)
    {
        return new Vector3(povX * tileSize, povY * tileSize, 0f);
    }

    private int CalculatePositionOnAxisWithWrap(float currentValue, bool horizontal)
    {
        if (horizontal)
        {
            if (currentValue >= 0)
            {
                currentValue = currentValue % terrainTileHorizontalCount;
            }
            else
            {
                currentValue += 1;
                currentValue =
                    terrainTileHorizontalCount - 1 + currentValue % terrainTileHorizontalCount;
            }
        }
        else
        {
            if (currentValue >= 0)
            {
                currentValue = currentValue % terrainTileVerticalCount;
            }
            else
            {
                currentValue += 1;
                currentValue =
                    terrainTileVerticalCount - 1 + currentValue % terrainTileVerticalCount;
            }
        }

        return (int) currentValue;
    }
}