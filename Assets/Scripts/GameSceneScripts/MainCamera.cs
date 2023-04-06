using UnityEngine;
using UnityEngine.Events;

public class MainCamera : MonoBehaviour
{
    public GameObject player;
    private Camera _cam;
    public float maxZoom = 2;
    public float minZoom = 7;
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
        Vector3 pos = player.transform.position;
        transform.position = new Vector3(pos.x, pos.y, -10);
        if (Input.mouseScrollDelta.y != 0)
        {
            _targetZoom -= Input.mouseScrollDelta.y * sensitivity;
            _targetZoom = Mathf.Clamp(_targetZoom, maxZoom, minZoom);
            float newSize = Mathf.MoveTowards(_cam.orthographicSize, _targetZoom, speed * Time.deltaTime);
            _cam.orthographicSize = newSize;
            cameraZoom.Invoke();
        }
    }
}