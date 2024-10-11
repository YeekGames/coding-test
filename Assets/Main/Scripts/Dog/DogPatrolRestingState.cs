using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogPatrolRestingState : DogState
{
    private DogBehaviour dogBehaviour;
    private DogSO dogSO;
    private float maxStamina, stamina;

    public override void EnterState(DogBehaviour _dogBehaviour)
    {
        dogBehaviour = _dogBehaviour;

        dogSO = dogBehaviour.dogSO;
        maxStamina = dogSO.maxStamina;
        stamina = 0f;

        dogBehaviour.isPatroling = false;
        dogBehaviour.navMeshAgent.isStopped = true;

        dogBehaviour.animator.ResetTrigger("Run");
        dogBehaviour.animator.SetTrigger("Rest");
    }

    public override void UpdateState()
    {
        RecoverStamina();

        if (stamina >= maxStamina)
        {
            dogBehaviour.navMeshAgent.isStopped = false;
            dogBehaviour.SetState(dogBehaviour.dogPatrolRunningState);
        }
    }

    private void RecoverStamina()
    {
        stamina += dogSO.staminaRecoveryRate * Time.deltaTime;
    }
}
