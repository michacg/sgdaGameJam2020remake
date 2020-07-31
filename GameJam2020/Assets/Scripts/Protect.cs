using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Protect : MonoBehaviour
{
    [SerializeField] private float moveInc;
    [SerializeField] private GameObject wingPivot;
    [SerializeField] private float rotZ;

    bool OnPanel = false;

    private void Awake()
    {
        GetComponentInParent<Panel>().OnPanel += Activate;
    }

    void Update()
    {
        if (OnPanel && (Input.GetMouseButton(0) || Input.GetAxis("Horizontal") > 0)) //on panel
        {
            Vector3 newPos = transform.position;
            newPos.x += moveInc;

            if (wingPivot.transform.rotation != Quaternion.Euler(new Vector3(0, 0, rotZ)))
                transform.position = newPos;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Protected SFX!
        audioManager.instance.Play("block");
        wingPivot.transform.rotation = Quaternion.Euler(new Vector3(0, 0, rotZ));

        ChapterManager.instance.NextPanel();
        OnPanel = false;

    }

    void Activate()
    {
        OnPanel = true;
    }
}
