using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class phone : MonoBehaviour
{

    [SerializeField] private GameObject xeth;
    [SerializeField] private Sprite xethLay;
    [SerializeField] private Sprite xethPhone;
    [SerializeField] private GameObject heart0;
    [SerializeField] private GameObject heart1;

    [SerializeField] private float yPos;

    bool OnPanel = false;

    void Awake()
    {
        GetComponentInParent<Panel>().OnPanel += Activate;
    }

        void Update()
        {
            if (heart0.GetComponent<SpriteRenderer>().color == new Color(1,1,1f))
            {
                Vector3 newPos = transform.position;
                newPos.y = yPos;
                transform.position = Vector2.Lerp(transform.position, newPos, 0.1f);
            }
            if (heart1.GetComponent<SpriteRenderer>().color == new Color(1, 1, 1f))
            {
                //DONE
                ChapterManager.instance.NextPanel();
                OnPanel = false;
            }
        }

    private void OnMouseOver()
    {
        xeth.GetComponent<SpriteRenderer>().sprite = xethPhone;
    }

    private void OnMouseExit()
    {
        xeth.GetComponent<SpriteRenderer>().sprite = xethLay;
    }


    void Activate()
    {
        OnPanel = true;
    }

}
