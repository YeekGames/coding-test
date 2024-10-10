using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogPatrolRunningState : IDogState
{
    private Dog dog;

    public void EnterState(Dog _dog)
    {
        dog = _dog;
    }

    public void UpdateState()
    {
        //Patrol();
    }
}
