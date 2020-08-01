using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class ScrollWheel : MonoBehaviour
{
    [SerializeField] private GameObject scrollingList;
    [SerializeField] private float wheelEndY;
    [SerializeField] private float listEndY;

    private SpriteRenderer sprite;
    private Vector3 posOnClick;
    private float wheelStartY;
    private float listStartY;

    private float wheelLen;
    private float listLen;

    bool OnPanel = false;

    private void Awake()
    {
        GetComponentInParent<Panel>().OnPanel += Activate;
        sprite = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        wheelStartY = transform.position.y;
        listStartY = scrollingList.transform.position.y;

        wheelLen = Math.Abs(wheelStartY) + Math.Abs(wheelEndY);
        listLen = Math.Abs(listStartY) + Math.Abs(listEndY);
    }

    private void Update()
    {
        if (OnPanel)
        {
            if (Input.anyKey)
            {
                OnMouseOver();
            }
            else
            {
                OnMouseExit();
            }
        }
    }
    void OnMouseOver()
    {
        sprite.color = new Color(1, 1, 1, 0.75f);
        if (Input.GetMouseButton(0) || Input.anyKey)
        {
            sprite.color = new Color(1, 1, 1, 0.5f);
            Scroll();
        }
        if (Input.GetMouseButtonDown(0))
        {
            posOnClick = Input.mousePosition;   
        }
    }

    private void OnMouseExit()
    {
        sprite.color = new Color(1, 1, 1, 1);
    }

    private void Scroll()
    {
        if (posOnClick == null)
            return;
        print(transform.position.y);

        //Scrolling Down
        if ((Input.mousePosition.y < posOnClick.y || Input.GetAxis("Vertical") < 0) && transform.position.y >= wheelEndY)
        {
            Vector3 newPos = transform.position;
            newPos.y -= .005f;
            transform.position = newPos;

            // List goes up
            Vector3 newPos2 = scrollingList.transform.position;
            newPos2.y += .01f;
            scrollingList.transform.position = newPos2;
        }
        else if (Input.mousePosition.y > posOnClick.y && transform.position.y <= wheelStartY)
        {
            Vector3 newPos = transform.position;
            newPos.y += .005f;
            transform.position = newPos;

            // List goes Down
            Vector3 newPos2 = scrollingList.transform.position;
            newPos2.y -= .01f;
            scrollingList.transform.position = newPos2;
        }
        
        
    }

    void Activate()
    {
        OnPanel = true;
    }

}
