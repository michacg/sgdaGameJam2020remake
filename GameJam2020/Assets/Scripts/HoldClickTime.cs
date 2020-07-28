using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldClickTime : HoldClick
{
    [SerializeField] GameObject ChangingObject;
    [SerializeField] float SpriteChangeTimer;
    [SerializeField] List<Sprite> Sprites;

    SpriteRenderer SpriteRend;

    float totalTime;
    float timer;

    void Start()
    {
        totalTime = SpriteChangeTimer * Sprites.Count;
        SpriteRend = ChangingObject.GetComponent<SpriteRenderer>();
        NotInteracting();
    }

    // Update is called once per frame
    void Update()
    {
        if(Pressed && OnPanel)
        {
            if(RoundToOneDP(timer) % SpriteChangeTimer == 0)
            {
                if (timer < totalTime)
                {
                    SpriteRend.sprite = Sprites[(int)(timer / SpriteChangeTimer)];

                    if ((int)(timer / SpriteChangeTimer) == Sprites.Count - 1)
                    {
                        ShowAllEndObjects();
                    }
                }
                else
                {
                    OnPanel = false;
                    ChapterManager.instance.NextPanel();
                }
            }
            timer += Time.deltaTime;

        }
    }

    float RoundToOneDP(float num)
    {
        return (int)(num * 10) / 10f;
    }

    protected override void OnMouseUp()
    {
        base.OnMouseUp();   
        NotInteracting();
    }

    protected override void OnMouseExit()
    {
        base.OnMouseExit();
        NotInteracting();
    }

    void NotInteracting()
    {
        timer = 0f;
        SpriteRend.sprite = Sprites[0];
    }

}
