using System.Collections.Generic;
using UnityEngine;

namespace AI
{
    public class ContextSolver : MonoBehaviour
    {
        [SerializeField] private bool showGizmos = true;

        //gizmo parameters
        private float[] _interestGizmo = new float[0];
        private const float RayLength = 2;
        private Vector2 _resultDirection = Vector2.zero;

        private void Start()
        {
            _interestGizmo = new float[8];
        }


        private void OnDrawGizmos()
        {
            if (Application.isPlaying && showGizmos)
            {
                Gizmos.color = Color.yellow;
                Gizmos.DrawRay(transform.position, _resultDirection * RayLength);
            }
        }

        public Vector2 GetDirectionToMove(List<SteeringBehaviour> behaviours, AIData aiData)
        {
            var danger = new float[8];
            var interest = new float[8];

            //Loop through each behaviour
            foreach (var behaviour in behaviours) (danger, interest) = behaviour.GetSteering(danger, interest, aiData);

            //subtract danger values from interest array
            for (var i = 0; i < 8; i++) interest[i] = Mathf.Clamp01(interest[i] - danger[i]);

            _interestGizmo = interest;

            //get the average direction
            var outputDirection = Vector2.zero;
            for (var i = 0; i < 8; i++) outputDirection += Directions.EightDirections[i] * interest[i];

            outputDirection.Normalize();

            _resultDirection = outputDirection;

            //return the selected movement direction
            return _resultDirection;
        }
    }
}