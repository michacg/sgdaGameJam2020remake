using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickForKeebs : MonoBehaviour
{

    private void OnMouseDown()
    {
        // Play SFX
        Debug.Log("hiya");
        audioManager.instance.Play("keyPress");
    }

}

