using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace AI
{
    public class AngryMoleAI : EnemyAIBase
    {
        [SerializeField] private float attackDelay = 2.0f;

        [SerializeField] private float dashAttackDistance = 10.0f;

        private float _distanceToTarget;
        public UnityEvent<Vector2> onDash;

        protected override IEnumerator BehaviourLogic()
        {
            while (true)
            {
                if (aiData.currentTarget == null)
                {
                    //Stopping Logic
                    StopLogic();
                    yield break;
                }

                _distanceToTarget = Vector2.Distance(aiData.currentTarget.position, transform.position);

                if (_distanceToTarget > dashAttackDistance)
                {
                    //Chase logic
                    yield return ChaseLogic();
                }
                else
                {
                    //Dash logic
                    yield return DashLogic();
                }
            }
        }

        private object DashLogic()
        {
            onDash?.Invoke(movementDirectionSolver.GetDirectionToMove(steeringBehaviours, aiData));
            isAttacking?.Invoke(false);
            return new WaitForSeconds(attackDelay);
        }
    }
}