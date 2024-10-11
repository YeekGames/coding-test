using UnityEngine;
using UnityEngine.AI;

public class PedestrianPatrolFleeingState : PedestrianState
{
    private PedestrianBehaviour pedestrianBehaviour;
    private Vector3 targetDirection;
    private Vector3 fleeToDestination;

    public override void EnterState(PedestrianBehaviour _pedestrianBehaviour)
    {
        pedestrianBehaviour = _pedestrianBehaviour;
        targetDirection = pedestrianBehaviour.alertTarget.transform.position - pedestrianBehaviour.transform.position;

        pedestrianBehaviour.navMeshAgent.speed = pedestrianBehaviour.pedestrianSO.runningSpeed;
        pedestrianBehaviour.isPatroling = false;

        pedestrianBehaviour.animator.ResetTrigger("Walk");
        pedestrianBehaviour.animator.SetTrigger("Run");

        SetFleeDestination();

    }

    public override void UpdateState()
    {
        Flee();
    }

    private void SetFleeDestination()
    {
        fleeToDestination = pedestrianBehaviour.transform.position - targetDirection;
    }

    private void Flee()
    {
        pedestrianBehaviour.navMeshAgent.SetDestination(fleeToDestination);

        if (Vector3.Distance(fleeToDestination, pedestrianBehaviour.transform.position) <= 0.1f)
        {
            pedestrianBehaviour.SetState(pedestrianBehaviour.pedestrianPatrolingState);
        }
    }
}
