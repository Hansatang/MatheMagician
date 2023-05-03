using UnityEngine;

namespace AI
{
    public class ObstacleDetector : Detector
    {
        [SerializeField] private float detectionRadius = 2;

        [SerializeField] private LayerMask layerMask;

        private Collider2D[] _colliders;

        public override void Detect(AIData aiData)
        {
            _colliders = Physics2D.OverlapCircleAll(transform.position, detectionRadius, layerMask);
            aiData.obstacles = _colliders;
        }
    }
}