using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveOrScale : MonoBehaviour
{
    [SerializeField] bool ShouldMove;
    [SerializeField] float Speed;
    [SerializeField] float Minimum;

    Coroutine c;

    public void StartMovement()
    {
        c = StartCoroutine(ChangeOverTime());
    }

    IEnumerator ChangeOverTime()
    {
        if(ShouldMove)
        {
            while (this.transform.position.x > Minimum)
            {
                this.transform.Translate(Vector3.left * Time.deltaTime * Speed);
                yield return null;
            }
        }
        else
        {
            while (this.transform.localScale.x > Minimum)
            {
                this.transform.localScale *= Speed;
                yield return null;
            }
        }
    }

    public void StopRoutine()
    {
        StopCoroutine(c);
    }


}
