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
    //[SerializeField] GameObject PhoneBG;

    void Awake()
    {
        DownArm.SetActive(false);
        DownBody.SetActive(false);
        PicButton.SetActive(false);
        this.GetComponent<BoxCollider2D>().enabled = false;
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
       // PhoneBG.SetActive(true);
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
        PicButton.SetActive(true);
        this.GetComponent<BoxCollider2D>().enabled = true;

    }

    void OnMouseDown()
    {

        if (gameObject.GetComponent<AudioSource>() != null)
            gameObject.GetComponent<AudioSource>().Play();
        
        //PhoneBG.SetActive(false);
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
