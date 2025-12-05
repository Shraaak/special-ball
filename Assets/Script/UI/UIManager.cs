using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [Header("UI 模块")]
    public GameObject pausePanel;
    public GameObject gameOverPanel;
    public GameObject winPanel;
    public GameObject hudPanel;

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    void Start()
    {
        if(pausePanel) pausePanel.SetActive(false);
        if(gameOverPanel) gameOverPanel.SetActive(false);
        if(winPanel) winPanel.SetActive(false);
        
        if(hudPanel) hudPanel.SetActive(true);
    }
    public void ShowPausePanel(bool show)
    {
        pausePanel.SetActive(show);
        Time.timeScale = show ? 0f : 1f;
    }

    public void ShowGameOver()
    {
        gameOverPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void ShowWin()
    {
        winPanel.SetActive(true);
        Time.timeScale = 0f;
    }
}
