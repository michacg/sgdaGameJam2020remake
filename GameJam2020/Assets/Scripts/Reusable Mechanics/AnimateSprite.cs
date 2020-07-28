using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateSprite : MonoBehaviour
{
    [SerializeField] private Sprite[] sprites;
    [SerializeField] private float timeBetweenSprites;
    private SpriteRenderer m_spriteRend;

    private void Awake()
    {
        m_spriteRend = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        StartCoroutine(Animate());
    }

    private void Update()
    {

    }

    IEnumerator Animate()
    {
        while (true)
        {
            foreach (Sprite sprite in sprites)
            {
                m_spriteRend.sprite = sprite;
                yield return new WaitForSeconds(timeBetweenSprites);
            }
        }
        
    }
}
