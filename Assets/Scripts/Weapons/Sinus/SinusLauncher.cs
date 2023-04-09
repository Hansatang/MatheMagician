using System.Collections;
using UnityEngine;

public class SinusLauncher : IWeaponSystem
{
    [SerializeField] public SinusBullet sinBullet;
    private PlayerInput _playerInput;
    private Coroutine _spawningBulletCoroutine;

    public void Awake()
    {
        _playerInput = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInput>();
    }

    public override void Arm(float speedEnhancements, float powerEnhancements, float areaEnhancements)
    {
        _spawningBulletCoroutine =
            StartCoroutine(SpawnSinBullet(speedEnhancements, powerEnhancements, areaEnhancements));
    }

    private IEnumerator SpawnSinBullet(float speedEnhancements, float powerEnhancements, float areaEnhancements)
    {
        while (true)
        {
            SinusBullet instantiatedBullet =
                Instantiate(sinBullet, transform.position, _playerInput.Rotation, gameObject.transform);
            instantiatedBullet.UpgradeAll(speedEnhancements, powerEnhancements, areaEnhancements);
            yield return new WaitForSeconds(2);
        }
    }


    public override void Stop()
    {
        Destroy(gameObject);
        StopCoroutine(_spawningBulletCoroutine);
    }

    public override void UpgradeAll(float speedEnhancements, float powerEnhancements, float areaEnhancements)
    {
        Stop();
        Arm(speedEnhancements, powerEnhancements, areaEnhancements);
    }
}