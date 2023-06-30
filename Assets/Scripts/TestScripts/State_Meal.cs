using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State_Meal : StateBase
{
    float time = 0f;
    public override void Enter(StateController controller)
    {
        controller.agent.destination = controller.transforms[2].position;

        Debug.Log("식당로 간다");
    }
    public override void Excute(StateController controller)
    {
        time += Time.deltaTime;
        if (time > 1f)
        {
            time = 0f;
            controller._stressPoint -= 3;
            controller._hungryPoint += 15;
            controller._moneyPoint -= 2;

            if(controller._hungryPoint >= 70 && controller._moneyPoint >= 1) { controller.Change_State(new State_Gym()); }
            else if (controller._stressPoint >= 70) { controller.Change_State(new State_bed()); }
            else if ( controller._moneyPoint >= 5) { controller.Change_State(new State_Home()); }
            else if (controller._moneyPoint < 1) { controller.Change_State(new State_Job()); }

        }
    }
    public override void Exit()
    {
        Debug.Log("식사 끝");
    }
}
