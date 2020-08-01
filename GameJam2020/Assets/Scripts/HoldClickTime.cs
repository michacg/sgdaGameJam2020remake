using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldClickTime : HoldClick
{
    [SerializeField] GameObject ChangingObject;
    [SerializeField] float SpriteChangeTimer;
    [SerializeField] List<Sprite> Sprites;
    [SerializeField] int TimesToRepeat = 1;
    [SerializeField] GameObject HoldUXIndicator;

    SpriteRenderer SpriteRend;

    float totalTime;
    float timer;

    int TimesLooped = 1;

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
            if(HoldUXIndicator)
                HoldUXIndicator.SetActive(false);
            if(RoundToOneDP(timer) % SpriteChangeTimer == 0)
            {
                if (timer < totalTime)
                {
                    SpriteRend.sprite = Sprites[(int)(timer / SpriteChangeTimer)];

                    if ((int)(timer / SpriteChangeTimer) == Sprites.Count - 1 && TimesLooped == TimesToRepeat)
                    {
                        ShowAllEndObjects();
                    }
                }
                else
                {
                    if (TimesLooped == TimesToRepeat)
                    {
                        OnPanel = false;
                        MultiPanel p = GetComponentInParent<MultiPanel>();
                        if (p == null || !p.NextPart()){
                            Debug.Log("activating next panel from hold click times ");
                            ChapterManager.instance.NextPanel();
                        }
                            
                    }
                    else
                    {
                        timer = 0f;
                        TimesLooped += 1;
                    }
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
        if(HoldUXIndicator)
            HoldUXIndicator.SetActive(false);
    }

    void NotInteracting()
    {
        timer = 0f;
        SpriteRend.sprite = Sprites[0];
    }

    private void OnMouseOver()
    {
        if(HoldUXIndicator && OnPanel)
            HoldUXIndicator.SetActive(true);
    }


}
