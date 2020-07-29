using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpRefill : MonoBehaviour
{
    [SerializeField] private float refillInc;
    [SerializeField] private float cooldown;

    private void Start()
    {
        StartCoroutine(refill());
    }

    private IEnumerator refill()
    {
        while (true)
        {
            if (transform.localScale.x < 1 && transform.localScale.x > 0)
            {
                Vector3 newScale = transform.localScale;
                newScale.x += refillInc;
                transform.localScale = newScale;
            }

            yield return new WaitForSeconds(cooldown);

        }

    }
}
