using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System.Linq;

public enum DogPattern
{
    WalkingOnly,
    RunningWithStamina
}

public class Dog : MonoBehaviour
{
    private IDogState currentState;
    private DogPatrolWalkingState dogPatrolWalkingState;
    private DogPatrolRunningState dogPatrolRunningState;
    private DogPatrolRestingState dogPatrolRestingState;

    public Transform waypoint;
    public List<Transform> waypoints;
    public float waypointRegisterDistance = 1f;
    public int currentWaypointIndex = 0;

    public NavMeshAgent navMeshAgent;
    public DogPattern dogPattern;


    void Start()
    {
        waypoints = waypoint.transform.GetComponentsInChildren<Transform>().Skip(1).ToList();
        transform.position = waypoints[0].position;

        InitializeStates();
    }

    private void InitializeStates()
    {
        switch (dogPattern)
        {
            case DogPattern.WalkingOnly:
                dogPatrolWalkingState = new DogPatrolWalkingState();
                SetState(dogPatrolWalkingState);
                break;

            case DogPattern.RunningWithStamina:
                dogPatrolRunningState = new DogPatrolRunningState();
                SetState(dogPatrolRunningState);
                break;

            default:
                break;
        }     
    }

    void Update()
    {
        currentState.UpdateState();
    }

    public void SetState(IDogState dogState)
    {
        currentState = dogState;
        dogState.EnterState(this);
    }
}
