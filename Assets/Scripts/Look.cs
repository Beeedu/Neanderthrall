using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Look
{
    private readonly Rigidbody2D rigidbody;
    private Vector2 direction = new Vector2(1, 0);

    public Look(Rigidbody2D rigidbody)
    {
        this.rigidbody = rigidbody;
    }

    private Vector2 UpdateDirection()
    {
        if (IsMoving(this.rigidbody.velocity))
        {
           this.direction = this.rigidbody.velocity.normalized;
        }
        return this.direction;
    }

    private bool IsMoving(Vector2 velocity)
    {
        return velocity.x != 0 || velocity.y != 0;
    }

    public Vector2 GetDirection()
    {
        return UpdateDirection();
    }
}
