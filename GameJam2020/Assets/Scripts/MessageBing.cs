using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageBing : MonoBehaviour
{
    [SerializeField] private Sprite newMSG;
    [SerializeField] private Sprite newMSGhover;
    [SerializeField] private float waitTime;

    [SerializeField] private GameObject chat;
    [SerializeField] private float chatY;

    private SpriteRenderer m_sprite;
    private bool pinged = false;
    bool OnPanel = false;

    private void Awake()
    {
        GetComponentInParent<Panel>().OnPanel += Activate;
        m_sprite = GetComponent<SpriteRenderer>();
    }


    void Update()
    {
        if (OnPanel && !pinged)
        {
            StartCoroutine(WaitThenPing());
            pinged = true;
        }
    }

    private IEnumerator WaitThenPing()
    {
        yield return new WaitForSeconds(waitTime);

        //sound sfx
        audioManager.instance.Play("msgNotif");
        m_sprite.sprite = newMSG;
    }

    private void OnMouseOver()
    {
        // Pinged
        if (m_sprite.sprite == newMSG)
        {
            m_sprite.sprite = newMSGhover;
        }

        // Open Message
        if (Input.GetMouseButtonDown(0))
        {
            chat.SetActive(true);
            Vector3 newPos = chat.transform.position;
            newPos.y = chatY;
            chat.transform.position = Vector3.Lerp(chat.transform.position, newPos, Time.time);
            gameObject.SetActive(false);
        }
    }

    private void OnMouseExit()
    {
        if (m_sprite.sprite == newMSGhover)
        {
            m_sprite.sprite = newMSG;
        }
    }

    private IEnumerator SmoothMove(Vector3 currentPos, Vector3 targetPos, float waitTime)
    {

        while (chat.transform.position != targetPos)
        {
            chat.transform.position = Vector3.Lerp(currentPos, targetPos, 0.1f);
            yield return new WaitForSeconds(waitTime);
        }
    }

    void Activate()
    {
        OnPanel = true;
    }

}
