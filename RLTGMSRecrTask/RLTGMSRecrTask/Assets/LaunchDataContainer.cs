using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchDataContainer : MonoBehaviour
{
    //stores flightnumber and enables a button to pass it on click
    public int flightNumber;

    public void OpenPopup()
    {
        Canvas canvas = GetComponentInParent<Canvas>();
        PopupController popUpController = canvas.GetComponent<PopupController>();
        popUpController.OpenPopupAndPassFlightNumber(flightNumber);
    }

}
