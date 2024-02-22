using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitTrigger : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Attack"))
        {
            EventManager.instance.OnEnemyHit(this.transform.gameObject.GetInstanceID(), collision);
        }
    }
}