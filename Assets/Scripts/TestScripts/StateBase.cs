using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StateBase
{
    public abstract void Enter(StateController controller);

    public abstract void Excute(StateController controller);
    public abstract void Exit();
}
