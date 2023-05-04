using UnityEngine;

namespace WorldBackground
{
    public class BackgroundWorld : MonoBehaviour
    {
        [SerializeField] private Transform playerTransform;
        [SerializeField] private Vector2Int playerTilePosition;

        [SerializeField] private int terrainTileHorizontalCount;
        [SerializeField] private int terrainTileVerticalCount;
        [SerializeField] private float tileSize = 40f;
        [SerializeField] private int fieldOfVisionHeight = 3;
        [SerializeField] private int fieldOfVisionWidth = 3;
        private Vector2Int _currentTilePosition = new(0, 0);
        private Vector2Int _onTileGridPlayerPosition;
        private GameObject[,] _terrainTiles;

        private void Awake()
        {
            _terrainTiles = new GameObject[terrainTileHorizontalCount, terrainTileVerticalCount];
        }

        private void Update()
        {
            playerTilePosition.x = (int) (playerTransform.position.x / tileSize);
            playerTilePosition.y = (int) (playerTransform.position.y / tileSize);

            playerTilePosition.x -= playerTransform.position.x < 0 ? 1 : 0;
            playerTilePosition.y -= playerTransform.position.y < 0 ? 1 : 0;

            if (_currentTilePosition != playerTilePosition)
            {
                _currentTilePosition = playerTilePosition;

                _onTileGridPlayerPosition.x = CalculatePositionOnAxisWithWrap(_onTileGridPlayerPosition.x, true);
                _onTileGridPlayerPosition.y = CalculatePositionOnAxisWithWrap(_onTileGridPlayerPosition.y, false);
                UpdateTilesOnScreen();
            }
        }

        public void AddTile(GameObject tileGameObject, Vector2Int tilePosition)
        {
            _terrainTiles[tilePosition.x, tilePosition.y] = tileGameObject;
        }

        private void UpdateTilesOnScreen()
        {
            for (var pov_x = -(fieldOfVisionWidth / 2); pov_x <= fieldOfVisionWidth / 2; pov_x++)
            for (var pov_y = -(fieldOfVisionHeight / 2); pov_y <= fieldOfVisionHeight / 2; pov_y++)
            {
                var tileToUpdate_x = CalculatePositionOnAxisWithWrap(playerTilePosition.x + pov_x, true);
                var tileToUpdate_y = CalculatePositionOnAxisWithWrap(playerTilePosition.y + pov_y, false);

                var tile = _terrainTiles[tileToUpdate_x, tileToUpdate_y];
                tile.transform.position =
                    CalculateTilePosition(playerTilePosition.x + pov_x, playerTilePosition.y + pov_y);
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
                    currentValue %= terrainTileHorizontalCount;
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
}