using Managers;
using UnityEngine;
using UnityEngine.Events;

namespace GameSceneScripts
{
    public class MainCamera : MonoBehaviour
    {
        public GameObject player;
        public float maxZoom = 2;
        public float minZoom = 7;
        public float sensitivity = 1;
        public float speed = 30;
        public UnityEvent cameraZoom;
        private Camera _cam;
        private float _targetZoom;


        private void Start()
        {
            _cam = GetComponent<Camera>();
            _targetZoom = _cam.orthographicSize;
        }

        private void Update()
        {
            var pos = player.transform.position;
            transform.position = new Vector3(pos.x, pos.y, -10);
            if (Input.mouseScrollDelta.y != 0 && !PauseManager.GamePaused)
            {
                _targetZoom -= Input.mouseScrollDelta.y * sensitivity;
                _targetZoom = Mathf.Clamp(_targetZoom, maxZoom, minZoom);
                var newSize = Mathf.MoveTowards(_cam.orthographicSize, _targetZoom, speed * Time.deltaTime);
                _cam.orthographicSize = newSize;
                cameraZoom.Invoke();
            }
        }
    }
}