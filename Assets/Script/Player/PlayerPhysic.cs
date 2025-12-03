using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPhysic : MonoBehaviour
{
    [Header("物理参数")]
    [Tooltip("重力")]
    [SerializeField] private float gravity = 9.18f;
    [Tooltip("反弹系数")]
    [SerializeField] private float bounce = 0.8f;
    [Tooltip("小球半径")]
    [SerializeField] private float radius = 0.3f;
    Vector2 velocity;
    void Start()
    {
        
    }

    void Update()
    {
        //更新位置
        velocity.y -= gravity * Time.deltaTime;
        transform.position += (Vector3)(velocity * Time.deltaTime);

        //碰到墙壁反弹
        WallBounce();
    }

    void WallBounce()
    {
        float dt = Time.deltaTime;

        // 最多解析 3 次碰撞（足够解决大部分角落问题）
        for (int i = 0; i < 3; i++)
        {
            Vector2 pos = transform.position;
            float distance = velocity.magnitude * dt;

            // 如果速度太小，没必要检测
            if (distance < 0.0001f)
                break;

            // 做 CircleCast 检测下一帧是否会撞地形
            RaycastHit2D hit = Physics2D.CircleCast(pos, radius, velocity.normalized, distance);

            // 没撞到，直接退出（这帧不需要反弹）
            if (!hit)
                break;

            // ① 将小球推到贴墙点（避免穿墙）
            Vector2 correctedPos = hit.point + hit.normal * radius;
            transform.position = correctedPos;

            // ② 计算反射后的速度（真实反弹）
            velocity = Vector2.Reflect(velocity, hit.normal) * bounce;

            // ③ ★ 在反射方向继续移动剩余距离（关键）
            float remainingDistance = distance - hit.distance;
            transform.position += (Vector3)(velocity.normalized * remainingDistance * 0.99f);
        }
    }
}
