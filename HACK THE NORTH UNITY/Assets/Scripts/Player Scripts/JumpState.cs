using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpState : PlayerBaseState
{
    private Vector2 velocity;
    public WalkState WalkState = new WalkState();
    public override void EnterState(PlayerStateManager state)
    {
        state.body.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
        PlayerAnimationController.ChangeAnimationState("Player_Jump");
    }

    public override void UpdateState(PlayerStateManager state)
    {
        #region jumpStuff
        velocity = state.body.velocity;

        if (state.desiredJump)
        {
            state.desiredJump = false;
            state.jumpBufferCounter = state.jumpBufferTime;
        }

        if (state.jumpBufferCounter > 0)
        {
            JumpAction(state);
        }
        state.body.velocity = velocity;
        #endregion
    }
    public void JumpAction(PlayerStateManager state)
    {
        if (state.coyoteCounter > 0f || (state.jumpPhase < state.maxAirJumps && state.isJumping))
        {
            if (state.isJumping)
            {
                state.jumpPhase += 1;
            }

            state.jumpBufferCounter = 0f;
            state.coyoteCounter = 0f;
            state.jumpSpeed = Mathf.Sqrt(-2f * Physics2D.gravity.y * state.jumpHeight);
            state.isJumping = true;
            state.jumpSpeed = Mathf.Max(state.jumpSpeed - velocity.y, 0f);
            velocity.y += state.jumpSpeed;
            state.body.velocity = velocity;
            state.body.constraints = RigidbodyConstraints2D.FreezeRotation;
            state.SwitchState(state.AirState);
        }

    }
}
