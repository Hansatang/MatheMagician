using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace AI
{
    public class EnemyAIBase : MonoBehaviour
    {
        [SerializeField] protected List<SteeringBehaviour> steeringBehaviours;
        [SerializeField] protected List<Detector> detectors;

        [SerializeField] protected AIData aiData;

        [SerializeField] protected float detectionDelay = 0.10f;
        [SerializeField] protected float aiUpdateDelay = 0.10f;

        //Inputs sent from the Enemy AI to the Enemy controller
        public UnityEvent<Vector2> onMovementInput;
        public UnityEvent<Vector2> onPointerInput;
        public UnityEvent<bool> isAttacking;

        [SerializeField] protected Vector2 movementInput;

        [SerializeField] protected ContextSolver movementDirectionSolver;

        protected bool following;

        private void Start()
        {
            //Detecting Player and Obstacles around
            InvokeRepeating("PerformDetection", 0, detectionDelay);
        }

        private void Update()
        {
            //Enemy AI movement based on Target availability
            if (aiData.currentTarget != null)
                //Looking at the Target
                LookAtTarget();
            else if (aiData.GetTargetsCount() > 0)
                //Target acquisition logic
                aiData.currentTarget = aiData.targets[0];

            //Moving the Agent
            onMovementInput?.Invoke(movementInput);
        }

        private void PerformDetection()
        {
            foreach (var detector in detectors) detector.Detect(aiData);
        }

        private void LookAtTarget()
        {
            onPointerInput?.Invoke(aiData.currentTarget.position);
            if (following == false)
            {
                following = true;
                StartCoroutine(BehaviourLogic());
            }
        }

        protected virtual IEnumerator BehaviourLogic()
        {
            while (true)
            {
                if (aiData.currentTarget == null)
                {
                    //Stopping Logic
                    StopLogic();
                    yield break;
                }

                //Chase logic
                yield return ChaseLogic();
            }
        }

        protected object ChaseLogic()
        {
            movementInput = movementDirectionSolver.GetDirectionToMove(steeringBehaviours, aiData);
            isAttacking?.Invoke(false);
            return new WaitForSeconds(aiUpdateDelay);
        }

        protected void StopLogic()
        {
            movementInput = Vector2.zero;
            following = false;
        }
    }
}