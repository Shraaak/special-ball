using System.Collections;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    [Header("跟随对象")]
    [SerializeField] private Transform lookAtPoint;

    [Header("相机先要降到的目标位置")]
    [SerializeField] private Transform midTarget;

    [Header("移动速度")]
    public float moveSpeed = 3f;

    [Header("跟随平滑速度")]
    public float followSmooth = 5f;

    [Header("跟随的最低Y位置")]
    public float minFollowY = -20f; 

    private float yOffset;
    private bool startFollow = false;
    private bool isPaused = false;

    private Vector3 initialPosition;   // 相机初始位置

    void Start()
    {
        yOffset = transform.position.y - lookAtPoint.position.y;
        initialPosition = transform.position;
    }

    void Update()
    {
        if (isPaused) return;

        if (!startFollow)
        {
            DropToMiddle();
        }
        else
        {
            FollowPlayer();
        }
    }

    
    void DropToMiddle()
    {
        float newY = Mathf.MoveTowards(transform.position.y, midTarget.position.y, moveSpeed * Time.deltaTime);
        transform.position = new Vector3(transform.position.x, newY, -10f);

        if (Mathf.Abs(transform.position.y - midTarget.position.y) < 0.05f)
        {
            startFollow = true;
        }
    }

    void FollowPlayer()
    {
        // 玩家掉得太深 → 相机不再继续下降
        if (transform.position.y < minFollowY)
            return;

        float targetY = lookAtPoint.position.y + yOffset;
        float smoothY = Mathf.Lerp(transform.position.y, targetY, followSmooth * Time.deltaTime);

        transform.position = new Vector3(transform.position.x, smoothY, -10f);
    }

    public void OnPlayerDie()
    {
        isPaused = true;
    }

    public void OnPlayerRespawn()
    {
        StartCoroutine(ResetCameraSmooth());
    }

    private IEnumerator ResetCameraSmooth()
    {
        Vector3 startPos = transform.position;
        Vector3 endPos = initialPosition;
        float t = 0;

        while (t < 1f)
        {
            t += Time.deltaTime * moveSpeed;
            transform.position = Vector3.Lerp(startPos, endPos, t);
            yield return null;
        }

        // 恢复完毕后重新进入 Drop 阶段
        isPaused = false;
        startFollow = false;
    }
}