using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorrectButton : MonoBehaviour
{
    [SerializeField] private GameObject emote;
    private bool OnPanel = false;

    private void OnMouseOver()
    {
        if(emote)
            emote.SetActive(true);

        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("button true");
            ChapterManager.instance.NextPanel();
            OnPanel = false;
        }
    }

    private void OnMouseExit()
    {
        if(emote)
            emote.SetActive(false);
    }


}
