using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float speed = 3f;

    [SerializeField]
    private int dashCharges = 2;

    [SerializeField]
    private float dashCooldown = 1f;

    [SerializeField]
    private float dashDuration = 0.25f;

    [SerializeField]
    private float dashDistance = 4f;

    [SerializeField]
    private float dashRecharge = 2f;

    public DashState dashState;
    public MoveState moveState;
    private IMovementState currentState;

    private PlayerActions playerActions;
    private Rigidbody2D playerRigidbody;

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

        dashState = new DashState(OnDash, OnDashEnd);
        moveState = new MoveState(OnMove);
        this.currentState = this.moveState;
    }

    private void FixedUpdate()
    {
        this.currentState = this.currentState.Transition(this);
    }

    private void OnMove()
    {
        Vector2 moveInput = ReadMoveInput();
        Vector2 newVelocity = moveInput * GetSpeed();
        this.playerRigidbody.velocity = newVelocity;
    }

    private void OnDash()
    {
        this.playerRigidbody.velocity = ReadMoveInput() * this.dashDistance / this.dashDuration;
        Physics2D.IgnoreLayerCollision(6, 7, true); // IFrames
    }
    private void OnDashEnd()
    {
        Physics2D.IgnoreLayerCollision(6, 7, false); // IFrames
    }

    public float GetDashCooldown()
    {
        return this.dashCooldown;
    }
    public float GetDashDuration()
    {
        return this.dashDuration;
    }

    public float GetSpeed()
    {
        return this.speed;
    }

    public Vector2 GetVelocity()
    {
        return this.playerRigidbody.velocity;
    }

    public float ReadDashInput()
    {
        return this.playerActions.PlayerMap.Dash.ReadValue<float>();
    }

    private Vector2 ReadMoveInput()
    {
        return this.playerActions.PlayerMap.Movement.ReadValue<Vector2>();
    }
}