using System.Collections;
using UnityEngine;

public class DoubleSinusLauncher : IWeaponSystem
{
    [SerializeField] public SinusBullet sinBullet;
    private PlayerInput _playerInput;
    private Coroutine _spawningUpperBulletCoroutine;
    private Coroutine _spawningLowerBulletCoroutine;

    public void Awake()
    {
        _playerInput = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInput>();
    }


    public override void Arm(float speedEnhancements, float powerEnhancements, float areaEnhancements)
    {
        _spawningUpperBulletCoroutine =
            StartCoroutine(SpawnSinBullet(speedEnhancements, powerEnhancements, areaEnhancements, true));
        _spawningUpperBulletCoroutine =
            StartCoroutine(SpawnSinBullet(speedEnhancements, powerEnhancements, areaEnhancements, false));
    }

    private IEnumerator SpawnSinBullet(float speedEnhancements, float powerEnhancements, float areaEnhancements,
        bool upper)
    {
        while (true)
        {
            if (upper)
            {
                SinusBullet instantiatedBullet =
                    Instantiate(sinBullet, transform.position, _playerInput.Rotation, gameObject.transform);
                instantiatedBullet.UpgradeAll(speedEnhancements, powerEnhancements, areaEnhancements);
                yield return new WaitForSeconds(2);
            }
            else
            {
                SinusBullet instantiatedBullet =
                    Instantiate(sinBullet, transform.position, _playerInput.Rotation, gameObject.transform);
                instantiatedBullet.UpgradeAll(speedEnhancements, powerEnhancements, areaEnhancements);
                instantiatedBullet.Reverse();
                yield return new WaitForSeconds(2);
            }
          
        }
    }


    public void Stop()
    {
        StopCoroutine(_spawningUpperBulletCoroutine);
        StopCoroutine(_spawningLowerBulletCoroutine);
    }

    public override void UpgradeAll(float speedEnhancements, float powerEnhancements, float areaEnhancements)
    {
        Stop();
        Arm(speedEnhancements, powerEnhancements, areaEnhancements);
    }
}