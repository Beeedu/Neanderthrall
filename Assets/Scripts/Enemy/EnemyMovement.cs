using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField]
    private float speed = 1.5f;

    private Rigidbody2D enemyRigidbody;

    private void Awake()
    {
        this.enemyRigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        GameObject player = GameManager.instance.GetPlayer();
        Vector3 toPLayer = FindDirectionToObject(player);
        this.enemyRigidbody.velocity = this.speed * toPLayer;
    }

    private Vector3 FindDirectionToObject(GameObject other)
    {
        Vector3 thisPosition = this.transform.position;
        Vector3 otherPosition = other.transform.position;
        Vector3 toOther = new Vector2(otherPosition.x - thisPosition.x, otherPosition.y - thisPosition.y).normalized;
        return toOther;
    }
}
