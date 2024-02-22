using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float speed = 3f;

    private PlayerActions playerActions;
    private Rigidbody2D playerRigidbody;
    private Vector2 moveInput;
    private Look look;

    private void OnEnable()
    {
        this.playerActions.PlayerMap.Enable();
    }

    private void OnDisable()
    {
        this.playerActions.PlayerMap.Disable();
    }

    private void Awake()
    {
        this.playerActions = new PlayerActions();

        this.playerRigidbody = GetComponent<Rigidbody2D>();

        this.look = new Look(this.playerRigidbody);
    }

    private void FixedUpdate()
    {
        this.moveInput = this.playerActions.PlayerMap.Movement.ReadValue<Vector2>();
        Vector2 newVelocity = this.moveInput * this.speed;
        this.playerRigidbody.velocity = newVelocity;
    }

    public Vector2 GetVelocity()
    {
        return this.playerRigidbody.velocity;
    }

    public Look GetLook()
    {
        return this.look;
    }
}
