using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Animator anim{ get; private set; }
    public Rigidbody2D rb{ get; private set; }
    public PlayerStateMechine stateMachine{get; private set;}
    public PlayerReadyState readyState{get; private set;}
    public PlayerFallState fallState{get; private set;}

    public List<Transform> dirPosition;

    public float readySpeed; //ready状态左右移动的速度

    void Awake()
    {
        stateMachine = new PlayerStateMechine();

        readyState = new PlayerReadyState(this, stateMachine, "Ready");
        fallState = new PlayerFallState(this, stateMachine, "Fall");
    }

    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody2D>();

        stateMachine.Initialize(readyState);
    }

    void Update()
    {
        stateMachine.currentState.Update();
    }
}
