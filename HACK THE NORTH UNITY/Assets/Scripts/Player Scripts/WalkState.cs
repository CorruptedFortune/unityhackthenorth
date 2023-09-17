using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkState : PlayerBaseState
{
    public override void EnterState(PlayerStateManager state)
    {
        PlayerAnimationController.ChangeAnimationState("Player_Idle");
    }

    public override void UpdateState(PlayerStateManager state)
    {
        if(InputController.RetrieveMoveInput() == 0)
        {
            XMovement.Move(state.accel, 0, state);
            if (state.body.velocity.x == 0)
                state.SwitchState(state.IdleState);
        }
        else
            XMovement.Move(state.accel, state.maxVel, state);
    }
}
