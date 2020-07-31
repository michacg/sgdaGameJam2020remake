using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickToBuff : MonoBehaviour
{

    private void OnMouseDown()
    {
        // Play SFX
        audioManager.instance.Play("buff");
    }

}

