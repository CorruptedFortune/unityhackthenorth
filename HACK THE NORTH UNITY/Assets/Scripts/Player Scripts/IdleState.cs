using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : PlayerBaseState
{
    public override void EnterState(PlayerStateManager state)
    {
        PlayerAnimationController.ChangeAnimationState("Player_Idle");
    }

    public override void UpdateState(PlayerStateManager state)
    {
        if (InputController.RetrieveMoveInput() != 0)
            state.SwitchState(state.WalkState);
    }
}
