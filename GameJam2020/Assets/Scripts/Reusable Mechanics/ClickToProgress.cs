using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickToProgress : MonoBehaviour
{
    void OnMouseDown()
    {
        FindObjectOfType<audioManager>().Play("onClick");
        Debug.Log("here");
        ChapterManager.instance.NextPanel();
    }
}
