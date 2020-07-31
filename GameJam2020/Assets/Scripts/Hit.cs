using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit : MonoBehaviour
{
    [SerializeField] private GameObject hpBar;
    [SerializeField] private float hitInc;

    bool OnPanel = false;

    private void Awake()
    {
        GetComponentInParent<Panel>().OnPanel += Activate;
    }

    private void OnMouseDown()
    {
        if (OnPanel)
        {
            Vector3 newScale = hpBar.transform.localScale;
            newScale.x -= hitInc;

            if (newScale.x <= 0)
            {
                newScale.x = 0;
                hpBar.transform.localScale = newScale;

                ChapterManager.instance.NextPanel();
                OnPanel = false;
            }
            else
            {
                audioManager.instance.Play("dps");
                hpBar.transform.localScale = newScale;
            }
        }
    }

    void Activate()
    {
        OnPanel = true;
    }
}
