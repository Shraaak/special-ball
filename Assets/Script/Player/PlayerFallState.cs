using UnityEngine;

public class PlayerFallState : PlayerState
{
    public PlayerFallState(Player player, PlayerStateMechine stateMechine, string animBoolName):base(player, stateMechine, animBoolName){}
    public override void Enter()
    {
        base.Enter();
        player.rb.gravityScale = 1;
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
