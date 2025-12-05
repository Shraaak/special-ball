using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialTrigger1 : MonoBehaviour
{
    [SerializeField] private GameObject tutorialPanelObject;

    public List<string> text;
    void OnTriggerEnter2D(Collider2D collision)
    {
        print("触发教程");
        TutorialPanel tutorialPanel = tutorialPanelObject.GetComponent<TutorialPanel>();

        if (tutorialPanel) tutorialPanel.ShowTutorial(text);
    }
}
