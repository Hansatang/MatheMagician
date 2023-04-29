using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

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

        public virtual IEnumerator BehaviourLogic()
        {
            while (true)
            {
                if (aiData.currentTarget == null)
                {
                    //Stopping Logic
                    Debug.Log("Stopping");
                    movementInput = Vector2.zero;
                    following = false;
                    yield break;
                }

                //Chase logic
                movementInput = movementDirectionSolver.GetDirectionToMove(steeringBehaviours, aiData);
                yield return new WaitForSeconds(aiUpdateDelay);
            }
        }
    }
}