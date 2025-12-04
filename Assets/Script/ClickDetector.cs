using UnityEngine;
public class ClickDetector : MonoBehaviour
{
    public LayerMask interactLayer;
    private bool set = true;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero, 0f, interactLayer);

            if (hit.collider != null)
            {
                Debug.Log("点到了：" + hit.collider.name);

                set = !set;

                MagnetAttract attract = hit.collider.GetComponentInParent<MagnetAttract>();
                MagnetResist resist = hit.collider.GetComponentInParent<MagnetResist>();

                if(attract) hit.collider.GetComponentInParent<MagnetAttract>().enabled = set;
                if(resist) hit.collider.GetComponentInParent<MagnetResist>().enabled = set;
            }
        }
    }
}