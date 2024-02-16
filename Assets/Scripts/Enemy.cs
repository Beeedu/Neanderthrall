using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IHealth
{
    [SerializeField]
    private float speed = 1.5f;

    private Rigidbody2D enemyRigidbody;

    [SerializeField]
    private int maxHealth = 100;

    private int _instanceId;

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

    private void Awake()
    {
        this.enemyRigidbody = GetComponent<Rigidbody2D>();
        this._instanceId = transform.gameObject.GetInstanceID();
    }

    // Start is called before the first frame update
    void Start()
    {
        this.health = new Health(this.maxHealth);
        EventManager.instance.EnemyHit += HandleEnemyHit;
    }

    void Update()
    {
        if (this.health.CurrentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        Player player = GameManager.instance.GetPlayer();
        Vector3 toPLayer = FindDirectionToPlayer(player.gameObject, this.gameObject);
        this.enemyRigidbody.velocity = this.speed * toPLayer;
    }

    private Vector3 FindDirectionToPlayer(GameObject player, GameObject enemy)
    {
        Vector3 playerPosition = player.transform.position;
        Vector3 enemyPosition = enemy.transform.position;
        Vector3 toPlayer = new Vector2(playerPosition.x - enemyPosition.x, playerPosition.y - enemyPosition.y).normalized;
        return toPlayer;
    }

    private void HandleEnemyHit(int instanceId, Collider2D collision)
    {
        if (this._instanceId != instanceId)
        {
            return;
        }

        Projectile projectile = collision.gameObject.GetComponent<Projectile>();
        this.ChangeHealth(-projectile.GetDamage());

        SoundManager.instance.PlayImpactSound();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Projectile"))
        {
            EventManager.instance.OnEnemyHit(this._instanceId, collision);
        }
    }
}
