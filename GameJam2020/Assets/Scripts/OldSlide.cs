using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OldSlide : MonoBehaviour
{
    [SerializeField] Fade[] ObjectsToShow;
    [SerializeField] float TimeOnPicture;
    [SerializeField] bool ShouldFade = true;

    bool OnPanel = false;
    bool InRoutine = false;

    int index = 0;

    private void Awake()
    {
        GetComponentInParent<Panel>().OnPanel += Activate;
        foreach (Fade f in ObjectsToShow)
        {
            f.StartTransparent();
        }
    }

    void Activate()
    {
        Debug.Log("Activating");
        ObjectsToShow[index].FadeIn();
    }

    private void OnMouseDown()
    {
        if (OnPanel && !InRoutine)
        {
            StartCoroutine(NextPicture());

        }
    }




    IEnumerator NextPicture()
    {
        InRoutine = true;
        if(ShouldFade)
            ObjectsToShow[index].FadeOut();

        ++index;
        Debug.Log("Next picture");

        yield return new WaitForSeconds(TimeOnPicture);

        if (index < ObjectsToShow.Length)
            ObjectsToShow[index].FadeIn();
        else
        {
            OnPanel = false;
            ChapterManager.instance.NextPanel();
        }
        yield return new WaitForSeconds(TimeOnPicture);
        InRoutine = false;
    }
}
