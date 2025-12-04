using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saw : Hazard
{
    [Header("旋转速度")]
    [SerializeField] private float rotateSpeed = 10f;
    protected override void OnBallEnter(Player player)
    {
        player.stateMachine.ChangeState(player.dieState);
    }

    void Update()
    {
        transform.Rotate(Vector3.forward, rotateSpeed * Time.deltaTime);
    }
}
