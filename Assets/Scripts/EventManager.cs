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

    public void OnEnemyHit(int instanceId, Collider2D collision)
    {
        EnemyHit?.Invoke(instanceId, collision);
    }
}
