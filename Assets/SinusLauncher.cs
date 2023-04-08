using System.Collections;
using UnityEngine;

public class SinusLauncher : MonoBehaviour, IWeaponSystem
{
    [SerializeField] public SinusBullet sinBullet;

    private GameObject _player;

    private PlayerInput _playerInput;
    // Start is called before the first frame update

    public void Awake()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _playerInput = _player.GetComponent<PlayerInput>();
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
            _playerInput.Rotation);
        yield return new WaitForSeconds(2);
        StartCoroutine(nameof(SpawnSinBullet));
    }


    public void Stop()
    {
        StopCoroutine(nameof(SpawnSinBullet));
    }
}