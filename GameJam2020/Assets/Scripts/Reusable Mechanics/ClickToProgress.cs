using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickToProgress : MonoBehaviour
{
    void OnMouseDown()
    {
       audioManager.instance.Play("onClick");
        Debug.Log("here");
        ChapterManager.instance.NextPanel();
    }
}
