using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
    private float manaGain;

    private void GainMana()
    {

    }

    private float GetAttackDamage()
    {
        return 0;
    }

    private float GetAbilityDamage()
    {
        return 0;
    }
}

public class Attack : MonoBehaviour, IDealDamage
{
    [SerializeField]
    float attackDuration = 0.1f;

    private Vector3 direction;
    private float damage;

    public void Setup(Vector3 direction, float damage)
    {
        this.direction = direction;
        this.transform.eulerAngles = new Vector3(0, 0, Util.GetAngleFromVector(this.direction));
        this.damage = damage;

        Destroy(gameObject, attackDuration);
    }

    public float GetDamage()
    {
        return this.damage;
    }
}
