using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chapter5Part1 : MonoBehaviour, Interactable
{
    [SerializeField] GameObject[] ObjectsFromTitle;
    [SerializeField] GameObject[] ObjectsToShow;
    [SerializeField] MoveOrScale balloon;
    [SerializeField] MoveOrScale balloonIG;
    [SerializeField] GameObject TitleNext;
    [SerializeField] GameObject UpArm;
    [SerializeField] GameObject UpBody;
    [SerializeField] GameObject DownArm;
    [SerializeField] GameObject DownBody;
    [SerializeField] GameObject PicButton;

    void Awake()
    {
        DownArm.SetActive(false);
        DownBody.SetActive(false);
    }

    void Start()
    {
        foreach (GameObject g in ObjectsToShow)
        {
            g.SetActive(false);
        }
    }

    public void Activate()
    {
        StartCoroutine(StartFS());
    }

    IEnumerator StartFS()
    {
        TitleNext.SetActive(false);
        foreach (GameObject g in ObjectsFromTitle)
        {
            g.GetComponent<Fade>().FadeOut();
        }
        yield return new WaitForSeconds(1f);
        foreach (GameObject g in ObjectsToShow)
        {
            g.SetActive(true);
        }
        yield return new WaitForSeconds(1f);
        balloon.gameObject.SetActive(true);
        balloon.StartMovement();
        balloonIG.gameObject.SetActive(true);
        balloonIG.StartMovement();

    }

    void OnMouseDown()
    {
        PicButton.SetActive(false);
        TitleNext.SetActive(true);
        UpArm.SetActive(false);
        UpBody.SetActive(false);
        DownArm.SetActive(true);
        DownBody.SetActive(true);
        this.GetComponent<BoxCollider2D>().enabled = false;
        balloonIG.StopRoutine();

    }
}
