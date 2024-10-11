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

        pedestrianBehaviour.animator.ResetTrigger("Run");
        pedestrianBehaviour.animator.SetTrigger("Walk");
    }

    public override void UpdateState()
    {
        OnAlert();
    }

    private void OnAlert()
    {
        Collider[] hits = Physics.OverlapSphere(pedestrianBehaviour.transform.position, pedestrianBehaviour.alertRadius);

        foreach (Collider hit in hits)
        {
            if (hit.TryGetComponent(out IAlertable alertable))
            {
                //Debug.Log("HIT");
                pedestrianBehaviour.alertTarget = alertable;
                pedestrianBehaviour.SetState(pedestrianBehaviour.pedestrianPatrolFleeingState);
            }
        }    
    }
}
