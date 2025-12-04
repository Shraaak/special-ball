using UnityEngine;

public class CameraControl : MonoBehaviour
{
    [Header("跟随对象")]
    [SerializeField] private Transform lookAtPoint;

    [Header("相机先要降到的目标位置")]
    [SerializeField] private Transform midTarget;

    [Header("下降速度")]
    public float dropSpeed = 3f;

    [Header("跟随平滑速度")]
    public float followSmooth = 5f;

    private float yOffset;
    private bool startFollow = false;

    void Start()
    {
        yOffset = transform.position.y - lookAtPoint.position.y;
    }

    void Update()
    {
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
        // 只移动y轴下落
        float newY = Mathf.MoveTowards(transform.position.y, midTarget.position.y, dropSpeed * Time.deltaTime);

        transform.position = new Vector3(transform.position.x, newY, transform.position.z);

        // 接近中间位置后开始跟随
        if (Mathf.Abs(transform.position.y - midTarget.position.y) < 0.05f)
        {
            startFollow = true;
        }
    }

    void FollowPlayer()
    {
        float targetY = lookAtPoint.position.y + yOffset;

        float smoothY = Mathf.Lerp(transform.position.y, targetY, followSmooth * Time.deltaTime);

        transform.position = new Vector3(transform.position.x, smoothY, transform.position.z);
    }
}