using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickToProgress : MonoBehaviour
{
    bool BeenClicked = false;

    private void OnEnable()
    {
        BeenClicked = false;
    }

    void OnMouseDown()
    {
        if (!BeenClicked)
        {
            BeenClicked = true;
            audioManager.instance.Play("onClick");
            MultiPanel p = GetComponentInParent<MultiPanel>();
            if (p == null || !p.NextPart())
            {
                Debug.Log("NO MORE PANELS");
                ChapterManager.instance.NextPanel();
            }
        }
       
    }
}
