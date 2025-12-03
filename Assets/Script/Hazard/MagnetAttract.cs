using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetAttract : Hazard
{
    [Header("磁吸参数")]
    [Tooltip("吸力大小")]
    [SerializeField] private float magnetAttractForce = 10f;
    [Tooltip("吸附速度")]
    [SerializeField] private float attachSpeed = 5f;

    [Header("磁吸器位置")]
    [SerializeField] private Transform magnetTransform;
    [Tooltip("距离磁吸器的最大距离")]
    [SerializeField] private float testDistance = 1;

    private bool isPlayerAttached = false;

    private Player currentPlayer;
    protected override void OnBallEnter(Player player)
    {
        // 记录进入的玩家
        currentPlayer = player;
    }

    protected override void OnTriggerStay2D(Collider2D other)
    {
        if (!isActive) return;
        print("吸");
        
        Player player = other.GetComponent<Player>();
        if (player != null && currentPlayer == null)
        {
            currentPlayer = player;
        }
        
        if (currentPlayer != null && isActive)
        {
            ApplyMagneticForce();
        }

        //检测距离磁吸器的距离
        if (Vector2.Distance(currentPlayer.transform.position, magnetTransform.position) < testDistance)
        {
            AttachPlayer();
        }

    }

    private float originalGravity;

    private void ApplyMagneticForce()
    {
        if (currentPlayer == null) return;

        // 记录初始重力
        if (originalGravity == 0)
            originalGravity = currentPlayer.rb.gravityScale;

        // 1. 降低重力
        currentPlayer.rb.gravityScale = 0.2f; // 可调：越小掉得越慢

        // 2. 让 y 速度不要太大
        if (currentPlayer.rb.velocity.y < -1f)
            currentPlayer.rb.velocity = new Vector2(currentPlayer.rb.velocity.x, -1f);

        // 3. 只吸 X
        Vector2 direction = magnetTransform.position - currentPlayer.transform.position;
        direction.y = 0;

        float distance = Mathf.Max(direction.magnitude, 0.1f);
        float forceMagnitude = magnetAttractForce / distance;

        Vector2 force = direction.normalized * forceMagnitude;
        currentPlayer.rb.AddForce(force, ForceMode2D.Force);
    }
    
    protected override void OnTriggerExit2D(Collider2D other)
    {
        Player player = other.GetComponent<Player>();

        if (player != null && player == currentPlayer && !isPlayerAttached)
        {
            // 没被吸住状态下才恢复
            player.rb.gravityScale = player.defaultGravityScale;
            currentPlayer = null;
        }
    }

    private void Update()
    {
        //如果player被吸住就平滑移动到磁吸器位置
        if (isPlayerAttached && currentPlayer != null)
        {
            currentPlayer.transform.position = Vector2.MoveTowards(
                currentPlayer.transform.position,
                magnetTransform.position,
                attachSpeed * Time.deltaTime
            );
        }
    }

    private void AttachPlayer()
    {
        if (isPlayerAttached) return;
        isPlayerAttached = true;

        // 暂停重力以及速度
        currentPlayer.rb.gravityScale = 0;
        currentPlayer.rb.velocity = Vector2.zero;
    }

    private void OnMouseDown()
    {
        ReleasePlayer();
    }

    private void ReleasePlayer()
    {
        if (currentPlayer == null) return;

        isPlayerAttached = false;

        // 恢复为 Dynamic
        currentPlayer.rb.bodyType = RigidbodyType2D.Dynamic;

        // 恢复重力
        currentPlayer.rb.gravityScale = currentPlayer.defaultGravityScale;
    }
    
}
