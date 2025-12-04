using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpUIControl : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private Player player;

    private float maxHp;

    void Start()
    {
        slider.value = 1;
        maxHp = player.hp;
    }

    void Update()
    {
        slider.value = player.hp/maxHp;
    }


}
