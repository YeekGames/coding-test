using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DogPatrolWalkingState : DogState
{
    private DogBehaviour dogBehaviour;

    public override void EnterState(DogBehaviour _dogBehaviour)
    {
        dogBehaviour = _dogBehaviour;

        dogBehaviour.navMeshAgent.speed = dogBehaviour.dogSO.walkingSpeed;
        dogBehaviour.isPatroling = true;
    }

    public override void UpdateState()
    {

    }
}
