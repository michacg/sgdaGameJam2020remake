using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickThisToMakeAppear : MonoBehaviour
{
    [SerializeField] private GameObject[] stuff;
    private int i = 0;

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (i <= stuff.Length)
                stuff[i].SetActive(true);
        }
    }

    private void OnMouseExit()
    {
        foreach (GameObject s in stuff)
            s.SetActive(false);
    }

}
