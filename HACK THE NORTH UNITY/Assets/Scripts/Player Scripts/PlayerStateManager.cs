using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateManager : MonoBehaviour
{
    #region States
    [HideInInspector] public PlayerBaseState currentState;
    public IdleState IdleState = new IdleState();
    public WalkState WalkState = new WalkState();
    public JumpState JumpState = new JumpState();
    public AirState AirState = new AirState();
    #endregion

    #region References
    [HideInInspector] public Rigidbody2D body;
    #endregion

    #region Movement
    public float accel;
    public float maxVel;
    #endregion

    #region Jump
    [Header("Jump Settings")]
    public float jumpHeight = 3f;
    [Range(0, 5)] public int maxAirJumps = 0;
    [Range(0f, 5f)] public float downwardMovementMultiplier = 3f;
    [Range(0f, 5f)] public float upwardMovementMultiplier = 1.7f;
    [Range(0f, 0.3f)] public float coyoteTime = 0.2f;
    [Range(0f, 0.3f)] public float jumpBufferTime = 0.2f;
    public float defaultGravityScale;

    [HideInInspector] public int jumpPhase;
    [HideInInspector] public float jumpSpeed, coyoteCounter, jumpBufferCounter;

    [HideInInspector] public bool desiredJump, isJumping;
    #endregion
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        currentState = IdleState;

        currentState.EnterState(this);
    }
    private void Update()
    {
        Debug.Log(desiredJump);
        currentState.UpdateState(this);
        float dir = InputController.RetrieveMoveInput();
        // get direction
        if (dir != 0)
            transform.localScale = new Vector3(1 * dir, 1, 0);
        if (body.velocity.y == 0)
        {
            jumpPhase = 0;
            coyoteCounter = coyoteTime;
            isJumping = false;
        }
        else
        {
            coyoteCounter -= Time.deltaTime;
        }
    }
    public void SwitchState(PlayerBaseState state)
    {
        currentState = state;
        state.EnterState(this);
    }
}
