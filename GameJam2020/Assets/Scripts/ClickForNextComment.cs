using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickForNextComment : MonoBehaviour
{
    private void OnMouseDown()
    {
        Debug.Log(this.gameObject.name + " is activated");
        this.GetComponent<BoxCollider2D>().enabled = false;
        GetComponentInParent<Phone>().LoadNextComment();
    }
}
