using System.Collections;
using Player;
using UnityEngine;

namespace Weapons.Sinus
{
    /// <summary>
    ///    Class responsible for creating and managing the stats of projectiles 
    /// </summary>
    public class SinusLauncher : WeaponSystem
    {
        [SerializeField] public SinusBullet sinBullet;
        private readonly float _attackDelay = 1f;
        private PlayerInput _playerInput;

        public override void Arm()
        {
            _playerInput = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInput>();
            StartCoroutine(SpawnSinBullet());
        }

        private IEnumerator SpawnSinBullet()
        {
            while (true)
            {
                var instantiatedBullet =
                    Instantiate(sinBullet, transform.position, _playerInput.rotation, gameObject.transform);
                instantiatedBullet.SetStatistics(speedEnhanced, powerEnhanced, areaEnhanced);
                yield return new WaitForSeconds(_attackDelay);
            }
        }

        public override void Stop()
        {
            Destroy(gameObject);
        }
    }
}