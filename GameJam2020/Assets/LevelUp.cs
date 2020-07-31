using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUp : MonoBehaviour
{
    //ya ummm sorry this code is straight up ugly lolm y b<3
    [SerializeField] private SpriteRenderer m_sprite;
    [SerializeField] private Sprite buttonUp;
    [SerializeField] private Sprite buttonDown;
    [SerializeField] private GameObject ageObj;
    [SerializeField] private Sprite[] numSprites;
    [SerializeField] private GameObject pic;
    [SerializeField] private Sprite[] ageSprites;

    private int age = 0;

    [SerializeField] private int perClick = 5;

    [SerializeField]  private int clicks = 0;
    bool OnPanel = false;
    
    void Awake()
    {
        GetComponentInParent<Panel>().OnPanel += Activate;
        m_sprite = GetComponent<SpriteRenderer>();
        m_sprite.sprite = buttonUp;
    }

    void Update()
    {
        print(age);
        if (age == numSprites.Length)
        {
            ChapterManager.instance.NextPanel();
            OnPanel = false;
        }

        if (age + 7 == 13)
            pic.GetComponent<SpriteRenderer>().sprite = ageSprites[0];

        if (age + 7 == 18)
            pic.GetComponent<SpriteRenderer>().sprite = ageSprites[1];
       
    }

    private void OnMouseDown()
    {

        if (OnPanel)
        {
            m_sprite.sprite = buttonDown;
            clicks++;


            // multiples of 5
            if (clicks % 5 == 0)
            {
                ageObj.GetComponent<SpriteRenderer>().sprite = numSprites[++age];
            }
        }
    }

    private void OnMouseUp()
    {
        if (OnPanel)
            m_sprite.sprite = buttonUp;
    }

    void Activate()
    {
        OnPanel = true;
    }
}
