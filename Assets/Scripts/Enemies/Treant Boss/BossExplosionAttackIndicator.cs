using System.Collections;
using UnityEngine;

namespace Enemies.Treant_Boss
{
    /// <summary>
    ///     Class responsible for managing the expanding attack indicator, which at the end spawn the actual projectiles
    /// </summary>
    public class BossExplosionAttackIndicator : MonoBehaviour
    {
        public ParticleSystem sporeExplosion;
        private float _currentScale = InitScale;
        private const float TargetScale = 1f;
        private const float InitScale = 0f;
        private const int FramesCount = 100;
        private const float AnimationTimeSeconds = 2;
        private float _deltaTime = AnimationTimeSeconds / FramesCount;
        private float _dx = (TargetScale - InitScale) / FramesCount;
        private bool _upScale = true;

        private void Start()
        {
            StartCoroutine(ExpandArea());
        }

        /// <summary>
        ///    Increases scale over time up to TargetScale
        /// </summary>
        private IEnumerator ExpandArea()
        {
            while (true)
            {
                while (_upScale)
                {
                    _currentScale += _dx;
                    if (_currentScale > TargetScale)
                    {
                        _upScale = false;
                        _currentScale = TargetScale;
                    }

                    transform.localScale = Vector3.one * _currentScale;
                    yield return new WaitForSeconds(_deltaTime);
                }

                SpawnExplosionParticles();
                yield break;
            }
        }

        private void SpawnExplosionParticles()
        {
            Instantiate(sporeExplosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}