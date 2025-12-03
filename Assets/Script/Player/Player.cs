using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Animator anim{ get; private set; }
    public Rigidbody2D rb{ get; private set; }

    public PlayerStateMechine stateMachine{get; private set;}

    public PlayerReadyState readyState{get; private set;}
    public PlayerFallState fallState{get; private set;}
    public PlayerDieState dieState{get; private set;}
    public PlayerFrozenState frozenState{get; private set;}

    public List<Transform> dirPosition;
    public float defaultGravityScale = 1;

    public float readySpeed; //ready状态左右移动的速度

    [Header("重生设置")]
    [Tooltip("重生点")]
    public Transform reSpwanPos;
    [Tooltip("重生时间")]
    public float reSpwanTime = 2f;

    void Awake()
    {
        stateMachine = new PlayerStateMechine();

        readyState = new PlayerReadyState(this, stateMachine, "Ready");
        fallState = new PlayerFallState(this, stateMachine, "Fall");
        dieState = new PlayerDieState(this, stateMachine, "Die");
        frozenState = new PlayerFrozenState(this, stateMachine, "Frozen");
    }

    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody2D>();

        stateMachine.Initialize(readyState);
    }

    void Update()
    {
        stateMachine.currentState.Update();
    }

    public IEnumerator Die()
    {
        //先停止运动
        StopAllMovement();

        yield return new WaitForSeconds(2f);

        //动画播放完之后消失
        DisVisual();

        yield return new WaitForSeconds(reSpwanTime);

        //复活变成ready状态
        stateMachine.ChangeState(readyState);
    }

    private void StopAllMovement()
    {
        rb.velocity = Vector2.zero;  
        rb.gravityScale = 0f;        

        // 禁用碰撞体，避免碰撞
        Collider2D col = GetComponent<Collider2D>();
        if (col != null)
            col.enabled = false;
    }

    public void RestoreMovement()
    {

        Collider2D col = GetComponent<Collider2D>();
        if (col != null)
            col.enabled = true;
        Visual();
    }

    private void DisVisual()
    {
        foreach (var sr in GetComponentsInChildren<SpriteRenderer>())
        {
            sr.enabled = false;
        }
    }

    private void Visual()
    {
        foreach (var sr in GetComponentsInChildren<SpriteRenderer>())
            sr.enabled = true;
    }


}
