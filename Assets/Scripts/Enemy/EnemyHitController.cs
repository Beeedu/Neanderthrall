using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitController : MonoBehaviour
{
    private Health health;

    void Start()
    {
        this.health = GetComponent<Health>();
        EventManager.instance.EnemyHit += HandleEnemyHit;
    }

    private void OnDestroy()
    {
        EventManager.instance.EnemyHit -= HandleEnemyHit;
    }

    private void HandleEnemyHit(int enemyId, Collider2D collision)
    {
        if (this.transform.gameObject.GetInstanceID() != enemyId)
        {
            return;
        }

        if (this.health == null)
        {
            Debug.LogError("No Health Component on GameObject");
            return;
        }

        if (collision.TryGetComponent(out Projectile projectile))
        {
            this.health.ChangeHealth(-projectile.GetDamage());
        }

        if (collision.TryGetComponent(out Attack attack))
        {
            this.health.ChangeHealth(-attack.GetDamage());
        }

        SoundManager.instance.PlayImpactSound();
    }
}
