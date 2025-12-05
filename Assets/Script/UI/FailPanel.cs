using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FailPanel : MonoBehaviour
{
    [Header("按钮配置")]
    [SerializeField] private Button retryButton;

    void Start()
    {
        retryButton.onClick.AddListener(() =>
        {
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(currentSceneIndex);
            Time.timeScale = 1;
        });
    }
}