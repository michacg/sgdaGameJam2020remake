using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phone : MonoBehaviour, Interactable
{
    [SerializeField] GameObject[] Comments;
    [SerializeField] GameObject[] ObjectsToActivate;
    [SerializeField] GameObject[] ObjectsToDeactivate;
    [SerializeField] GameObject TitleNext;

    int CommentIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject g in ObjectsToActivate)
        {
            g.SetActive(false);
        }
        foreach(GameObject c in Comments)
        {
            c.SetActive(false);
        }
    }

    public void Activate()
    {
        TitleNext.SetActive(false);
        foreach(GameObject g in ObjectsToActivate)
        {
            g.SetActive(true);
        }
    }

    public void LoadNextComment()
    {
        if (CommentIndex < Comments.Length)
        {
            Comments[CommentIndex].SetActive(true);
            CommentIndex += 1;
        }
        else
        {
            TitleNext.SetActive(true);
        }
    }
     
    void OnMouseDown()
    {
        if (gameObject.GetComponent<AudioSource>() != null)
            gameObject.GetComponent<AudioSource>().Play();

        foreach (GameObject g in ObjectsToDeactivate)
        {
            g.SetActive(false);
        }
        this.GetComponent<BoxCollider2D>().enabled = false;

    }
}
