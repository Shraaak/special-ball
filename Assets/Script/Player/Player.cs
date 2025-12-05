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

    public CameraControl cameraControl;

    [Header("小球基础设置")]
    [Tooltip("小球hp")]
    public float hp = 1;
    [Tooltip("小球默认重力")]
    public float defaultGravityScale = 1;
    [Tooltip("ready状态左右移动的速度")]
    public float readySpeed;
    [Tooltip("掉血时间间隔")]
    [SerializeField] private float  interval = 1f;
    [Tooltip("每秒掉血")]
    public float damgeFollow = 0.04f;

    [Header("重生设置")]
    [Tooltip("重生点")]
    public Transform reSpwanPos;
    [Tooltip("重生时间")]
    public float reSpwanTime = 2f;

    [Header("冻结设置")]
    [Tooltip("冻结时间")]
    public float frozenDuration = 2f;
    [Tooltip("冻结伤害")]
    public float frozenDamage = 0.08f;

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

    public IEnumerator LoseHpOverTime()
    {
        while (true)
        {
            hp -= damgeFollow;  
            print("扣血"); 
            if (hp <= 0)
            {
                hp = 0;
                stateMachine.ChangeState(dieState);
                yield break; 
            }

            yield return new WaitForSeconds(interval); // 每固定时间一次
        }
    }

}
