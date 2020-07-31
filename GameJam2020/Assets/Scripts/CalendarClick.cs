using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalendarClick : MonoBehaviour
{
    [SerializeField] GameObject nextMonth;

    private void OnMouseDown()
    {
        EventController.instance.calendarClicked = true;
        audioManager.instance.Play("pageFlip");
        nextMonth.SetActive(true);
        //gameObject.SetActive(false);
    }
}
