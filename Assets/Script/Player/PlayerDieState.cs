using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDieState :PlayerState
{
    public PlayerDieState(Player player, PlayerStateMechine stateMechine, string animBoolName):base(player, stateMechine, animBoolName){}

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
    }

}
