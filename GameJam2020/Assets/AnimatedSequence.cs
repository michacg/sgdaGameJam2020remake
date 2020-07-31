using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatedSequence : MonoBehaviour
{
    [SerializeField] Sprite[] sprites;
    [SerializeField] GameObject obj;
    [SerializeField] float TimeBetweenSprites;

    SpriteRenderer sr;
    bool inRoutine;

    int index = 0;

    // Start is called before the first frame update
    private void Awake()
    {
        sr = obj.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!inRoutine)
        {
            StartCoroutine(CycleSprite());
        }
    }


    IEnumerator CycleSprite()
    {
        inRoutine = true;
        sr.sprite = sprites[index];
        yield return new WaitForSeconds(TimeBetweenSprites);
        index = (++index) % sprites.Length;
        inRoutine = false;
    }
}
