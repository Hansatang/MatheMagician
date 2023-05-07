using UnityEngine;
using UnityEngine.Events;

namespace Player
{
    /// <summary>
    ///    Class responsible for input and rotation of player
    /// </summary>
    public class PlayerInput : MonoBehaviour
    {
        public Vector2 inputAxis;
        public Quaternion rotation;

        public UnityEvent<bool, Vector2> movementEvent;

        private bool _isAlive = true;

        private void Update()
        {
            if (!_isAlive) return;

            inputAxis.Set(GetHorizontalAxisValue(), GetVerticalAxisValue());
            if (inputAxis.x != 0 || inputAxis.y != 0)
            {
                movementEvent?.Invoke(true, new Vector2(inputAxis.x, inputAxis.y));
            }
            else
            {
                movementEvent?.Invoke(false, new Vector2(inputAxis.x, inputAxis.y));
            }

            rotation = GetRotation();
        }


        private float GetHorizontalAxisValue()
        {
            return Input.GetAxis("Horizontal");
        }

        private float GetVerticalAxisValue()
        {
            return Input.GetAxis("Vertical");
        }

        /// <summary>
        ///    As the player doesn't use rotation for movement, but it's still needed for shooting direction,
        ///    the inputs are manually translated into rotation values
        /// </summary>
        private Quaternion GetRotation()
        {
            if (inputAxis.x == 0 && inputAxis.y == 0)
            {
                return rotation;
            }

            return rotation = Quaternion.Euler(0, 0,
                Mathf.Atan2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) * -Mathf.Rad2Deg);
        }

        public void DenyInput()
        {
            _isAlive = false;
        }
    }
}