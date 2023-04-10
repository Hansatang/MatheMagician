using System.Collections;
using Player;
using UnityEngine;

namespace Weapons.Sinus
{
    public class DoubleSinusLauncher : WeaponSystem
    {
        [SerializeField] public SinusBullet sinBullet;
        private PlayerInput _playerInput;

        public void Awake()
        {
            _playerInput = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInput>();
        }

        public override void Arm()
        {
            StartCoroutine(SpawnSinBullet(true));

            StartCoroutine(SpawnSinBullet(false));
        }

        private IEnumerator SpawnSinBullet(bool upper)
        {
            while (true)
            {
                if (upper)
                {
                    SinusBullet instantiatedBullet =
                        Instantiate(sinBullet, transform.position, _playerInput.Rotation, gameObject.transform);
                    instantiatedBullet.SetStatistics(speed, power, area);
                    yield return new WaitForSeconds(2);
                }
                else
                {
                    SinusBullet instantiatedBullet =
                        Instantiate(sinBullet, transform.position, _playerInput.Rotation, gameObject.transform);
                    instantiatedBullet.SetStatistics(speed, power, area);
                    instantiatedBullet.Reverse();
                    yield return new WaitForSeconds(2);
                }
            }
        }

        public override void Stop()
        {
            Destroy(gameObject);
        }
    }
}