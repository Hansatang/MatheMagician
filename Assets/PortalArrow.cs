using System;
using UnityEngine;

public class PortalArrow : MonoBehaviour
{
    private GameObject _portal;

    private const float Speed = 2f;

    public const float RotationModifier = 90f;

    private void Start()
    {
        var transform1 = transform;
        var position = transform1.position;
        position = new Vector3(position.x, position.y + 1f, position.z);
        transform1.position = position;
    }

    private void Update()
    {
        if (_portal != null)
        {
            Vector3 vectorToTarget = _portal.transform.position - transform.position;
            float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg - RotationModifier;
            Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * Speed);
        }
    }

    public void SetPortal(GameObject portal)
    {
        _portal = portal;
    }
}