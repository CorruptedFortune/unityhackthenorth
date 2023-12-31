using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XMovement : MonoBehaviour
{
    public static float desiredVel;
    public static void CalcVel(PlayerStateManager state)
    {
        Vector2 vel = new Vector2(InputController.RetrieveMoveInput(), 0f) * state.maxVel;
        desiredVel = vel.x;
    }
    public static void Move(float accel, PlayerStateManager state)
    {
        Vector2 velocity1 = state.body.velocity;
        float acceleration1 = accel;
        float maxSpeedChange1 = acceleration1 * Time.deltaTime;
        velocity1.x = Mathf.MoveTowards(velocity1.x, desiredVel, maxSpeedChange1);
        state.body.velocity = new Vector2(velocity1.x, state.body.velocity.y);
    }
}
