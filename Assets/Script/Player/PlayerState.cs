using UnityEngine;
public class PlayerState
{
    protected PlayerStateMechine stateMechine;
    protected Player player;
    private string animBoolName;

    public PlayerState(Player player, PlayerStateMechine stateMechine, string animBoolName)
    {
        this.stateMechine = stateMechine;
        this.player = player;
        this.animBoolName = animBoolName;
    }

    public virtual void Enter()
    {
        player.anim.SetBool(animBoolName, true);
        Debug.Log("进入"+animBoolName+"状态");
    }

    public virtual void Update()
    {
        
    }

    public virtual void Exit()
    {
        player.anim.SetBool(animBoolName, false);
        Debug.Log("退出"+animBoolName+"状态");
    }
}
