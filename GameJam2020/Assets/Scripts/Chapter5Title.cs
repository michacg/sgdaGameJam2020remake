using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chapter5Title : MonoBehaviour, Interactable
{
    [SerializeField] GameObject TitleNext;

    void Awake()
    {
        TitleNext.SetActive(false);
    }

    public void Activate()
    {
        TitleNext.SetActive(true);
    }
}
