using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static EventManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    public event Action<int, int, Collider2D> EnemyHit;

    // TODO: This assumes only one entity is using this event
    public event Action<int> AttackFirstHit;

    public void OnEnemyHit(int attackerId, int enemyId, Collider2D collision)
    {
        EnemyHit?.Invoke(attackerId, enemyId, collision);
    }

    public void OnAttackFirstHit(int attackerId)
    {
        AttackFirstHit?.Invoke(attackerId);
    }
}
