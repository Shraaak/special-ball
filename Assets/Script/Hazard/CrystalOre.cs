using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalOre : Hazard
{
    protected override void OnBallEnter(Player player)
    {
        player.stateMachine.ChangeState(player.dieState);
    }
}
