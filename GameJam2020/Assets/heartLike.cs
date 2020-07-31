using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heartLike : MonoBehaviour
{
    [SerializeField] private GameObject xeth;
    [SerializeField] private Sprite xethPhone;
    private SpriteRenderer m_sprite;
    private bool clicked = false;

    private void Awake()
    {
        m_sprite = GetComponent<SpriteRenderer>();
    }


    private void OnMouseDown()
    {
        m_sprite.color = new Color(1, 1, 1, 1f);
        clicked = true;
    }
    private void OnMouseOver()
    {
        if (!clicked)
            m_sprite.color = new Color(1, 1, 1, 0.5f);
        xeth.GetComponent<SpriteRenderer>().sprite = xethPhone;
    }

    private void OnMouseExit()
    {
        if (!clicked)
        {
            m_sprite.color = new Color(1, 1, 1, 0f);
        }

    }
}
