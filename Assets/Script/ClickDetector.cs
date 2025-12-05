using UnityEngine;

public class ClickDetector : MonoBehaviour
{
    public LayerMask interactLayer;

    // 全局统一开关
    private bool toggle = true;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            // 比 Raycast 更适合“点击检测”
            Collider2D col = Physics2D.OverlapPoint(mousePos, interactLayer);

            if (col != null)
            {
                Debug.Log("点到了：" + col.name);

                toggle = !toggle;

                // 任意磁铁脚本都算“目标”
                var attract = col.GetComponentInParent<MagnetAttract>();
                var resist = col.GetComponentInParent<MagnetResist>();


                if (attract != null) 
                {
                    attract.GetComponentInParent<BoxCollider2D>().enabled = toggle;
                    attract.ReleasePlayer();
                }
                if (resist != null) 
                {
                    resist.GetComponentInParent<BoxCollider2D>().enabled = toggle;
                }
                
            }
        }
    }
}