using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExperienceOrb : MonoBehaviour
{
    private GameObject player;

    private Rigidbody2D orbRigidbody;

    private float lifetime = 0f;

    private void Awake()
    {
        this.orbRigidbody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        this.player = GameManager.instance.GetPlayer();
    }

    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        this.lifetime += Time.deltaTime;
        Vector3 toPLayer = Util.FindDistanceToObject(this.gameObject, this.player);
        this.orbRigidbody.velocity = this.lifetime * 20 * toPLayer.normalized;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(this.gameObject);
        }
    }
}
