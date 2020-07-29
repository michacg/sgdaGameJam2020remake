using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorrectButton : MonoBehaviour
{
    [SerializeField] private GameObject emote;

    private void OnMouseOver()
    {
        emote.SetActive(true);

        if (Input.GetMouseButtonDown(0))
        {
            print("next scene");
        }
    }

    private void OnMouseExit()
    {
        emote.SetActive(false);
    }
}
