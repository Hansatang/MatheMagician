using System.Collections.Generic;
using UnityEngine;

namespace AI
{
    public class ContextSolver : MonoBehaviour
    {
        private Vector2 _resultDirection = Vector2.zero;

        public Vector2 GetDirectionToMove(List<SteeringBehaviour> behaviours, AIData aiData)
        {
            var danger = new float[8];
            var interest = new float[8];

            //Loop through each behaviour
            foreach (var behaviour in behaviours) (danger, interest) = behaviour.GetSteering(danger, interest, aiData);

            //subtract danger values from interest array
            for (var i = 0; i < 8; i++) interest[i] = Mathf.Clamp01(interest[i] - danger[i]);

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