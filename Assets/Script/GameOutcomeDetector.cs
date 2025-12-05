using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOutcomeDetector : MonoBehaviour
{
    [Header("到达需要的生命最大值")]
    [SerializeField] float failThreshold = 0.1f;
    void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();

        if(player) 
        {
            if (WinOrLose(player))
            {
                //协程播放胜利动画

                UIManager.Instance.ShowWin();
            }
            else
            {
                //协程播放失败动画

                player.stateMachine.ChangeState(player.dieState);
            }
        }

    }

    private bool WinOrLose(Player player)
    {
        if (player.hp >= failThreshold) return true;
        else return false;
    }

    
}
