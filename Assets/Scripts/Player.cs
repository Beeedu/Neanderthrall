using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IHealth
{
    [SerializeField]
    private float speed = 3f;

    [SerializeField]
    private int maxHealth = 100;

    private PlayerActions playerActions;
    private Rigidbody2D playerRigidbody;
    private Vector2 moveInput;
    private Look look;

    private Health health;
    public float MaxHealth
    { 
        get => this.health.MaxHealth;
        set => this.health.MaxHealth = value;
    }
    public float CurrentHealth
    {
        get => this.health.CurrentHealth;
        set => this.health.CurrentHealth = value;
    }
    public float ChangeHealth(float amount)
    {
        return this.health.ChangeHealth(amount);
    }

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

    // Start is called before the first frame update
    void Start()
    {
        this.health = new Health(this.maxHealth);
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
