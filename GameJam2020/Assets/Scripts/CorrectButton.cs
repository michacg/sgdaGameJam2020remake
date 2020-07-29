using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorrectButton : MonoBehaviour
{
    [SerializeField] private GameObject emote;
    private bool OnPanel = false;

    private void OnMouseOver()
    {
        emote.SetActive(true);

        if (Input.GetMouseButtonDown(0))
        {
            ChapterManager.instance.NextPanel();
            //   OnPanel = false;
        }
    }

    private void OnMouseExit()
    {
        emote.SetActive(false);
    }


}
