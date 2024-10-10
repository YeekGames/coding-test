using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System.Linq;

public class Dog_2 : MonoBehaviour, IDog
{
    private IDogState currentState;
    private DogPatrolWalkingState dogPatrolWalkingState;

    public Transform waypoint;
    public List<Transform> waypoints;
    public float waypointRegisterDistance = 1f;
    public int currentWaypointIndex = 0;

    public NavMeshAgent navMeshAgent;
    public float runningSpeed = 2f;
    public float restingDuration = 1f;


    void Start()
    {
        waypoints = waypoint.transform.GetComponentsInChildren<Transform>().Skip(1).ToList();
        transform.position = waypoints[0].position;
        InitializeStates();
    }

    private void InitializeStates()
    {
        dogPatrolWalkingState = new DogPatrolWalkingState();
        SetState(dogPatrolWalkingState);
    }

    void Update()
    {
        currentState.UpdateState();
    }

    public void SetState(IDogState dogState)
    {
        currentState = dogState;
        //dogState.EnterState(this);
    }
}
