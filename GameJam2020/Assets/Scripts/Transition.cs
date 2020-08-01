using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transition : MonoBehaviour, Interactable
{
    [SerializeField] GameObject WhitePanel;

    private void Start()
    {
        WhitePanel.GetComponent<Fade>().StartTransparent();
    }

    public void Activate()
    {
        StartCoroutine(FinalTransition());
    }

    IEnumerator FinalTransition()
    {
        WhitePanel.GetComponent<Fade>().FadeIn();
        yield return new WaitForSeconds(1.2f);
        ChapterManager.instance.NextPanel();
    }
}
