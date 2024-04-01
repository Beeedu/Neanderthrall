using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour, IDealDamage
{
    [SerializeField]
    float attackDuration = 0.1f;

    private Vector3 direction;
    private float damage;
    private GameObject parent;

    public void Setup(Vector3 direction, float damage, GameObject parent)
    {
        this.direction = direction;
        this.transform.eulerAngles = new Vector3(0, 0, Util.GetAngleFromVector(this.direction));
        this.damage = damage;
        this.parent = parent;

        Destroy(this.gameObject, attackDuration);
    }

    private void FixedUpdate()
    {
        this.transform.position = this.parent.transform.position + this.direction;
    }

    public float GetDamage()
    {
        return this.damage;
    }

    public int GetAttackerID()
    {
        return this.parent.GetInstanceID();
    }
}
