using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public float Horizontal { get; private set; }
    public float Vertical { get; private set; }

    void Update()
    {
        Horizontal = GetHorizontalAxisValue();
        Vertical = GetVerticalAxisValue();
    }

    private float GetHorizontalAxisValue()
    {
        return Input.GetAxis("Horizontal");
    }

    private float GetVerticalAxisValue()
    {
        return Input.GetAxis("Vertical");
    }
}