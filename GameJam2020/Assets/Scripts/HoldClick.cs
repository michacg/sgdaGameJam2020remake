using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldClick : MonoBehaviour
{
    public List<GameObject> EndOfInteractionObjects;

    protected bool Pressed = false;
    protected bool OnPanel = false;
    // Start is called before the first frame update
    void Awake()
    {
        GetComponentInParent<Panel>().OnPanel += Activate;
        HideAllEndObjects();
    }

    protected void OnMouseDown()
    {
        Pressed = true;
    }

    protected virtual void OnMouseUp()
    {
        Pressed = false;
    }

    protected virtual void OnMouseExit()
    {
        Pressed = false;
    }


    protected void HideAllEndObjects()
    {
        foreach (GameObject g in EndOfInteractionObjects)
        {
            g.SetActive(false);
        }
    }

    protected void ShowAllEndObjects()
    {
        foreach (GameObject g in EndOfInteractionObjects)
        {
            g.SetActive(true);
        }
    }

    public void Activate()
    {
        Debug.Log("Activating");
        OnPanel = true;
    }
}
