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
    private float dashDuration = 0.5f;

    [SerializeField]
    private float dashDistance = 5f;

    [SerializeField]
    private float dashRecharge = 2f;

    private bool isDashing = false;
    private float timeSinceDash = 0f;

    private PlayerActions playerActions;
    private Rigidbody2D playerRigidbody;
    private Vector2 moveInput;

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
    }

    private void FixedUpdate()
    {
        if (this.isDashing)
        {
            this.timeSinceDash += Time.deltaTime;
        }

        if (this.timeSinceDash >= this.dashDuration)
        {
            EndDash();
        }

        this.moveInput = this.playerActions.PlayerMap.Movement.ReadValue<Vector2>();
        float dashInput = this.playerActions.PlayerMap.Dash.ReadValue<float>();

        if (!this.isDashing && dashInput > 0)
        {
            Debug.Log("Start  dash");
            Dash();
        }

        if (!this.isDashing)
        {
            Vector2 newVelocity = this.moveInput * this.speed;
            this.playerRigidbody.velocity = newVelocity;
        }
    }

    private void EndDash()
    {
        this.isDashing = false;
        this.timeSinceDash = 0f;
        Physics2D.IgnoreLayerCollision(6, 7, false);
    }

    private void Dash()
    {
        this.isDashing = true;
        this.timeSinceDash = 0f;
        this.playerRigidbody.velocity = this.moveInput * this.dashDistance / this.dashDuration;
        Physics2D.IgnoreLayerCollision(6, 7, true);
    }

    public Vector2 GetVelocity()
    {
        return this.playerRigidbody.velocity;
    }
}
