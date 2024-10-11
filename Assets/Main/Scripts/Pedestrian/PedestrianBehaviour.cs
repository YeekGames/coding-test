using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class PedestrianBehaviour : MonoBehaviour
{
    private PedestrianState currentState;
    [HideInInspector] public PedestrianPatrolWalkingState pedestrianPatrolingState;
    [HideInInspector] public PedestrianPatrolFleeingState pedestrianPatrolFleeingState;

    public PedestrianSO pedestrianSO;

    public Animator animator;

    public Transform waypoint;
    public List<Transform> waypoints;
    public float waypointRegisterDistance = 1f;
    public int currentWaypointIndex = 0;

    public NavMeshAgent navMeshAgent;

    public bool isPatroling;
    public float alertRadius = 2f;
    public IAlertable alertTarget;

    void Start()
    {
        waypoints = waypoint.transform.GetComponentsInChildren<Transform>().Skip(1).ToList();
        transform.position = waypoints[0].position;

        InitializeStates();
    }

    private void InitializeStates()
    {
        pedestrianPatrolingState = new PedestrianPatrolWalkingState();
        pedestrianPatrolFleeingState = new PedestrianPatrolFleeingState();

        SetState(pedestrianPatrolingState);
    }

    void Update()
    {
        currentState.UpdateState();
        Patrol();
    }

    public void SetState(PedestrianState pedestrianState)
    {
        currentState = pedestrianState;
        pedestrianState.EnterState(this);
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

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, alertRadius);

        if (waypoints.Count > 1)
        {
            for (int i = 0; i < waypoints.Count; i++)
            {
                Gizmos.color = Color.blue;
                var nextPoint = (i + 1) % waypoints.Count;
                Gizmos.DrawLine(waypoints[i].position, waypoints[nextPoint].position);
            }
        }
    }
}
