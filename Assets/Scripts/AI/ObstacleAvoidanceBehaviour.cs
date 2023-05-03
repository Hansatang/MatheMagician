using System.Collections.Generic;
using UnityEngine;

namespace AI
{
    public class ObstacleAvoidanceBehaviour : SteeringBehaviour
    {
        [SerializeField] private float radius = 2f, agentColliderSize = 0.6f;

        public override (float[] danger, float[] interest) GetSteering(float[] danger, float[] interest, AIData aiData)
        {
            foreach (var obstacleCollider in aiData.obstacles)
            {
                var directionToObstacle
                    = obstacleCollider.ClosestPoint(transform.position) - (Vector2) transform.position;
                var distanceToObstacle = directionToObstacle.magnitude;

                //calculate weight based on the distance Enemy<--->Obstacle
                var weight
                    = distanceToObstacle <= agentColliderSize
                        ? 1
                        : (radius - distanceToObstacle) / radius;

                var directionToObstacleNormalized = directionToObstacle.normalized;

                //Add obstacle parameters to the danger array
                for (var i = 0; i < Directions.EightDirections.Count; i++)
                {
                    var result = Vector2.Dot(directionToObstacleNormalized, Directions.EightDirections[i]);

                    var valueToPutIn = result * weight;

                    //override value only if it is higher than the current one stored in the danger array
                    if (valueToPutIn > danger[i]) danger[i] = valueToPutIn;
                }
            }

            return (danger, interest);
        }
    }

    public static class Directions
    {
        public static readonly List<Vector2> EightDirections = new()
        {
            new Vector2(0, 1).normalized,
            new Vector2(1, 1).normalized,
            new Vector2(1, 0).normalized,
            new Vector2(1, -1).normalized,
            new Vector2(0, -1).normalized,
            new Vector2(-1, -1).normalized,
            new Vector2(-1, 0).normalized,
            new Vector2(-1, 1).normalized
        };
    }
}