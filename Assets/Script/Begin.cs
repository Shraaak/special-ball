using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Begin : MonoBehaviour
{
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(StartGame);
    }
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
}
