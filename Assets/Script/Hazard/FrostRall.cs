using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrostRall : Hazard
{
    [Header("旋转速度")]
    [SerializeField] private float rotateSpeed = 50f;
    protected override void OnBallEnter(Player player)
    {
        player.stateMachine.ChangeState(player.frozenState);
    }

    void Update()
    {
        transform.Rotate(Vector3.forward, rotateSpeed * Time.deltaTime);
    }
}
