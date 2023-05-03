using System.Collections.Generic;
using UnityEngine;

namespace AI
{
    public class TargetDetector : Detector
    {
        [SerializeField] private float targetDetectionRange = 5;

        [SerializeField] private LayerMask obstaclesLayerMask, playerLayerMask;
        
        //gizmo parameters
        private List<Transform> _colliders;

        public override void Detect(AIData aiData)
        {
            //Find out if player is near
            var playerCollider =
                Physics2D.OverlapCircle(transform.position, targetDetectionRange, playerLayerMask);

            if (playerCollider != null)
            {
                //Check if you see the player
                Vector2 direction = (playerCollider.transform.position - transform.position).normalized;
                var hit =
                    Physics2D.Raycast(transform.position, direction, targetDetectionRange, obstaclesLayerMask);

                //Make sure that the collider we see is on the "Player" layer
                if (hit.collider != null && (playerLayerMask & (1 << hit.collider.gameObject.layer)) != 0)
                    //Debug.DrawRay(transform.position, direction * targetDetectionRange, Color.magenta);
                    _colliders = new List<Transform> {playerCollider.transform};
                else
                    _colliders = null;
            }
            else
            {
                //Enemy doesn't see the player
                _colliders = null;
            }

            aiData.targets = _colliders;
        }
    }
}