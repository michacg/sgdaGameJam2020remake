﻿using UnityEngine.Audio;
using System;
using UnityEngine;

public class audioManager : MonoBehaviour
{

    public Sound[] sounds;
    // Start is called before the first frame update
    void Awake()
    {
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
        }
    }

    // Update is called once per frame
    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.audioName == name);
        if (s == null)
        {
            Debug.Log("sound not found");
            return;
        }
        s.source.Play();
    }

    public void Pause(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.audioName == name);
        if (s == null)
        {
            Debug.Log("sound not found");
            return;
        }
        s.source.Stop();
    }
}
