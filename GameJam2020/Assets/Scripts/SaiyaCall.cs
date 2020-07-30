using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaiyaCall : MonoBehaviour
{
    private void OnMouseDown()
    {
        // saiya pick up SFX (?)
        EventController.instance.saiyaClicked = true;
    }
}
