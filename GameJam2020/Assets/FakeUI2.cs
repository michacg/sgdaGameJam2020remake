using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeUI2 : MonoBehaviour
{
    [SerializeField] private GameObject fakeUI;
    private SpriteRenderer sprite;

    private void Awake()
    {
        sprite = fakeUI.GetComponent<SpriteRenderer>();
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
