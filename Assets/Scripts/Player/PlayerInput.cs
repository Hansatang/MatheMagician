using UnityEngine;
using UnityEngine.Events;

namespace Player
{
    public class PlayerInput : MonoBehaviour
    {
        public float Horizontal { get; private set; }
        public float Vertical { get; private set; }

        public Quaternion Rotation { get; private set; }

        public UnityEvent<bool, Vector2> movementEvent;

        private void Update()
        {
            Horizontal = GetHorizontalAxisValue();
            Vertical = GetVerticalAxisValue();

            if (Horizontal != 0 || Vertical != 0)
            {
                movementEvent?.Invoke(true, new Vector2(Horizontal, Vertical));
            }
            else
            {
                movementEvent?.Invoke(false, new Vector2(Horizontal, Vertical));
            }

            Rotation = GetRotation();
        }

        private float GetHorizontalAxisValue()
        {
            return Input.GetAxis("Horizontal");
        }

        private float GetVerticalAxisValue()
        {
            return Input.GetAxis("Vertical");
        }


        private Quaternion GetRotation()
        {
            if (Horizontal == 0 && Vertical == 0)
            {
                return Rotation;
            }
            return Rotation = Quaternion.Euler(0, 0,
                Mathf.Atan2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) * -Mathf.Rad2Deg);
        }
    }
}