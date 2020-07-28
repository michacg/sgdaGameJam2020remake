using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeStuffAppear : MonoBehaviour
{
    [SerializeField] GameObject[] stuff;
    private int i = 0;

    private void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            // If all objects are present
            if (i == (stuff.Length))
            {
                print("Next Scene!");
            }
            else
            {
                stuff[i].SetActive(true);
                i++;
            }
        }
    }

}
