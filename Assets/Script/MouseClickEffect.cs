using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems; // 注意要加这个

public class UIClickEffect : MonoBehaviour
{
    public static UIClickEffect Instance;
    public RectTransform clickEffectPrefab;
    public Canvas canvas;

    private void Awake()
    {
        Instance = this;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // 如果点在 UI 上就直接返回，不生成特效
            if (EventSystem.current.IsPointerOverGameObject())
                return;

            Vector2 pos;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(
                canvas.transform as RectTransform,
                Input.mousePosition,
                canvas.worldCamera,
                out pos
            );

            var fx = Instantiate(clickEffectPrefab, canvas.transform);
            fx.anchoredPosition = pos;

            Destroy(fx.gameObject, 0.5f);
        }
    }
}