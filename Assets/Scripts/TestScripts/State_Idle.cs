using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State_Idle : StateBase
{
    
    public override void Enter(StateController controller)
    {
        controller.agent.destination = controller.transforms[5].position;

        
    }
    public override void Excute(StateController controller)
    {
        controller.Change_State(new State_bed());
    }
    public override void Exit()
    {
        
    }
}
