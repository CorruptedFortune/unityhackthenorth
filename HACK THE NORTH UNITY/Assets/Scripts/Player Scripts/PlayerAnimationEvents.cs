using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationEvents : MonoBehaviour
{
    PlayerStateManager stateMan;
    private void Start()
    {
        stateMan = GetComponent<PlayerStateManager>();
    }
    public void Jump()
    {
        stateMan.desiredJump = true;
    }
}
