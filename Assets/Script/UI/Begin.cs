using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Begin : MonoBehaviour
{
    [Header("按钮配置")]
    [SerializeField] private Button beginButton;
    void Start()
    {
        beginButton.onClick.AddListener(() => 
        {
            SceneManager.LoadScene(1);
            Time.timeScale = 1;
        });
    }
}
