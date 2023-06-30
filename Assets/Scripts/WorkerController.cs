using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkerController : Worker
{
    Worker_StateBase w_state = null;
    // Start is called before the first frame update
    void Start()
    {
        Change_State(new State_Test());
    }

    // Update is called once per frame
    void Update()
    {
        if(w_state != null)
        {
            w_state.Excute(this);
        }
    }

    public void Change_State(Worker_StateBase _state)
    {
        if (w_state != null)
        {
            w_state.Exit();
        }
        w_state = _state;
        w_state.Enter(this);
    }
}
