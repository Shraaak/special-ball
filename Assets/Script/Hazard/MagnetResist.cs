using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetResist : Hazard
{
    [Header("磁阻参数")]
    [Tooltip("阻力大小")]
    [SerializeField] private float magnetResistForce = 10f;

    [Header("磁阻器位置")]
    [SerializeField] private Transform magnetTransform;
    private Player currentPlayer;

    protected override void OnBallEnter(Player player)
    {
        // 记录进入的玩家
        currentPlayer = player;
    }

    protected override void OnTriggerStay2D(Collider2D other)
    {
        if (!isActive) return;
        print("推");
        
        Player player = other.GetComponent<Player>();
        if (player != null && currentPlayer == null)
        {
            currentPlayer = player;
        }
        
        if (currentPlayer != null && isActive)
        {
            ApplyMagneticForce();
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
        float forceMagnitude = magnetResistForce / distance;

        Vector2 force = -direction.normalized * forceMagnitude;
        currentPlayer.rb.AddForce(force, ForceMode2D.Force);
    }
}
