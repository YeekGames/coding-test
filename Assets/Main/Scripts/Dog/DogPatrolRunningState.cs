using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DogPatrolRunningState : DogState
{
    private DogBehaviour dogBehaviour;
    private DogSO dogSO;
    private float stamina;

    public override void EnterState(DogBehaviour _dogBehaviour)
    {
        dogBehaviour = _dogBehaviour;
        dogSO = dogBehaviour.dogSO;

        stamina = dogSO.maxStamina;
        dogBehaviour.navMeshAgent.speed = dogSO.runningSpeed;

        dogBehaviour.isPatroling = true;
        dogBehaviour.animator.ResetTrigger("Rest");
        dogBehaviour.animator.SetTrigger("Run");
    }

    public override void UpdateState()
    {
        UseStamina();

        if (stamina <= 0f)
        {
            dogBehaviour.SetState(dogBehaviour.dogPatrolRestingState);
        }
    }

    private void UseStamina()
    {
        stamina -= dogSO.runningStaminaDepletionRate * Time.deltaTime;
    }
}
