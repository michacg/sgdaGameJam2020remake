using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWing : MonoBehaviour
{
    [SerializeField] private GameObject xeth;
    [SerializeField] private GameObject newXeth;
    [SerializeField] private float rotZ;

    bool OnPanel = false;

    private void Awake()
    {
        GetComponentInParent<Panel>().OnPanel += Activate;
    }

    void Update()
    {
        if (Input.anyKeyDown && OnPanel) //And panel on
        {
            if (newXeth.activeSelf)
            {
                ChapterManager.instance.NextPanel();
                OnPanel = false;
            }
            else
            {
                transform.rotation = Quaternion.Euler(new Vector3(0, 0, rotZ));
                xeth.SetActive(false);
                newXeth.SetActive(true);

            }
        }
    }

    void Activate()
    {
        OnPanel = true;
    }
}
