using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PutDownPhone : MonoBehaviour, Interactable
{
    [SerializeField] GameObject[] PhoneComp;
    [SerializeField] GameObject UpBody;
    [SerializeField] GameObject DownBody;
    [SerializeField] GameObject DownArm;
    [SerializeField] float TimeDelay;
    [SerializeField] GameObject TitleNext;


    public void Activate()
    {
        TitleNext.SetActive(false);
        foreach(GameObject g in PhoneComp)
        {
            g.SetActive(false);
        }
        StartCoroutine(Animation());
    }

    IEnumerator Animation()
    {
        DownArm.SetActive(false);
        yield return new WaitForSeconds(TimeDelay);
        DownBody.SetActive(false);
        UpBody.SetActive(true);
        yield return new WaitForSeconds(TimeDelay);
        TitleNext.SetActive(true);
        
    }
    
}
