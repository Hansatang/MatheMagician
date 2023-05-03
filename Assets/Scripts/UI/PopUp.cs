using UnityEngine;

namespace UI
{
    /// <summary>
    ///    Class responsible for moving and destroying the pop ups
    /// </summary>
    public class PopUp : MonoBehaviour
    {
        private readonly float _timeToDestroy = 1f;

        private void Start()
        {
            Destroy(gameObject, _timeToDestroy);
        }

        private void Update()
        {
            transform.position += Vector3.up * Time.deltaTime;
        }
    }
}