using System.Collections;
using Player;
using UnityEngine;

namespace Weapons.Sinus
{
    public class SinusLauncher : WeaponSystem
    {
        [SerializeField] public SinusBullet sinBullet;
        private readonly float _attackDelay = 1.5f;
        private PlayerInput _playerInput;

        public void Awake()
        {
            _playerInput = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInput>();
        }

        public override void Arm()
        {
            StartCoroutine(SpawnSinBullet());
        }

        private IEnumerator SpawnSinBullet()
        {
            while (true)
            {
                var instantiatedBullet =
                    Instantiate(sinBullet, transform.position, _playerInput.Rotation, gameObject.transform);
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