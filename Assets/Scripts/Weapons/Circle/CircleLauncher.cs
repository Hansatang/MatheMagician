using UnityEngine;

public class CircleLauncher : MonoBehaviour, IWeaponSystem
{
    [SerializeField] public CircleBullet circleBullet;

    // Start is called before the first frame update
    private float _rotateSpeed = 2f;
    private float _radius = 2.0f;
    private float _power = 1.0f;

    private GameObject _player;
    private float _angle;

    // Start is called before the first frame update

    private void Awake()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
    }

    public void Upgrade(float area, float power, float speed)
    {
        circleBullet.Upgrade(area, power, speed);
    }

    public void Arm()
    {
        Debug.Log("A " + _player.transform.position);
        Debug.Log("B " + transform.parent.position);
        CircleBullet instantiatedBullet = Instantiate(circleBullet, transform.parent.position, Quaternion.identity,
            gameObject.transform);
        circleBullet = instantiatedBullet;
    }

    public void Stop()
    {
        circleBullet.Stop();
    }
}