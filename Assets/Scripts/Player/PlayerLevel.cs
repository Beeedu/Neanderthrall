using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLevel : MonoBehaviour
{
    const float ExpGain = 1;

    private float experience = 0f;

    private int level = 1;

    // Update is called once per frame
    void Update()
    {
        int breakpoint = CalculateNextLevelBreakpoint(this.level);
        if (this.experience >= breakpoint)
        {
            this.level++;
            experience = 0f;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Exp"))
        {
            this.experience += ExpGain;
        }
    }

    private int CalculateNextLevelBreakpoint(int level)
    {
        // F(x) = 4(x - 1)^2 + 10
        // 10, 14, 26, 46, 74, ...
        return 4 * Mathf.RoundToInt(Mathf.Pow(level - 1, 2)) + 10;
    }

    public int GetPlayerLevel()
    {
        return this.level;
    }

    public float GetPlayerExp()
    {
        return this.experience;
    }

    public float GetPlayerExpBreakpoint()
    {
        return CalculateNextLevelBreakpoint(this.level);
    }
}
