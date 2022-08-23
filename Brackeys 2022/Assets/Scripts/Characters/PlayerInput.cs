using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [Header("READ ONLY: Do not edit")]
    public float MovementInput;
    public bool JumpInput;

    [Space]
    public bool WeaponPrimaryAction;
    public bool WeaponSecondaryAction;
    public int WeaponScrollInput;
    // public int WeaponSelectInput; // TODO

    /* TODO
    Attack
    secondary attack
    switch weapons
    */

    // ==================================================

    private void Update()
    {
        // TODO: use input system?
        GetMovementInput();
        GetWeaponInput();
    }

    private void GetMovementInput()
    {
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

    private void GetWeaponInput()
    {
        Vector2 delta = Input.mouseScrollDelta;
        if (delta.y > 0)
        {
            WeaponScrollInput = 1;
        }
        else if (delta.y < 0)
        {
            WeaponScrollInput = -1;
        }
        else
        {
            WeaponScrollInput = 0;
        }

        WeaponPrimaryAction = Input.GetMouseButtonDown(0);
        WeaponSecondaryAction = Input.GetMouseButtonDown(1);
    }

}
