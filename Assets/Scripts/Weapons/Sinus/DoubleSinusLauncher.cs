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
                if (upper)
                {
                    var instantiatedBullet =
                        Instantiate(sinBullet, transform.position, _playerInput.Rotation, gameObject.transform);
                    instantiatedBullet.SetStatistics(speedEnhanced, powerEnhanced, areaEnhanced);
                    yield return new WaitForSeconds(2);
                }
                else
                {
                    var instantiatedBullet =
                        Instantiate(sinBullet, transform.position, _playerInput.Rotation, gameObject.transform);
                    instantiatedBullet.SetStatistics(speedEnhanced, powerEnhanced, areaEnhanced);
                    instantiatedBullet.Reverse();
                    yield return new WaitForSeconds(2);
                }
        }

        public override void Stop()
        {
            Destroy(gameObject);
        }
    }
}