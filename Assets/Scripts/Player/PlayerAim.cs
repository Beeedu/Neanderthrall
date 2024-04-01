using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameManager;

public class PlayerAim
{
    private float aimRange = 10f;

    private Vector3 lastUsedAimDirection = new Vector3(1, 0);

    public PlayerAim() { }

    public Vector3 DetermineAimDirection(AimMode mode)
    {
        GameObject player = GameManager.instance.GetPlayer();
        Vector3 playerPosition = player.transform.position;

        var aimDirection = mode switch
        {
            AimMode.Manual => CalculateManualAimDirection(playerPosition),
            AimMode.Auto => CalculateAutoAimDirection(playerPosition),
            _ => CalculateManualAimDirection(playerPosition),
        };

        return aimDirection;
    }

    private Vector3 CalculateManualAimDirection(Vector3 origin)
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector3 aimDirection = (new Vector3(mousePosition.x, mousePosition.y) - origin).normalized;

        this.lastUsedAimDirection = aimDirection;

        return aimDirection;
    }

    private Vector3 CalculateAutoAimDirection(Vector3 origin)
    {
        Transform target = FindClosestTargetInRange(origin, this.aimRange);

        if (target == null)
        {
            return this.lastUsedAimDirection;
        }

        Vector3 aimDirection = (new Vector3(target.position.x, target.position.y) - origin).normalized;

        this.lastUsedAimDirection = aimDirection;

        return aimDirection;
    }

    private Transform FindClosestTargetInRange(Vector3 origin, float range)
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(origin, range);

        Transform target = null;
        float minDistanceSquared = Mathf.Infinity;

        foreach (Collider2D hit in hits)
        {
            if (!hit.transform.CompareTag("Enemy"))
            {
                continue;
            }

            Vector3 directionToHit = hit.transform.position - origin;
            float distanceSquaredToHit = directionToHit.sqrMagnitude;

            if (distanceSquaredToHit < minDistanceSquared)
            {
                minDistanceSquared = distanceSquaredToHit;
                target = hit.transform;
            }
        }

        return target;
    }
}
