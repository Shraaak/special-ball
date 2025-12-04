using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealCrystal : MonoBehaviour
{
    [Header("基础设置")]
    [Tooltip("增加血量值")]
    [SerializeField] private float heal = 0.1f;
    [Tooltip("旋转速度")]
    [SerializeField] private float rotateSpeed = 20f;

    void Start()
    {
        Enable();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();

        if(!player) return;
        
        player.hp += 0.1f;

        Disable();
    }

    public void Enable()
    {
        gameObject.SetActive(true);
    }

    public void Disable()
    {
        gameObject.SetActive(false);
    }

    void Update()
    {
        transform.Rotate(Vector3.forward*rotateSpeed*Time.deltaTime);
    }
}
