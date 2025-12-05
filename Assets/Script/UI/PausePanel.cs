using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PausePanel : MonoBehaviour
{
    [Header("按钮配置")]
    [SerializeField] private Button resumeButton;
    [SerializeField] private Button homeButton;

    void Start()
    {
        resumeButton.onClick.AddListener(() =>
        {
            gameObject.SetActive(false);
            Time.timeScale = 1;
        });

        homeButton.onClick.AddListener(() =>
        {
            SceneManager.LoadScene(0);
        });
    }
}
