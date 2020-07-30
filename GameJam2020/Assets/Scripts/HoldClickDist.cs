using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldClickDist : HoldClick
{
    [SerializeField] GameObject MovingObject;
    [SerializeField] float xDistance;
    [SerializeField] float MaxYIncrease;

    bool StopWalking = false;

    float OrigX;
    float OrigY;
    float yDir = 1;

    // Start is called before the first frame update
    protected override void Awake()
    {
        base.Awake();
        OrigX = MovingObject.transform.position.x;
        OrigY = MovingObject.transform.position.y;
       

    }
    private void Start()
    {

        audioManager.instance.Play("footStep", true);
        //loop in audio manager
    }
    // Update is called once per frame
    void Update()
    {

        if (Pressed && !StopWalking && OnPanel)
        {
            audioManager.instance.Unpause("footStep");
            if (MovingObject.transform.position.x - OrigX < xDistance)
            {

                MovingObject.transform.Translate(Vector2.right * Time.deltaTime * xDistance / 2);

                if (MovingObject.transform.position.y > OrigY + MaxYIncrease || MovingObject.transform.position.y < OrigY)
                {
                    yDir = -1 * yDir;
                }

                MovingObject.transform.Translate(Vector2.up * Time.deltaTime * yDir);
            }
            else
            {
                audioManager.instance.Pause("footStep");
                StopWalking = true;
                ShowAllEndObjects();
            }
        }
        else
        {
            audioManager.instance.Pause("footStep");
        }
    }
}
