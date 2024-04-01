using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField]
    private float speed = 1.5f;

    [SerializeField]
    private float attackRange = 10f;

    private Rigidbody2D enemyRigidbody;

    private void Awake()
    {
        this.enemyRigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        GameObject player = GameManager.instance.GetPlayer();
        Vector3 toPLayer = Util.FindDistanceToObject(this.gameObject, player);

        if (toPLayer.magnitude < attackRange)
        {
            this.enemyRigidbody.velocity = new Vector2();
            return;
        }

        this.enemyRigidbody.velocity = this.speed * toPLayer.normalized;
    }
}
