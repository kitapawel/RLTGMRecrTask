using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using SimpleJSON;
using TMPro;
using UnityEngine.UI;

public class PopupController : MonoBehaviour
{
    public GameObject popUpContainer;
    public GameObject infoInstantiationParent;
    public GameObject shipInfoPiece;

    private readonly string oneLaunchURL = "https://api.spacexdata.com/v3/launches/";
    private readonly string oneShipURL = "https://api.spacexdata.com/v3/ships/";

    private void Awake()
    {
        popUpContainer.SetActive(false);
    }

    public void OpenPopupAndPassFlightNumber(int flightNumber)
    {
        popUpContainer.SetActive(true);
        ClearPopupWindow();
        StartCoroutine(GetShipIDs(flightNumber));
    }

    IEnumerator GetShipIDs(int flightNumber)
    {
        /*------------------Get ship ID from launch data------------------*/
        Debug.Log(oneLaunchURL + flightNumber);

        UnityWebRequest launchInfoRequest = UnityWebRequest.Get(oneLaunchURL + flightNumber);
        yield return launchInfoRequest.SendWebRequest();

        if (launchInfoRequest.isNetworkError || launchInfoRequest.isHttpError)
        {
            Debug.LogError(launchInfoRequest.error);
            yield break;
        }
        JSONNode launchInfoFromWeb = JSON.Parse(launchInfoRequest.downloadHandler.text);
        foreach (JSONNode ship in launchInfoFromWeb["ships"])
        {
            string shipID = ship;
            StartCoroutine(GetShipData(shipID));//connect to ship API            
        }
    }

    IEnumerator GetShipData(string shipID)
    {
        /*------------------Get ship data from ship data------------------*/
        Debug.Log(oneShipURL + shipID);

        UnityWebRequest shipInfoRequest = UnityWebRequest.Get(oneShipURL + shipID);
        yield return shipInfoRequest.SendWebRequest();

        if (shipInfoRequest.isNetworkError || shipInfoRequest.isHttpError)
        {
            Debug.LogError(shipInfoRequest.error);
            yield break;
        }
        JSONNode shipInfoFromWeb = JSON.Parse(shipInfoRequest.downloadHandler.text);

        string shipName = shipInfoFromWeb["ship_name"];
        int noOfMissions = 0;
        string shipType = shipInfoFromWeb["ship_type"];
        string homePort = shipInfoFromWeb["home_port"];
        string shipImageURL = shipInfoFromWeb["image"];

        foreach (JSONNode mission in shipInfoFromWeb["missions"])
        {
            noOfMissions += 1;
        }

        UnityWebRequest shipImageRequest = UnityWebRequestTexture.GetTexture(shipImageURL);        
        yield return shipImageRequest.SendWebRequest();
        if (shipImageRequest.isNetworkError || shipImageRequest.isHttpError)
        {
            Debug.LogError(shipImageRequest.error);
            yield break;
        }
        
        Texture shipTexture = DownloadHandlerTexture.GetContent(shipImageRequest);
        RawImage statusImage = shipInfoPiece.GetComponentInChildren<RawImage>();
        statusImage.texture = shipTexture;        
        
        string stringToPrint = "Ship: " + shipName + " of type: " + shipType + " took part in " + noOfMissions +
            " missions. Home port: " + homePort + ".";
        
        shipInfoPiece.GetComponentInChildren<TextMeshProUGUI>().text = stringToPrint;
        GameObject instantiadedInformationPiece = Instantiate(shipInfoPiece, infoInstantiationParent.transform);        
    }
    public void ClosePopup()
    {
        ClearPopupWindow();
        popUpContainer.SetActive(false);
    }
    public void ClearPopupWindow()
    {
        foreach (Transform child in infoInstantiationParent.transform)
        {
            Destroy(child.gameObject);
        }
    }
}
