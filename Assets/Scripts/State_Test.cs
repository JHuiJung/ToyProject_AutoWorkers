using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State_Test : Worker_StateBase
{
    float time = 0f;
    float n_time = 0f;
    public override void Enter(WorkerController wc)
    {
       
    }

    public override void Excute(WorkerController wc)
    {
        time += Time.deltaTime;
        if(time >= 1f)
        {
            time = 0f;
            n_time += 1f;
            wc.bag.AddRs(1);
            Debug.Log(wc.bag.RsAmount);
            if(n_time >= 8f)
            {
                wc.Change_State(new State_Test());
            }
        }
    }

    public override void Exit(WorkerController wc)
    {
        
    }
    ~State_Test()
    {
        Debug.Log("¼Ò¸êµÇ¾ú¾û");
    }

}
