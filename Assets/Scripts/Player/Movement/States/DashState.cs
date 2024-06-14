using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class DashState : IMovementState
{

    private float timeOfDashStart = 0f;
    private readonly Action onDash;
    private readonly Action onDashEnd;

    public DashState(Action onDash, Action onDashEnd)
    {
        this.onDash = onDash;
        this.onDashEnd = onDashEnd;
    }

    public IMovementState Transition(PlayerMovement playerMovement)
    {
        // Start dash
        if (timeOfDashStart == 0f && !IsDashing(playerMovement))
        {
            Debug.Log("Start dash");
            this.onDash();
            this.timeOfDashStart = Time.time;
            return playerMovement.dashState;
        }

        // End dash
        if (timeOfDashStart != 0f && !IsDashing(playerMovement))
        {
            Debug.Log("End dash");
            this.onDashEnd();
            this.timeOfDashStart = 0f;
            return playerMovement.moveState;
        }

        Debug.Log("Continue dash");
        return playerMovement.dashState;
    }
    public PlayerMovementState GetStateType()
    {
        return PlayerMovementState.dash;
    }

    private bool IsDashing(PlayerMovement playerMovement)
    {
        return Time.time <= this.timeOfDashStart + playerMovement.GetDashDuration();
    }

    private bool CanDash(PlayerMovement playerMovement)
    {
        return Time.time >= this.timeOfDashStart + playerMovement.GetDashCooldown();
    }
}
