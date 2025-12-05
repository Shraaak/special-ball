using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerDieState : PlayerState
{

    public PlayerDieState(Player player, PlayerStateMechine stateMechine, string animBoolName)
        : base(player, stateMechine, animBoolName) { }

    public override void Enter()
    {
        base.Enter();
        player.StartCoroutine(player.Die());

        player.cameraControl.OnPlayerDie();
    }

    public override void Update()
    {
        base.Update();
        
    }

    public override void Exit()
    {
        base.Exit();
    }

    
}