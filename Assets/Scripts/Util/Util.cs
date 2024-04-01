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

    public static Vector3 FindDistanceToObject(GameObject origin, GameObject other)
    {
        Vector3 originPosition = origin.transform.position;
        Vector3 otherPosition = other.transform.position;
        Vector3 toOther = new Vector2(otherPosition.x - originPosition.x, otherPosition.y - originPosition.y);
        return toOther;
    }
}
