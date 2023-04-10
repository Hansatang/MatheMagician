using UnityEngine;

namespace Player
{
    public class PlayerInput : MonoBehaviour
    {
        public float Horizontal { get; private set; }
        public float Vertical { get; private set; }
        public float LastHorizontal { get; private set; }
        public float LastVertical { get; private set; }

        public Quaternion Rotation { get; private set; }

        void Update()
        {
            Horizontal = GetHorizontalAxisValue();
            Vertical = GetVerticalAxisValue();

            if (Horizontal == 1 || Horizontal == -1 || Vertical == 1 || Vertical == -1)
            {
                LastHorizontal = Horizontal;
                LastVertical = Vertical;
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

        private float GetLastHorizontalAxisValue()
        {
            return LastHorizontal;
        }

        private float GetLastVerticalAxisValue()
        {
            return LastVertical;
        }

        private Quaternion GetRotation()
        {
            if (Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") < 0)
            {
                return Rotation = Quaternion.Euler(0, 0, 180);
            }

            if (Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") > 0)
            {
                return Rotation = Quaternion.Euler(0, 0, 0);
            }

            if (Input.GetAxis("Horizontal") < 0 && Input.GetAxis("Vertical") == 0)
            {
                return Rotation = Quaternion.Euler(0, 0, 90);
            }

            if (Input.GetAxis("Horizontal") > 0 && Input.GetAxis("Vertical") == 0)
            {
                return Rotation = Quaternion.Euler(0, 0, 270);
            }

            if (Input.GetAxis("Horizontal") < 0 && Input.GetAxis("Vertical") < 0)
            {
                return Rotation = Quaternion.Euler(0, 0, 135);
            }

            if (Input.GetAxis("Horizontal") > 0 && Input.GetAxis("Vertical") < 0)
            {
                return Rotation = Quaternion.Euler(0, 0, -135);
            }

            if (Input.GetAxis("Horizontal") > 0 && Input.GetAxis("Vertical") > 0)
            {
                return Rotation = Quaternion.Euler(0, 0, -45);
            }

            if (Input.GetAxis("Horizontal") < 0 && Input.GetAxis("Vertical") > 0)
            {
                return Rotation = Quaternion.Euler(0, 0, 45);
            }

            return Rotation;
        }
    }
}