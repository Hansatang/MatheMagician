using System.Collections;
using UnityEngine;

namespace Enemies
{
    public class EnemyExplosionAttackIndicator : MonoBehaviour
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
            StartCoroutine(Breath());
        }

        private IEnumerator Breath()
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

                Explode();
                yield break;
            }
        }

        private void Explode()
        {
            Instantiate(sporeExplosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}