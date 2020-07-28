using System.Collections;
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
        print("on");
        sprite.color = new Color(1, 1, 1, 0.5f);

        //if (Input.GetMouseButtonDown(0))
        //{
        //    print("click");
        //    foreach (GameObject ui in unhideThis)
        //    {
        //        ui.SetActive(true);
        //    }
        //    foreach (GameObject ui in hideThis)
        //    {
        //        ui.SetActive(false);
        //    }
        //}
    }
}
