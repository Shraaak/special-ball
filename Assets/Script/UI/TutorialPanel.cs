using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TutorialPanel : MonoBehaviour
{
    public Animator animator;
    public TextMeshProUGUI tutorialText;
    public List<string> initText;

    void Start()
    {
        gameObject.SetActive(true);
        ShowTutorial(initText);
       
    }

    public void ShowTutorial(List<string> messages)
    {
        StartCoroutine(TutorialCoroutine(messages));
    }

    private IEnumerator TutorialCoroutine(List<string> messages)
    {

        // 播放 Show 动画
        StartCoroutine(PlayShowAnimation());
        
        // 逐条展示文字
        for (int i = 0; i < messages.Count; i++)
        {
            tutorialText.text = messages[i];

            yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
            yield return null;
        }

        // 播放 Hide 动画
        StartCoroutine(PlayHideAnimation());

    }

    public IEnumerator PlayHideAnimation()
    {
        animator.SetTrigger("Hide");
        yield return new WaitForSecondsRealtime(0.1f);
        // 这里的时间改成 Hide 动画时长
    }
    public IEnumerator PlayShowAnimation()
    {
        animator.SetTrigger("Show");
        yield return new WaitForSecondsRealtime(0.1f);
        // 这里的时间改成 Show 动画时长
    }
}
