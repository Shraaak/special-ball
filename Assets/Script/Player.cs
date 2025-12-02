using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Animator anim{ get; private set; }
    public PlayerStateMechine stateMachine{get; private set;}

    public PlayerIdleState idleState{get; private set;}

    void Awake()
    {
        stateMachine = new PlayerStateMechine();

        idleState = new PlayerIdleState(this, stateMachine, "Idle");
    }

    void Start()
    {
        anim = GetComponentInChildren<Animator>();

        stateMachine.Initialize(idleState);
    }
}
