using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateManager : MonoBehaviour
{
    #region States
    [HideInInspector] public PlayerBaseState currentState;
    public IdleState IdleState = new IdleState();
    public WalkState WalkState = new WalkState();
    #endregion

    #region References
    [HideInInspector] public Rigidbody2D body;
    #endregion

    #region Movement
    public float accel;
    public float maxVel;
    #endregion
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        currentState = IdleState;

        currentState.EnterState(this);
    }
    public void SwitchState(PlayerBaseState state)
    {
        currentState = state;
        state.EnterState(this);
    }
}
