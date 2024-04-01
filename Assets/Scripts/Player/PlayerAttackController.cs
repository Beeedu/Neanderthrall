using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackController : MonoBehaviour
{
    [SerializeField]
    Attack prefabAttackHitbox;

    private float damage = 50f;

    private void Awake() {
        ActionTimer.Create(Attack, 1f);
    }

    private void Attack()
    {
        Vector3 direction = GameManager.instance.GetPlayerAim().DetermineAimDirection(GameManager.instance.GetAimMode());

        Transform attackHitbox = Instantiate(this.prefabAttackHitbox.transform, this.transform.position + (direction), Quaternion.identity);

        attackHitbox.GetComponent<Attack>().Setup(direction, damage, this.gameObject);
    }
}
