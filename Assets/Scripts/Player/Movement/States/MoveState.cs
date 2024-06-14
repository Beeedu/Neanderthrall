using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class MoveState : IMovementState
{

    private readonly Action move;

    public MoveState(Action move)
    {
        this.move = move;
    }

    public IMovementState Transition(PlayerMovement playerMovement)
    {
        this.move();

        if (this.ShouldDash(playerMovement))
        {
            return playerMovement.dashState;
        }

        return playerMovement.moveState;
    }

    public PlayerMovementState GetStateType()
    {
        return PlayerMovementState.move;
    }

    private bool ShouldDash(PlayerMovement playerMovement)
    {
        return playerMovement.ReadDashInput() > 0;
    }
}
