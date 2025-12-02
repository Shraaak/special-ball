using UnityEngine;
public class PlayerState
{
    protected PlayerStateMechine stateMechine;
    protected Player player;
    private string animBoolName;
    protected float xInput;
    protected float yInput;

    public PlayerState(Player player, PlayerStateMechine stateMechine, string animBoolName)
    {
        this.stateMechine = stateMechine;
        this.player = player;
        this.animBoolName = animBoolName;
    }

    public virtual void Enter()
    {
        player.anim.SetBool(animBoolName, true);
    }

    public virtual void Update()
    {
        xInput = Input.GetAxisRaw("Horizontal");
        yInput = Input.GetAxisRaw("Vertical");
    }

    public virtual void Exit()
    {
        player.anim.SetBool(animBoolName, false);
    }
}
