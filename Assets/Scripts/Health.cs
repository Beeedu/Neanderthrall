using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField]
    private float maxHealth;

    private float currentHealth;

    private void Start()
    {
        this.currentHealth = this.maxHealth;
    }

    public float MaxHealth
    {
        get => this.maxHealth;
        set => this.maxHealth = value;
    }

    public float CurrentHealth
    {
        get => this.currentHealth;
        set => this.currentHealth = value;
    }

    public float ChangeHealth(float amount)
    {
        this.currentHealth += amount;
        return this.currentHealth;
    }

    void Update()
    {
        if (this.CurrentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}