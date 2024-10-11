using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System.Linq;

public class DogBehaviour : MonoBehaviour
{
    private DogState currentState;
    [HideInInspector] public DogPatrolWalkingState dogPatrolWalkingState;
    [HideInInspector] public DogPatrolRunningState dogPatrolRunningState;
    [HideInInspector] public DogPatrolRestingState dogPatrolRestingState;
    
    public DogSO dogSO;

    public Animator animator;

    public Transform waypoint;
    public List<Transform> waypoints;
    public float waypointRegisterDistance = 1f;
    public int currentWaypointIndex = 0;

    public NavMeshAgent navMeshAgent;

    public bool isPatroling;


    void Start()
    {
        waypoints = waypoint.transform.GetComponentsInChildren<Transform>().Skip(1).ToList();
        transform.position = waypoints[0].position;

        InitializeStates();
    }

    private void InitializeStates()
    {
        switch (dogSO.dogBehaviourPattern)
        {
            case DogSO.DogBehaviourPattern.WalkingOnly:
                dogPatrolWalkingState = new DogPatrolWalkingState();
                SetState(dogPatrolWalkingState);
                break;

            case DogSO.DogBehaviourPattern.RunningWithStamina:
                dogPatrolRunningState = new DogPatrolRunningState();
                dogPatrolRestingState = new DogPatrolRestingState();
                SetState(dogPatrolRunningState);
                break;

            default:
                break;
        }  
    }

    void Update()
    {
        currentState.UpdateState();
        Patrol();
    }

    public void SetState(DogState dogState)
    {
        currentState = dogState;
        dogState.EnterState(this);
    }

    public void Patrol()
    {
        if (!isPatroling) return;

        var nextWaypointIndex = (currentWaypointIndex + 1) % waypoints.Count;
        var nextWaypointPosition = waypoints[nextWaypointIndex].position;
        var distanceToNextWaypoint = Vector3.Distance(nextWaypointPosition, transform.position);

        if (distanceToNextWaypoint <= waypointRegisterDistance)
        {
            currentWaypointIndex = nextWaypointIndex;
        }

        navMeshAgent.SetDestination(nextWaypointPosition);
    }
}
