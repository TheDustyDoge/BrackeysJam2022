using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerInput))]
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    private static PlayerController _instance;
    public static PlayerController Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<PlayerController>();
            }
            return _instance;
        }
    }

    public const int GROUND_LAYER = 6;

    // ==================================================

    public float playerSpeed = 1;
    public float jumpStrength = 5;

    // TODO: press and hold to jump higher?

    // ==================================================
    
    public PlayerInput Input { get; private set; }
    public Rigidbody2D Body { get; private set; }
    public PlayerInventory Inventory { get; private set; }

    public bool IsGrounded { get; private set; }

    // ==================================================

    private void Awake()
    {
        Input = GetComponent<PlayerInput>();
        Body = GetComponent<Rigidbody2D>();
        Inventory = GetComponentInChildren<PlayerInventory>();// TODO: spawn in prefab
    }

    // ==================================================

    private void Update()
    {
        MovePlayer();
        UpdateWeapons();
    }

    private void MovePlayer()
    {
        Vector2 vel = Body.velocity;

        float delta = Time.deltaTime;
        vel.x = Input.MovementInput * playerSpeed;

        if (Input.JumpInput && IsGrounded)
        {
            vel.y = jumpStrength;
            IsGrounded = false;
        }

        Body.velocity = vel;
    }

    private void UpdateWeapons()
    {
        if (Inventory.equippedWeapon.IsAttacking)
        {
            return;
        }

        if (Input.WeaponPrimaryAction)
        {
            Inventory.equippedWeapon.Attack();
        }

        if (Input.WeaponScrollInput == 1)
        {
            Inventory.NextWeapon();
        }
        else if (Input.WeaponScrollInput == -1)
        {
            Inventory.PreviousWeapon();
        }
    }

    // ==================================================

    private void OnTriggerEnter2D(Collider2D other)
    {
        // NOTE: cant tell which trigger on the player is colliding with something
        // Could be buggy if additional triggers are added to the player
        if (other.gameObject.layer == GROUND_LAYER)
        {
            IsGrounded = true;
        }
    }

}
