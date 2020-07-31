using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickToDmg : MonoBehaviour
{

    private void OnMouseDown()
    {
        // Play SFX
        audioManager.instance.Play("dmg");
    }

}
