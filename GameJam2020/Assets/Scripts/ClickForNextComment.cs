using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickForNextComment : MonoBehaviour
{
    [SerializeField] private GameObject heart;
    
    private void OnMouseDown()
    {
        if(heart)
            heart.SetActive(true);
        Debug.Log(this.gameObject.name + " is activated");
        this.GetComponent<BoxCollider2D>().enabled = false;
        GetComponentInParent<Phone>().LoadNextComment();
    }
}
