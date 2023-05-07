using System.Collections;
using Player;
using UnityEngine;

namespace Weapons.Sinus
{
    /// <summary>
    ///    Class responsible for creating and managing the stats of two projectiles 
    /// </summary>
    public class DoubleSinusLauncher : WeaponSystem
    {
        [SerializeField] public SinusBullet sinBullet;
        private readonly float _attackDelay = 1f;
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
                        Instantiate(sinBullet, transform.position, _playerInput.rotation, gameObject.transform);
                    instantiatedBullet.SetStatistics(speedEnhanced, powerEnhanced, areaEnhanced);
                    yield return new WaitForSeconds(_attackDelay);
                }
                else
                {
                    var instantiatedBullet =
                        Instantiate(sinBullet, transform.position, _playerInput.rotation, gameObject.transform);
                    instantiatedBullet.SetStatistics(speedEnhanced, powerEnhanced, areaEnhanced);
                    instantiatedBullet.Reverse();
                    yield return new WaitForSeconds(_attackDelay);
                }
        }

        public override void Stop()
        {
            Destroy(gameObject);
        }
    }
}