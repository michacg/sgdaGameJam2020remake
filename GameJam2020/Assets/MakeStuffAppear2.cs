using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeStuffAppear2 : MonoBehaviour
{
    [SerializeField] GameObject[] stuff;
    private int i = 0;

    private void Update()
    {

        if (Input.anyKeyDown)
        {
            // If all objects are present
            if (i == (stuff.Length))
            {
                
            }
            else
            {
                if (this.GetComponent<AudioSource>() != null)
                {
                    this.GetComponent<AudioSource>().Play();
                }

                stuff[i].SetActive(true);
                i++;
            }
        }
    }
}
