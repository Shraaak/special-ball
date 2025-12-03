using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class FrostRay : Hazard
{
    [SerializeField] private GameObject frostRay;
    [SerializeField] private float coolTimer = 2f;
    private bool set = true;

    private float timer;
    void Start()
    {
        timer = coolTimer;
        frostRay.SetActive(set);
    }
    
    protected override void OnBallEnter(Player player)
    {
        player.stateMachine.ChangeState(player.frozenState);
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            timer = coolTimer;
            set = !set;
            frostRay.SetActive(set);
        }
    }
}
