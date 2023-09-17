using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirState : PlayerBaseState
{
    public override void EnterState(PlayerStateManager state)
    {

    }

    public override void UpdateState(PlayerStateManager state)
    {
        if(state.body.velocity.y == 0)
        {
            Exit(state, state.IdleState);
            return;
        }

        if (InputController.RetrieveMoveInput() == 0)
        {
            XMovement.desiredVel = 0;
            XMovement.Move(state.accel, state);
        }
        else
        {
            XMovement.CalcVel(state);
            XMovement.Move(state.accel, state);
        }
        if (state.body.velocity.y > 0)
        {
            state.body.gravityScale = state.upwardMovementMultiplier;
        }
        else
        {
            state.body.gravityScale = state.downwardMovementMultiplier;
        }
    }
    public  void Exit(PlayerStateManager state, PlayerBaseState newState)
    {
        state.body.gravityScale = 1;
        state.SwitchState(newState);
    }
}
