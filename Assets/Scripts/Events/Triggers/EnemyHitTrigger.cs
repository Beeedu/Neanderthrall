using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitTrigger : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Attack") && collision.TryGetComponent(out Attack attack))
        {
            EventManager.instance.OnEnemyHit(attack.GetAttackerID(), this.transform.gameObject.GetInstanceID(), collision);
        }

        if (collision.gameObject.CompareTag("Ability") && collision.TryGetComponent(out Ability ability))
        {
            EventManager.instance.OnEnemyHit(ability.GetAttackerID(), this.transform.gameObject.GetInstanceID(), collision);
        }
    }
}