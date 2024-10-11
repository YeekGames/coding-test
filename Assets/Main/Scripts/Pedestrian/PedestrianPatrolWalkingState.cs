using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PedestrianPatrolWalkingState : PedestrianState
{
    private PedestrianBehaviour pedestrianBehaviour;

    public override void EnterState(PedestrianBehaviour _pedestrianBehaviour)
    {
        pedestrianBehaviour = _pedestrianBehaviour;

        pedestrianBehaviour.navMeshAgent.speed = pedestrianBehaviour.pedestrianSO.walkingSpeed;
        pedestrianBehaviour.isPatroling = true;
    }

    public override void UpdateState()
    {

    }
}
