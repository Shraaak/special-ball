using UnityEngine;

public class Portal : MonoBehaviour
{
    [Header("出口传送门")]
    public Transform exitPortal;

    [Header("出口方向 (empty 物体的 right 朝向决定左右)")]
    public Transform exitDirectionRef;

    [Header("传送后水平速度设置")]
    public bool keepInputSpeed = true;   // 保留原先水平速度
    public float fixedSpeed = 5f;        // 如果不保留则使用固定值

    [Header("传送逻辑设置")]
    public float ignoreDuration = 0.15f;
    public Vector2 offsetAfterTeleport = Vector2.zero;

    private void OnTriggerEnter2D(Collider2D col)
    {
        Player player = col.GetComponent<Player>();
        if (player == null)
            return;

        if (!player.CanTeleport())
            return;

        Rigidbody2D rb = player.rb;
        if (rb == null)
            return;

        // 保留 Y 速度
        float vY = rb.velocity.y;

        // 生成新的 X 速度
        float vX;

        if (keepInputSpeed)
            vX = Mathf.Abs(rb.velocity.x);
        else
            vX = Mathf.Abs(fixedSpeed);

        // 根据出口方向决定左右
        float dirX = Mathf.Sign(exitDirectionRef.right.x);
        vX *= dirX;

        // 设置位置
        rb.position = (Vector2)exitPortal.position + offsetAfterTeleport;

        // 重设速度
        rb.velocity = new Vector2(vX, vY);

        // 设置短暂忽略，防止回环
        player.SetPortalIgnore(ignoreDuration);
    }
}