using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstAttackHitTrigger : MonoBehaviour
{
    private bool hasHit = false;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (!hasHit && collision.gameObject.CompareTag("Enemy") && TryGetComponent(out Attack attack))
        {
            EventManager.instance.OnAttackFirstHit(attack.GetAttackerID());
            hasHit = true;
        }
    }
}