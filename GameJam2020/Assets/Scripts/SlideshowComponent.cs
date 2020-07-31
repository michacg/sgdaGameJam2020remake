using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideshowComponent : MonoBehaviour
{
    [SerializeField] Fade[] Counterpart;
    [SerializeField] bool ShouldFadeOut = false;

    Fade fade;

    private void Awake()
    {
        fade = this.GetComponent<Fade>();
    }


    public bool DoneWithSlide()
    {
        if(ShouldFadeOut)
        {
            fade.FadeOut();
        }
        return ShouldFadeOut;
    }

    public void OnSlide()
    {
        if(Counterpart.Length > 0)
        {
            foreach (Fade f in Counterpart)
                f.FadeOut();
        }
        fade.FadeIn();
    }

    public void StartTransparent()
    {
        fade.StartTransparent();
    }
    
}
