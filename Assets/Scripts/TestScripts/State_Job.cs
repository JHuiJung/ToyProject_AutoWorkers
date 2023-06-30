using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State_Job : StateBase
{
    float time = 0f;
    public override void Enter(StateController controller)
    {
        controller.agent.destination = controller.transforms[3].position;

        Debug.Log("직장으로 간다");
    }
    public override void Excute(StateController controller)
    {
        time += Time.deltaTime;
        if (time > 1f)
        {
            time = 0f;
            controller._stressPoint += 5;
            controller._hungryPoint -= 3;
            controller._moneyPoint += (3 + controller._musclePoint);
            
            if(controller._moneyPoint >= 5 && controller._stressPoint <= 40) { controller.Change_State(new State_Home()); }
            else if (controller._stressPoint >= 70) { controller.Change_State(new State_bed()); }
            else if (controller._hungryPoint <= 20 && controller._moneyPoint >= 2) { controller.Change_State(new State_Meal()); }
            else if (controller._hungryPoint >= 25 && controller._moneyPoint >= 1) { controller.Change_State(new State_Gym()); }

            
        }
    }
    public override void Exit()
    {
        Debug.Log("업무 끝");
    }
}
