using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickToProgress : MonoBehaviour
{
    void OnMouseDown()
    {
        audioManager.instance.Play("onClick");
        Debug.Log("here");
        MultiPanel p = GetComponentInParent<MultiPanel>();
        if(p == null || !p.NextPart())
        {
            ChapterManager.instance.NextPanel();
        }
       
    }
}
