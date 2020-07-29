using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeStuffAppear : MonoBehaviour
{
    [SerializeField] GameObject[] stuff;
    private int i = 0;

    bool OnPanel = false;

    private void Start()
    {
        GetComponentInParent<Panel>().OnPanel += Activate;
    }

    private void Update()
    {

        if (Input.anyKeyDown && OnPanel)
        {
            // If all objects are present
            if (i == (stuff.Length))
            {
                ChapterManager.instance.NextPanel();
                OnPanel = false;
            }
            else
            {
                stuff[i].SetActive(true);
                i++;
            }
        }
    }

    void Activate()
    {
        OnPanel = true;
    }

}
