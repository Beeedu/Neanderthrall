using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public enum PlayerMovementState
{
    move,
    dash
}

public interface IMovementState
{
    public IMovementState Transition(PlayerMovement playerMovement);

    public PlayerMovementState GetStateType();
}
