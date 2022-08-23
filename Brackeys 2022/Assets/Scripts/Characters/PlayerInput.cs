using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public float MovementInput { get; private set; }
    public bool JumpInput { get; private set; }

    // ==================================================

    private void Update()
    {
        // TODO: use input system?
        
        MovementInput = 0;
        if (Input.GetKey(KeyCode.A))
        {
            MovementInput -= 1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            MovementInput += 1;
        }
        
        JumpInput = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.Space);
    }
}
