using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerReadyState : PlayerState
{
    public PlayerReadyState(Player player, PlayerStateMechine stateMechine, string animBoolName):base(player, stateMechine, animBoolName){}
    int index = 0;
    public override void Enter()
    {
        base.Enter();

        player.RestoreMovement();
        player.transform.position = player.reSpwanPos.position;

        player.rb.gravityScale = 0;
        
    }
    public override void Exit()
    {
        base.Exit();
    }
    public override void Update()
    {
        base.Update();

        Transform target = player.dirPosition[index];

        if (Vector3.Distance(player.transform.position, target.position) < 0.01f)
        {
            index ++;

            if (index > 1)
            {
                index = 0;
            }
        }

        player.transform.position = Vector3.MoveTowards(
            player.transform.position,
            target.position,
            player.readySpeed * Time.deltaTime
        );

        if(Input.GetMouseButtonDown(0)) 
            stateMechine.ChangeState(player.fallState);
    }
}
