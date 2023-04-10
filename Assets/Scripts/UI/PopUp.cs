using UnityEngine;

namespace UI
{
    public class PopUp : MonoBehaviour
    {
        private float _timeToDestroy = 1f;

        void Start()
        {
            Destroy(gameObject, _timeToDestroy);
        }

        private void Update()
        {
            transform.position += Vector3.up * Time.deltaTime;
        }
    }
}