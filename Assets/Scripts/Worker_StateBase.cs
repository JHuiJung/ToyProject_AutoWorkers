using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Worker_StateBase
{
    // Start is called before the first frame update
    public abstract void Enter(WorkerController wc);

    public abstract void Excute(WorkerController wc);

    public abstract void Exit();

}
