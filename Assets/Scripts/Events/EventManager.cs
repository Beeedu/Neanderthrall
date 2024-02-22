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

    public event Action<int, Collider2D> EnemyHit;

    // TODO: This assumes only one entity is using this event...
    public event Action AttackFirstHit;

    public void OnEnemyHit(int enemyId, Collider2D collision)
    {
        EnemyHit?.Invoke(enemyId, collision);
    }

    public void OnAttackFirstHit()
    {
        AttackFirstHit?.Invoke();
    }
}
