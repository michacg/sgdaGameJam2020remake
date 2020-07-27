﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drinkSelect : MonoBehaviour
{
    SpriteRenderer sprite;

    private void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    void OnMouseOver()
    {
        // IF ramen cup
        if (gameObject.CompareTag("Progression"))
        {
            if (Input.GetMouseButton(0))
            {
                sprite.color = new Color(1, 1, 1, 0.5f);
                print("go to next scene");
            }
            else
            {
                sprite.color = new Color(1, 1, 1, 1);
            }
        }
        else
        {
            sprite.color = new Color(1, 1, 1, 1);
        }
    }

    private void OnMouseExit()
    {
        sprite.color = new Color(1, 1, 1, 0);
    }
}
