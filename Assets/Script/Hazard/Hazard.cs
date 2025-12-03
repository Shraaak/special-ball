using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Hazard : MonoBehaviour
{
    protected Collider2D hazardCollider;
    protected bool isActive = true;

    protected virtual void Awake()
    {
        hazardCollider = GetComponent<Collider2D>();
    }

    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        if (!isActive) return;

        Player player = other.GetComponent<Player>();

        if (player != null) OnBallEnter(player);
    }

    protected virtual void OnTriggerStay2D(Collider2D other)
    {
        // 子类可以重写
    }
    
    protected virtual void OnTriggerExit2D(Collider2D other)
    {
        // 子类可以重写
    }

    protected abstract void OnBallEnter(Player player);
    protected virtual void SetActive(bool isActive) 
    {
        this.isActive = isActive;
    }
}
