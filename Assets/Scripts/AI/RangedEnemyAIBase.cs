using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace AI
{
    public class RangedEnemyAIBase : EnemyAIBase
    {
        [SerializeField] private float attackDelay = 2.0f;
        [SerializeField] private float attackDistance = 5.0f;
        public UnityEvent<Vector2> onAttackPressed;
       
        public override IEnumerator BehaviourLogic()
        {
            while (true)
            {
                if (aiData.currentTarget == null)
                {
                    //Stopping Logic
                    StopLogic();
                    yield break;
                }

                var distance = Vector2.Distance(aiData.currentTarget.position, transform.position);

                if (distance < attackDistance)
                {
                    //Attack logic
                    yield return RangedAttackLogic();
                }
                else
                {
                    //Chase logic
                    yield return ChaseLogic();
                }
            }
        }

        private object RangedAttackLogic()
        {
            movementInput = Vector2.zero;
            onAttackPressed?.Invoke(aiData.currentTarget.position);
            isAttacking?.Invoke(true);
            return new WaitForSeconds(attackDelay);
        }
    }
}