using UnityEngine;
public class PlayerIdleState : PlayerState
{
    public PlayerIdleState(Player player, PlayerStateMechine stateMechine, string animBoolName):base(player, stateMechine, animBoolName){}

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
