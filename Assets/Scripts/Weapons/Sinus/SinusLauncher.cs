using System.Collections;
using UnityEngine;

public class SinusLauncher : MonoBehaviour, IWeaponSystem
{
    [SerializeField] public SinusBullet sinBullet;
    private PlayerInput _playerInput;

    public void Awake()
    {
        _playerInput = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInput>();
        Arm();
    }

    public void Upgrade(float area, float power, float speed)
    {
        //  sinBullet.Upgrade(area, power, speed);
    }

    public void Arm()
    {
        StartCoroutine(nameof(SpawnSinBullet));
    }

    private IEnumerator SpawnSinBullet()
    {
        while (true)
        {
            SinusBullet instantiatedBullet =
                Instantiate(sinBullet, transform.position, _playerInput.Rotation, gameObject.transform);
            yield return new WaitForSeconds(2);
        }
    }


    public void Stop()
    {
        StopCoroutine(nameof(SpawnSinBullet));
    }
}