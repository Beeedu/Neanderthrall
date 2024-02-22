using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLevel : MonoBehaviour
{
    const float ExpGain = 1;

    private float experience = 0f;

    private int level = 1;

    private int[] levelExpBreakpoints = { 10, 15, 20, 30, 40, 60, 80, 120, 160, 240, 320 };

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int breakpoint = this.levelExpBreakpoints[level - 1];
        if (this.experience >= breakpoint)
        {
            this.level++;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Exp"))
        {
            this.experience += ExpGain;
        }
    }
}
