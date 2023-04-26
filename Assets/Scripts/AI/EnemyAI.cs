using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private List<SteeringBehaviour> steeringBehaviours;

    [SerializeField] private List<Detector> detectors;

    [SerializeField] private AIData aiData;

    [SerializeField] private float detectionDelay = 0.05f, aiUpdateDelay = 0.06f;

    //Inputs sent from the Enemy AI to the Enemy controller
  
    public UnityEvent<Vector2> OnMovementInput;

    [SerializeField] private Vector2 movementInput;

    [SerializeField] private ContextSolver movementDirectionSolver;

    bool following = false;

    private void Start()
    {
        //Detecting Player and Obstacles around
        InvokeRepeating("PerformDetection", 0, detectionDelay);
    }

    private void PerformDetection()
    {
        foreach (Detector detector in detectors)
        {
            detector.Detect(aiData);
        }
    }

    private void Update()
    {
        //Enemy AI movement based on Target availability
        if (aiData.currentTarget != null)
        {
            if (following == false)
            {
                following = true;
                StartCoroutine(Chase());
            }
        }
        else if (aiData.GetTargetsCount() > 0)
        {
            //Target acquisition logic
            aiData.currentTarget = aiData.targets[0];
        }

        //Moving the Agent
        OnMovementInput?.Invoke(movementInput);
    }

    private IEnumerator Chase()
    {
        if (aiData.currentTarget == null)
        {
            //Stopping Logic
            Debug.Log("Stopping");
            movementInput = Vector2.zero;
            following = false;
            yield break;
        }
        else
        {
            //Chase logic
            movementInput = movementDirectionSolver.GetDirectionToMove(steeringBehaviours, aiData);
            yield return new WaitForSeconds(aiUpdateDelay);
            StartCoroutine(Chase());
        }
    }
}