﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeUI : MonoBehaviour
{
    private SpriteRenderer sprite;
    [SerializeField] private GameObject[] hideThis;
    [SerializeField] private GameObject[] unhideThis;

    private void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    void OnMouseOver()
    {
        sprite.color = new Color(1, 1, 1, 0.5f);

        if (Input.GetMouseButtonDown(0))
        {
            foreach (GameObject ui in unhideThis)
            {
                ui.SetActive(true);
                ui.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
            }
            foreach (GameObject ui in hideThis)
            {
                ui.SetActive(false);
            }
        }
    }

    private void OnMouseExit()
    {
        sprite.color = new Color(1, 1, 1, 1);
    }
}
