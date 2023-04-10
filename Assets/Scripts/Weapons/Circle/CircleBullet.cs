using System;
using UnityEngine;
using Weapons;
using Weapons.Circle;

public class CircleBullet : MonoBehaviour
{
    // Start is called before the first frame update
    private float _speed = 2f;
    private float _area = 2.0f;
    private float _power = 1.0f;

    private CircleLauncher origin;
    private float _angle;

    private void Awake()
    {
        origin = GetComponentInParent<CircleLauncher>();
    }

    private void Update()
    {
        _angle += _speed * Time.deltaTime;

        var offset = new Vector3(Mathf.Sin(_angle), Mathf.Cos(_angle), 0) * _area;
        transform.position = transform.parent.position + offset;
    }

    public void Stop()
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemies"))
        {
            //other.gameObject.GetComponent<Enemy>().TakeDamage(_power);
            //Destroy(gameObject);
        }
    }

    public void UpgradeAll(float speedEnhancements, float powerEnhancements, float areaEnhancements)
    {
        _area *= areaEnhancements;
        _speed *= speedEnhancements;
        _power *= powerEnhancements;
    }
}