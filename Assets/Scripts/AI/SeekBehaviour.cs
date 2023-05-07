using System.Linq;
using UnityEngine;
using UnityEngine.Serialization;

namespace AI
{
    public class SeekBehaviour : SteeringBehaviour
    {
        [FormerlySerializedAs("targetRechedThreshold")] [SerializeField]
        private float targetReachedThreshold = 0.5f;


        private bool _reachedLastTarget = true;

        //gizmo parameters
        private Vector2 _targetPositionCached;

        public override (float[] danger, float[] interest) GetSteering(float[] danger, float[] interest, AIData aiData)
        {
            //if we don't have a target stop seeking
            //else set a new target
            if (_reachedLastTarget)
            {
                if (aiData.targets == null || aiData.targets.Count <= 0)
                {
                    aiData.currentTarget = null;
                    return (danger, interest);
                }

                _reachedLastTarget = false;
                aiData.currentTarget = aiData.targets.OrderBy
                    (target => Vector2.Distance(target.position, transform.position)).FirstOrDefault();
            }

            //cache the last position only if we still see the target (if the targets collection is not empty)
            if (aiData.currentTarget != null && aiData.targets != null && aiData.targets.Contains(aiData.currentTarget))
                _targetPositionCached = aiData.currentTarget.position;

            //First check if we have reached the target
            if (Vector2.Distance(transform.position, _targetPositionCached) < targetReachedThreshold)
            {
                _reachedLastTarget = true;
                aiData.currentTarget = null;
                return (danger, interest);
            }

            //If we haven't yet reached the target do the main logic of finding the interest directions
            var directionToTarget = _targetPositionCached - (Vector2) transform.position;
            for (var i = 0; i < interest.Length; i++)
            {
                var result = Vector2.Dot(directionToTarget.normalized, Directions.EightDirections[i]);

                //accept only directions at the less than 90 degrees to the target direction
                if (result > 0)
                {
                    var valueToPutIn = result;
                    if (valueToPutIn > interest[i]) interest[i] = valueToPutIn;
                }
            }

            return (danger, interest);
        }
    }
}