using System.Collections;
using UnityEngine;

public class SinusLauncher : MonoBehaviour, IWeaponSystem
{
    [SerializeField] public GameObject sinBullet;

    private GameObject _player;
    // Start is called before the first frame update

    public void Awake()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
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
        Instantiate(sinBullet, new Vector3(_player.transform.position.x, _player.transform.position.y, 0),
            Quaternion.identity);
        yield return new WaitForSeconds(2);
        StartCoroutine(nameof(SpawnSinBullet));
    }


    public void Stop()
    {
        StopCoroutine(nameof(SpawnSinBullet));
    }
}