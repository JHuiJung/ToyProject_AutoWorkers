using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State_bed : StateBase
{
    float time = 0f;
    
    public override void Enter(StateController controller)
    {
        controller.agent.destination = controller.transforms[4].position;
     
        Debug.Log("침실로 간다");
    }
    public override void Excute(StateController controller)
    {
        time += Time.deltaTime;
        if (time > 1f)
        {
            time = 0f;
            controller._stressPoint -= 10;
            controller._hungryPoint -= 1;
            

            if(controller._stressPoint <= 20 && controller._moneyPoint >=5) { controller.Change_State(new State_Home()); }
            else if (controller._hungryPoint <= 20 && controller._moneyPoint >=2) { controller.Change_State(new State_Meal()); }
            else if (controller._moneyPoint < 2) { controller.Change_State(new State_Job()); }

        }
    }
    public override void Exit()
    {
        Debug.Log("취침 끝");
    }
}
