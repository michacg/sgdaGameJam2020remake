using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hi2 : MonoBehaviour
{
    private void OnEnable()
    {
        MessageBing.instance.NextPanel();
    }
}
