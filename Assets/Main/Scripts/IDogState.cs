using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDogState
{
    void EnterState(Dog dog);

    void UpdateState();
}
