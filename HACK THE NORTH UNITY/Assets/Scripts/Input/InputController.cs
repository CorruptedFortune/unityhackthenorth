using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class InputController
{
    public static float RetrieveMoveInput()
    {
        return Input.GetAxisRaw("Horizontal");
    }
}
