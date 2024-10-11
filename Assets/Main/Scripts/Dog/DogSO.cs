using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(menuName = "SO/Dog")]
public class DogSO : ScriptableObject
{
    public enum DogBehaviourPattern
    {
        WalkingOnly,
        RunningWithStamina
    }
    public DogBehaviourPattern dogBehaviourPattern = DogBehaviourPattern.WalkingOnly;

    public float walkingSpeed = 1f;
    public float runningSpeed = 2f;
    public float restingDuration = 1f;

    public float maxStamina = 10f;
    public float walkingStaminaDepletionRate = 1f;
    public float runningStaminaDepletionRate = 2f;
    public float staminaRecoveryRate = 2f;
}
