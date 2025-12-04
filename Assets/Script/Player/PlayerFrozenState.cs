using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFrozenState : PlayerState
{
    float defaultDamage;
    float timer;
    public PlayerFrozenState(Player player, PlayerStateMechine stateMechine, string animBoolName)
        : base(player, stateMechine, animBoolName) { }

    public override void Enter()
    {
        base.Enter();

        defaultDamage = player.damgeFollow;

        timer = player.frozenDuration;

        player.rb.velocity = Vector2.zero;

        player.rb.gravityScale = 0;

        //冻结时的额外扣血
        player.damgeFollow = player.frozenDamage;
        player.StartCoroutine(player.LoseHpOverTime());
    }

    public override void Exit()
    {
        base.Exit();
        player.rb.gravityScale = player.defaultGravityScale;

        //退出状态时扣血恢复正常
        player.damgeFollow = defaultDamage;
    }

    public override void Update()
    {
        base.Update();

        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            player.stateMachine.ChangeState(player.fallState);
        }
    }
}
