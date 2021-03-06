﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Panel: MonoBehaviour
{
    public delegate void Focused();
    public Focused OnPanel;

    public bool changeBGM = false;


    public virtual void Activate()
    {
        if(OnPanel != null)
        {
            OnPanel.Invoke();
        }

        if (changeBGM)
        {
            BGM.instance.ChangeSong();
        }
    }
}
