using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PopulateLaunchInfo : MonoBehaviour
{
	public Sprite testImage;
	public GameObject infoPiece;
	public void Populate(string nameOfMission, string nameOfRocket, int numberOfPayloads, string countryOfOrigin, bool isFlightUpcoming, int flightNumber)
	{	
		//populate the information required
		string stringToPrint = "Name of mission: " + nameOfMission + "; Name of rocket: " + nameOfRocket + 
				"; Number of payloads: " + numberOfPayloads + "; Country of origin: " + countryOfOrigin;
		
		infoPiece.GetComponentInChildren<TextMeshProUGUI>().text = stringToPrint;
		Image statusImage = infoPiece.GetComponentInChildren<Image>();
		statusImage.sprite = testImage;

		//set green or red icon for status of flight
		if (isFlightUpcoming)
		{
			statusImage.color = new Color32(255, 0, 0, 100);
		}
		else 
		{
			statusImage.color = new Color32(0, 255, 0, 100);
		}

		//add flight number info to each information object to enable further data retrieval on demand
		infoPiece.GetComponent<LaunchDataContainer>().flightNumber = flightNumber;		
		GameObject instantiadedInformationPiece = Instantiate(infoPiece, transform);
	}	
}