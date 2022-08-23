using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(PlayerInput))]
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
    
    public Rigidbody2D Body { get; private set; }
    public PlayerInput Input { get; private set; }

    public bool IsGrounded { get; private set; }

    // ==================================================

    private void Awake()
    {
        Body = GetComponent<Rigidbody2D>();
        Input = GetComponent<PlayerInput>();
    }

    // ==================================================

    private void Update()
    {
        MovePlayer();
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
