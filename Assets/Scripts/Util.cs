using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Util
{
    public static float GetAngleFromVector(Vector3 direction)
    {
        direction = direction.normalized;
        float n = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        if (n < 0)
        {
            n += 360;
        }
        return n;
    }
}
