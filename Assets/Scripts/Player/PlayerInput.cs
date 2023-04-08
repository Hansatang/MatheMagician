using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public float Horizontal { get; private set; }
    public float Vertical { get; private set; }
    
    public Quaternion Rotation { get; private set; }

    void Update()
    {
        Horizontal = GetHorizontalAxisValue();
        Vertical = GetVerticalAxisValue();
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