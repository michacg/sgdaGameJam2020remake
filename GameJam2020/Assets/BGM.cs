using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGM : MonoBehaviour
{
    public static BGM instance;

    [SerializeField] private AudioClip[] songs;
    [SerializeField] private AudioSource m_audio;
    private int track = 0;

    void Awake()
    {
        if (instance == null)
            instance = this;

        m_audio = GetComponent<AudioSource>();    
    }

    // Update is called once per frame
    private void Start()
    {
        m_audio.Play();
    }

    public void ChangeSong()
    {
        m_audio.clip = songs[track];
        track++;
        m_audio.Play();
    }
}
