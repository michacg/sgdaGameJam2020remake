using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiPanel : Panel
{
    [SerializeField] GameObject[] objects;

    int index = 0;

    public override void Activate()
    {
        objects[index].GetComponent<Interactable>().Activate();
    }

    public bool NextPart()
    {
        index += 1;
        if (index >= objects.Length)
            return false;
        Activate();
        return true;
    }


}
