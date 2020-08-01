using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalScene : MonoBehaviour
{
    [SerializeField] GameObject balloon;
    [SerializeField] float TargetX;
    [SerializeField] float MoveSpeed;
    [SerializeField] GameObject[] ObjectsToFadeIn;
    [SerializeField] GameObject Next;

    void Awake()
    {
        GetComponentInParent<Panel>().OnPanel += Activate;
        foreach(GameObject g in ObjectsToFadeIn)
        {
            g.SetActive(false);
        }
    }

    void Activate()
    {
        StartCoroutine(BalloonFly());
    }

    IEnumerator BalloonFly()
    {
        while(balloon.transform.localPosition.x > TargetX)
        {
            balloon.transform.Translate(Vector3.left * Time.deltaTime * MoveSpeed);
            yield return null;
        }
        foreach (GameObject g in ObjectsToFadeIn)
        {
            g.SetActive(true);
        }
        yield return new WaitForSeconds(1f);
        Next.SetActive(true);
    }
}
