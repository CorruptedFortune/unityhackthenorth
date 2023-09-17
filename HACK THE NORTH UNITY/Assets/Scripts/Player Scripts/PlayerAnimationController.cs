using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    [HideInInspector] public static string currentAnimState;
    static Animator anim;
    private static Transform transform;
    private void Start()
    {
        anim = GetComponent<Animator>();
        transform = GetComponent<Transform>();
    }
    public static void ChangeAnimationState(string newState)
    {
        float dir = InputController.RetrieveMoveInput();
        // get direction
        if (dir != 0)
            transform.localScale = new Vector3(1 * dir, 1, 0);
        // stop same anim from playing
        if (currentAnimState == newState)
            return; // dont want to play anims cuz we dont have anims yet
        // play new anim
        anim.Play(newState);

        // reassign the current state
        currentAnimState = newState;
    }
}
