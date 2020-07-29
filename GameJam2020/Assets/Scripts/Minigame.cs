using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minigame : HoldClick
{
    [SerializeField] GameObject mg;
    [SerializeField] float Delay;
    [SerializeField] List<GameObject> ObjectsToDeactivate;
    [SerializeField] List<GameObject> FadeIn;


    protected override void Awake()
    {
        base.Awake();
        mg.SetActive(false);
    }

    public override void Activate()
    {
        base.Activate();
        StartCoroutine(DelayForMinigame());
    }

    IEnumerator DelayForMinigame()
    {
        yield return new WaitForSeconds(Delay);
        mg.SetActive(true);
    }

    public void GameOver()
    {
        StartCoroutine(HideGame());
    }

    IEnumerator HideGame()
    {
        foreach (GameObject g in FadeIn)
        {
            g.SetActive(true);
        }
        yield return new WaitForSeconds(1.5f);
        mg.SetActive(false);
        foreach (GameObject g in ObjectsToDeactivate)
        {
            g.SetActive(false);
        }
        ShowAllEndObjects();
    }

}
