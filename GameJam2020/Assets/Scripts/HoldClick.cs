using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldClick : MonoBehaviour, Interactable
{
    public List<GameObject> EndOfInteractionObjects;

    protected bool Pressed = false;
    protected bool OnPanel = false;
    // Start is called before the first frame update
    protected virtual void Awake()
    {
        GetComponentInParent<Panel>().OnPanel += Activate;
        HideAllEndObjects();
    }

    protected void OnMouseDown()
    {
        FindObjectOfType<audioManager>().Play("cupNoodleLid");
        Pressed = true;
    }

    protected virtual void OnMouseUp()
    {
        FindObjectOfType<audioManager>().Pause("cupNoodleLid");
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

    public virtual void Activate()
    {
        Debug.Log("Hello!");
        OnPanel = true;
    }
}
