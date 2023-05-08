using System.Collections;
using Misc;
using Player;
using UnityEngine;

namespace Weapons.Sinus
{
    /// <summary>
    ///    Class responsible for creating and managing the stats of two projectiles 
    /// </summary>
    public class DoubleSinusLauncher : SinusLauncher
    {
        public override void Arm()
        {
            base.Arm();
            StartCoroutine(SpawnSinBulletReversed());
        }

        private IEnumerator SpawnSinBulletReversed()
        {
            while (true)
            {
                var instantiatedObject = Instantiate(sinBullet, transform.position, playerInput.rotation,
                    gameObject.transform);
                instantiatedObject.SetStats(enhancedSpeed, enhancedPower, enhancedArea);
                instantiatedObject.Reverse();
                yield return new WaitForSeconds(AttackDelay);
            }
        }


        public override void Stop()
        {
            Destroy(gameObject);
        }

        
    }
}