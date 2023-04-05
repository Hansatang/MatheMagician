using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class MainCamera : MonoBehaviour
{
    private Camera _cam;
    public float maxZoom = 5;
    public float minZoom = 20;
    public float sensitivity = 1;
    public float speed = 30;
    private float _targetZoom;
    public UnityEvent cameraZoom;

    void Start()
    {
        _cam = GetComponent<Camera>();
        _targetZoom = _cam.orthographicSize;
    }

    void Update()
    {
        _targetZoom -= Input.mouseScrollDelta.y * sensitivity;
        _targetZoom = Mathf.Clamp(_targetZoom, maxZoom, minZoom);
        float newSize = Mathf.MoveTowards(_cam.orthographicSize, _targetZoom, speed * Time.deltaTime);
        if (_cam.orthographicSize != newSize)
        {
            _cam.orthographicSize = newSize;
            cameraZoom.Invoke();
        }
    }
}