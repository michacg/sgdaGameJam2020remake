using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fade : MonoBehaviour
{
    [SerializeField] float FadeSpeed;
    [SerializeField] bool FadeOnEnable = true;

    SpriteRenderer sr;

    bool isFading = false;
    // Start is called before the first frame update
    void Awake()
    {
        sr = this.GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {
        if (FadeOnEnable)
            StartCoroutine(FadeInRoutine());
    }

    private void OnDisable()
    {

        StartCoroutine(FadeOutRoutine());
    }

    public void FadeIn()
    {
        if (!isFading)
            StartCoroutine(FadeInRoutine());
    }

    public void FadeOut()
    {
        if (!isFading)
            StartCoroutine(FadeOutRoutine());
    }

    public void StartTransparent()
    {
        Color col = sr.color;
        col.a = 0;
        sr.color = col;
    }

    IEnumerator FadeInRoutine()
    {
        isFading = true;
        Color col = sr.color;
        col.a = 0;
        while (col.a < 1f)
        {
            sr.color = col;
            col.a += Time.deltaTime * FadeSpeed;
            yield return null;
        }
        col.a = 1f;
        sr.color = col;
        isFading = false;
    }

    IEnumerator FadeOutRoutine()
    {
        isFading = true;
        Color col = sr.color;
        col.a = 1f;
        while (col.a > 0f)
        {
            sr.color = col;
            col.a -= Time.deltaTime * FadeSpeed;
            yield return null;
        }
        col.a = 0;
        sr.color = col;
        isFading = false;
    }
}
