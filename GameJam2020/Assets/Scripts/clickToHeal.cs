using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clickToHeal : MonoBehaviour
{

    private void OnMouseDown()
    {
        // Play SFX
        audioManager.instance.Play("healing");
    }

}
