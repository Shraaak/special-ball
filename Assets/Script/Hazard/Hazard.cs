using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Hazard : MonoBehaviour
{
    protected Collider2D hazardCollider;
    protected bool isActive = true;
    protected void OnTriggerEnter2D(Collider2D other)
    {
        Player player = other.GetComponent<Player>();
        OnBallEnter(player);
    }

    protected abstract void OnBallEnter(Player player);
    protected virtual void SetActive(bool isActive) 
    {
        this.isActive = isActive;
    }
}
