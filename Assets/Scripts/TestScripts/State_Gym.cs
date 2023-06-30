using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State_Gym : StateBase
{
    float time = 0f;
    public override void Enter(StateController controller)
    {
        controller.agent.destination = controller.transforms[1].position;

        Debug.Log("체육관으로 간다");
    }
    public override void Excute(StateController controller)
    {
        time += Time.deltaTime;
        if (time > 1f)
        {
            
            time = 0f;
            controller._stressPoint += 1;
            controller._hungryPoint -= 4;
            controller._moneyPoint -= 1;
            controller._musclePoint += 1;

            if (controller._hungryPoint <= 20 && controller._moneyPoint >= 2) { controller.Change_State(new State_Meal()); }
            else if (controller._stressPoint >= 70) { controller.Change_State(new State_bed()); }
            else if (controller._stressPoint <= 40 &&controller._moneyPoint >= 5) { controller.Change_State(new State_Home()); }
            else if (controller._moneyPoint < 1) { controller.Change_State(new State_Job()); }

        }
    }
    public override void Exit()
    {
        Debug.Log("운동 끝");
        
        
    }
}
