using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField]
    private float speed = 15f;

    //[SerializeField]
    //private int piercing = 5;

    //private int piercedCount = 0;

    private float damage = 100f;
    private float range = 20f;

    private Vector3 direction;
    private Vector3 startPosition;

    public void Setup(Vector3 direction)
    {
        this.direction = direction;
        this.transform.eulerAngles = new Vector3(0, 0, Util.GetAngleFromVector(this.direction));
        this.startPosition = transform.position;
    }

    void Update()
    {
        float deltaPosition = (this.transform.position - this.startPosition).magnitude;
        if (deltaPosition > range)
        {
            Destroy(gameObject);
        }

        this.transform.position += Time.deltaTime * this.speed * this.direction;
    }

    //void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Enemy"))
    //    {
    //        piercedCount++;
    //    }

    //    if (piercedCount > piercing)
    //    {
    //        Destroy(gameObject);
    //    }
    //}

    public float GetDamage()
    {
        return this.damage;
    }
}
