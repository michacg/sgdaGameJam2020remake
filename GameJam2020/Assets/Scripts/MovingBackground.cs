using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBackground : HoldClick
{
    [SerializeField] List<GameObject> BackgroundObjects;
    [SerializeField] float TimeToLoop;
    [SerializeField] float LeftBound;
    [SerializeField] float DistanceToLoop;
    [SerializeField] float ShiftSpeed;


    float timer = 0f;


    // Update is called once per frame
    void Update()
    {
        if(OnPanel)
        {
            LoopBackground();
            timer += Time.deltaTime;

            if (timer >= TimeToLoop)
            {
                ShowAllEndObjects();
            }
        }
    }

    void LoopBackground()
    {
        foreach(GameObject g in BackgroundObjects)
        {
            if (g.transform.localPosition.x < LeftBound)
            {
                g.transform.localPosition += (Vector3.right * DistanceToLoop * 2);
            }
            g.transform.Translate(Vector2.left * ShiftSpeed * Time.deltaTime);

        }
    }

}
