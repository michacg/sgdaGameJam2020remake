using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeUIButton : MonoBehaviour
{
    private SpriteRenderer sprite;

    private void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    void OnMouseOver()
    {
        sprite.color = new Color(1, 1, 1, 0.5f);
    }

    private void OnMouseExit()
    {
        sprite.color = new Color(1, 1, 1, 1);
    }
}
