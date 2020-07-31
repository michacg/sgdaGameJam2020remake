using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventController : MonoBehaviour
{
    public static EventController instance;
    [SerializeField] private GameObject[] photos;
    [SerializeField] private GameObject discord;

    public int photosTaped = 0;
    public bool calendarClicked = false;
    public bool saiyaClicked = false;

    bool OnPanel = false;


    void Awake()
    {
        GetComponentInParent<Panel>().OnPanel += Activate;
        if (instance == null)
            instance = this;
    }

    void Update()
    {

        if (OnPanel)
        {
            // Check if photos are taped
            if (photosTaped >= photos.Length && calendarClicked)
            {
                // DISCORD SFX
                audioManager.instance.Play("joinedCall");
                discord.SetActive(true);
            }

            if (saiyaClicked)
            {
                ChapterManager.instance.NextPanel();
                OnPanel = false;
            }
        }


    }

    void Activate()
    {
        OnPanel = true;
    }


}
