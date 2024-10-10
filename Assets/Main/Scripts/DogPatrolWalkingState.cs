using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DogPatrolWalkingState : IDogState
{
    private Dog dog;

    public void EnterState(Dog _dog)
    {
        dog = _dog;
    }

    public void UpdateState()
    {
        Patrol();
    }

    public void Patrol()
    {
        var currentWaypointIndex = dog.currentWaypointIndex;
        var nextWaypointIndex = (currentWaypointIndex + 1) % dog.waypoints.Count;

        var nextWaypointPosition = dog.waypoints[nextWaypointIndex].position;
        var distanceToNextWaypoint = Vector3.Distance(nextWaypointPosition, dog.transform.position);

        if (distanceToNextWaypoint <= dog.waypointRegisterDistance)
        {
            dog.currentWaypointIndex = nextWaypointIndex;
        }

        dog.navMeshAgent.SetDestination(nextWaypointPosition);
    }
}
