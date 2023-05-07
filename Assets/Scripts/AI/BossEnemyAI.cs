using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace AI
{
    public class BossEnemyAI : EnemyAIBase
    {
        [SerializeField] private float attackDelay = 2.0f;
        [SerializeField] private float rangedAttackDistance = 10.0f;
        [SerializeField] private float explosionAttackDistance = 5.0f;

        private float _distanceToTarget;
        private AttackType _currentAttackType;
        public UnityEvent<Vector2> onAttackRanged;

        public UnityEvent onAttackExplosion;
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

                if (_distanceToTarget > rangedAttackDistance)
                {
                    //Chase logic
                    yield return ChaseLogic();
                }
                else
                {
                    if (_currentAttackType == AttackType.Chase)
                    {
                        //Select Attack Type
                        _currentAttackType = (AttackType) Random.Range(1, 4);
                    }

                    if (_currentAttackType == AttackType.Dash)
                    {
                        if (_distanceToTarget < rangedAttackDistance)
                        {
                            //Dash logic
                            yield return DashLogic();
                        }
                    }
                    else if (_currentAttackType == AttackType.Ranged)
                    {
                        if (_distanceToTarget < rangedAttackDistance)
                        {
                            //Ranged Attack logic
                            yield return RangedAttackLogic();
                        }
                    }
                    else if (_currentAttackType == AttackType.Melee)
                    {
                        if (_distanceToTarget < explosionAttackDistance)
                        {
                            //Melee Attack Logic
                            yield return ExplosionAttackLogic();
                        }
                    }

                    //Chase logic
                    yield return ChaseLogic();
                }
            }
        }

        private object ExplosionAttackLogic()
        {
            movementInput = Vector2.zero;
            onAttackExplosion?.Invoke();
            _currentAttackType = AttackType.Chase;
            return new WaitForSeconds(attackDelay);
        }

        private object RangedAttackLogic()
        {
            movementInput = Vector2.zero;
            onAttackRanged?.Invoke(aiData.currentTarget.position);
            isAttacking?.Invoke(true);
            _currentAttackType = AttackType.Chase;
            return new WaitForSeconds(attackDelay);
        }


        private object DashLogic()
        {
            onDash?.Invoke(movementDirectionSolver.GetDirectionToMove(steeringBehaviours, aiData));
            isAttacking?.Invoke(false);
            _currentAttackType = AttackType.Chase;
            return new WaitForSeconds(attackDelay);
        }
    }
}