using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : IHealth
{
    [SerializeField]
    float maxHealth;

    [SerializeField]
    float currentHealth;

    public Health(float maxHealth)
    {
        this.maxHealth = maxHealth;
        this.currentHealth = maxHealth;
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
}

public interface IHealth
{
    float MaxHealth
    {
        get;
        set;
    }

    float CurrentHealth
    {
        get;
        set;
    }

    public float ChangeHealth(float amount);
}