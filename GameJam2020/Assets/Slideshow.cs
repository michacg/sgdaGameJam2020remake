using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slideshow : MonoBehaviour, Interactable
{
    [SerializeField] SlideshowComponent[] components;
    [SerializeField] float TimeOnPicture;

    int index = 0;

    bool OnPanel = false;
    bool InRoutine = false;

    private void Awake()
    {
        GetComponentInParent<Panel>().OnPanel += Activate;
    }

    private void Start()
    {
        for(int i = 1; i < components.Length; ++i)
        {
            components[i].StartTransparent();
        }
    }

    public void Activate()
    {
        OnPanel = true;
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

        if (components[index].DoneWithSlide())
            yield return new WaitForSeconds(TimeOnPicture);

        ++index;

        if (index < components.Length)
        {
            components[index].OnSlide();
            yield return new WaitForSeconds(TimeOnPicture);
        }
        else
        {
            OnPanel = false;

            MultiPanel p = GetComponentInParent<MultiPanel>();
            if (p == null || !p.NextPart())
                ChapterManager.instance.NextPanel();
        }
        InRoutine = false;
    }

}
