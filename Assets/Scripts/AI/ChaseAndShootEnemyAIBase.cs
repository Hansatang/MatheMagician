using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace AI
{
    public class ChaseAndShootEnemyAIBase : EnemyAIBase
    {
        [SerializeField] private float attackDelay = 2.0f;
        [SerializeField] private float attackDistance = 5.0f;
        public UnityEvent<Vector2> onAttackPressed;
        public UnityEvent<bool> isAttacking;

        public override IEnumerator BehaviourLogic()
        {
            while (true)
            {
                if (aiData.currentTarget == null)
                {
                    //Stopping Logic
                    movementInput = Vector2.zero;
                    following = false;
                    yield break;
                }

                var distance = Vector2.Distance(aiData.currentTarget.position, transform.position);

                if (distance < attackDistance)
                {
                    //Attack logic
                    movementInput = Vector2.zero;
                    onAttackPressed?.Invoke(aiData.currentTarget.position);
                    isAttacking?.Invoke(true);
                    yield return new WaitForSeconds(attackDelay);
                }
                else
                {
                    //Chase logic
                    movementInput = movementDirectionSolver.GetDirectionToMove(steeringBehaviours, aiData);
                    isAttacking?.Invoke(false);
                    yield return new WaitForSeconds(aiUpdateDelay);
                }
            }
        }
    }
}