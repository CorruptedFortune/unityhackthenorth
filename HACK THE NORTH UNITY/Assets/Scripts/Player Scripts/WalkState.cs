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
        if (InputController.RetrieveJumpInput())
        {
            state.SwitchState(state.JumpState);
            return;
        }
        else if(InputController.RetrieveMoveInput() == 0)
        {
            XMovement.desiredVel = 0;
            XMovement.Move(state.accel, state);
            if (state.body.velocity.x == 0)
                state.SwitchState(state.IdleState);
        }
        else
        {
            XMovement.CalcVel(state);
            XMovement.Move(state.accel, state);
        }
    }
}
