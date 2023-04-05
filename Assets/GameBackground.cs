using UnityEngine;

public class GameBackground : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;

    // The radius of a possible camera view
    private float _spaceCircleRadius;

    // Original background object dimensions
    private float _backgroundOriginalSizeX;
    private float _backgroundOriginalSizeY;

    private float _cameraOffsetX;
    private float _cameraOffsetY;

    void Start()
    {
        // Original Background Sizes
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        var originalSize = sr.size;
        _backgroundOriginalSizeX = originalSize.x;
        _backgroundOriginalSizeY = originalSize.y;
        CalculateSprite();
    }

    void Update()
    {
        // When the background reaches a shift equal to the original size in any direction, we return it to the origin exactly in this direction
        if (mainCamera.transform.position.x + _cameraOffsetX >= _backgroundOriginalSizeX)
        {
            _cameraOffsetX -= _backgroundOriginalSizeX;
            transform.Translate(_backgroundOriginalSizeX, 0, 0);
        }

        if (mainCamera.transform.position.x + _cameraOffsetX <= -_backgroundOriginalSizeX)
        {
            _cameraOffsetX += _backgroundOriginalSizeX;
            transform.Translate(-_backgroundOriginalSizeX, 0, 0);
        }

        if (mainCamera.transform.position.y + _cameraOffsetY >= _backgroundOriginalSizeY)
        {
            _cameraOffsetY -= _backgroundOriginalSizeY;
            transform.Translate(0, +_backgroundOriginalSizeY, 0);
        }

        if (mainCamera.transform.position.y + _cameraOffsetY <= -_backgroundOriginalSizeY)
        {
            _cameraOffsetY += _backgroundOriginalSizeY;
            transform.Translate(0, -_backgroundOriginalSizeY, 0);
        }
    }

    public void CalculateSprite()
    {
        // Camera height equal to the orthographic size
        float orthographicSize = mainCamera.orthographicSize;
        // Camera width equals to orthographic size multiplied by aspect ratio
        float screenAspect = Screen.width / (float) Screen.height;
        // The radius of the circle describing the camera
        _spaceCircleRadius = Mathf.Sqrt(orthographicSize * screenAspect * orthographicSize * screenAspect +
                                        orthographicSize * orthographicSize);

        // The final background sprite size should allow you to move by one basic background texture size in any direction + overlap the radius of the camera also in all directions
        GetComponent<SpriteRenderer>().size = new Vector2(_spaceCircleRadius * 2 + _backgroundOriginalSizeX * 2,
            _spaceCircleRadius * 2 + _backgroundOriginalSizeY * 2);

        Debug.Log("Size " + GetComponent<SpriteRenderer>().size);
    }
}