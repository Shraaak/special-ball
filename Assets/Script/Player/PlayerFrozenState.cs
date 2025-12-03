using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFrozenState : PlayerState
{
    float frozenDuration = 2f;

    float timer;
    public PlayerFrozenState(Player player, PlayerStateMechine stateMechine, string animBoolName)
        : base(player, stateMechine, animBoolName) { }

    public override void Enter()
    {
        base.Enter();
        timer = frozenDuration;

        player.rb.velocity = Vector2.zero;
        player.rb.gravityScale = 0;
    }

    public override void Exit()
    {
        base.Exit();
        player.rb.gravityScale = player.defaultGravityScale;
    }

    public override void Update()
    {
        base.Update();

        timer -= Time.deltaTime;

        //额外扣血

        if (timer <= 0)
        {
            player.stateMachine.ChangeState(player.fallState);
        }
    }
}
