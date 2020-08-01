using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickToControl : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 0.1f;
    [SerializeField] private GameObject onTrack;
    [SerializeField] private GameObject offTrack;

    private Vector3 mousePosition;

    bool OnPanel = false;

    private void Awake()
    {
        GetComponentInParent<Panel>().OnPanel += Activate;
    }

    void Update()
    {
        if (Input.GetMouseButton(0) && OnPanel)
        {
           
            mousePosition=Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = Vector2.Lerp(transform.position, mousePosition, moveSpeed * Time.deltaTime);
        }
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("target") && onTrack.activeSelf)
        {
            OnPanel = false;
            ChapterManager.instance.NextPanel();
        }

        onTrack.SetActive(true);
        offTrack.SetActive(false);
        audioManager.instance.Play("slash");
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        onTrack.SetActive(false);
        offTrack.SetActive(true);
    }

    void Activate()
    {
        OnPanel = true;
    }
}
