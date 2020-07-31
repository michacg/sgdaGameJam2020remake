using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhotoController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 0.1f;
    private SpriteRenderer sprite;
    private Vector3 mousePosition;

    public bool taped = false;
    private bool clicked = false;

    private void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (!taped && clicked)
        {
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = Vector2.Lerp(transform.position, mousePosition, moveSpeed);
        }
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("target")) // if on board
        {
            if (Input.GetMouseButtonDown(0))
            {
                taped = true;
                EventController.instance.photosTaped += 1;
                foreach (Transform child in transform)
                {
                    child.gameObject.SetActive(true);
                }
            }
        }
    }

    private void OnMouseDown()
    {
        clicked = true;
    }

    private void OnMouseOver()
    {
        if (!taped)
        {
            sprite.color = new Color(1, 1, 1, 0.5f);
        }
    }
    private void OnMouseExit()
    {
        if (!taped)
        {
            sprite.color = new Color(1, 1, 1, 1);
        }

    }

}
