using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField]
    Transform prefabAttackHitbox;

    private float damage = 50f;

    private void Awake() {
        ActionTimer.Create(Attack, 1f);
    }

    private void Attack()
    {
        Vector3 direction = GameManager.instance.GetPlayerAim().DetermineAimDirection(GameManager.instance.GetAimMode());

        Transform attackHitbox = Instantiate(this.prefabAttackHitbox, this.transform.position + (direction), Quaternion.identity, this.transform.parent);

        attackHitbox.transform.parent = this.transform;

        attackHitbox.GetComponent<Attack>().Setup(direction, damage);
    }
}
