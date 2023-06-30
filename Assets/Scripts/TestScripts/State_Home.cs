using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State_Home : StateBase
{
    float time = 0f;

    public override void Enter(StateController controller)
    {
        controller.agent.destination = controller.transforms[0].position;
        Debug.Log("집으로 간다");
    }
    public override void Excute(StateController controller)
    {
        time += Time.deltaTime;
        if (time > 1f) 
        {
            
            time = 0f;
            controller._intPoint += 1;
            controller._stressPoint += 3;
            controller._hungryPoint -= 2;
            controller._moneyPoint -= 5;

            if (controller._moneyPoint <= 5) { controller.Change_State(new State_Job()); }
            else if (controller._stressPoint >= 70) { controller.Change_State(new State_bed()); }
            else if (controller._hungryPoint <= 70 && controller._moneyPoint >= 2) { controller.Change_State(new State_Meal()); }
            else if (controller._hungryPoint >= 70 && controller._moneyPoint >= 1) { controller.Change_State(new State_Gym()); }

            
        }
    }
    public override void Exit()
    {
        Debug.Log("공부 끝");
        
    }
}
