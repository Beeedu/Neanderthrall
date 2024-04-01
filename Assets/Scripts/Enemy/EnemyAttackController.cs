using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackController : MonoBehaviour
{
    [SerializeField]
    Attack prefabAttackHitbox;

    private float damage = 50f;

    private void Awake()
    {
        //ActionTimer.Create(Attack, 1f);
    }

    private void Attack()
    {
        GameObject player = GameManager.instance.GetPlayer();
        Vector3 direction = Util.FindDistanceToObject(this.gameObject, player).normalized;

        Transform attackHitbox = Instantiate(this.prefabAttackHitbox.transform, this.transform.position + (direction), Quaternion.identity);

        attackHitbox.GetComponent<Attack>().Setup(direction, damage, this.gameObject);
    }
}
