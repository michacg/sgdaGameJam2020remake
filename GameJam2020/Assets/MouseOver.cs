using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseOver : MonoBehaviour
{
    [SerializeField] private GameObject ux;

    private void OnMouseOver()
    {
        ux.SetActive(true);
    }

    private void OnMouseExit()
    {
        ux.SetActive(false);
    }
}
