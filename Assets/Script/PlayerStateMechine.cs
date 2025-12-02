using UnityEngine;
public class PlayerStateMechine 
{
    public PlayerState currentState{get; private set;}
    public void Initialize(PlayerState startState)
    {
        currentState = startState;
        currentState.Enter();
    }

    public void ChangeState(PlayerState newState)
    {
        currentState.Exit();
        currentState = newState;
        currentState.Enter();
    }
}
