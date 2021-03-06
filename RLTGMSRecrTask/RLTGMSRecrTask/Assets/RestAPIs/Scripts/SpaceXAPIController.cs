﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using SimpleJSON;
using UnityEngine.UI;
using TMPro;
using System;
using System.Runtime.CompilerServices;
using System.IO;

public class SpaceXAPIController : MonoBehaviour
{
    private PopulateLaunchInfo viewPopulator;
    public GameObject loadingMessage;

    private readonly string allLaunchesURL = "https://api.spacexdata.com/v3/launches";
    private readonly string oneRocketURL = "https://api.spacexdata.com/v3/rockets/";

    private void Awake()
    {
        viewPopulator = GetComponent<PopulateLaunchInfo>();
        loadingMessage.SetActive(false);
    }
    private void Start()
    {
        StartCoroutine(GetSpaceXAPIData());
    }
    IEnumerator GetSpaceXAPIData()
    {
        loadingMessage.SetActive(true);

        /*------------------Get data from All launches API------------------*/
        UnityWebRequest launchInfoRequest = UnityWebRequest.Get(allLaunchesURL);
        yield return launchInfoRequest.SendWebRequest();

        if (launchInfoRequest.isNetworkError || launchInfoRequest.isHttpError)
        {
            Debug.LogError(launchInfoRequest.error);
            yield break;
        }
        JSONNode launchInfoFromWeb = JSON.Parse(launchInfoRequest.downloadHandler.text);

        /*------------------Iterate through info from the downloaded data------------------*/
        foreach (JSONNode flight in launchInfoFromWeb)
        {
            int flightNumber = flight["flight_number"];
            string missionName = flight["mission_name"];
            string rocketName = flight["rocket"]["rocket_name"];
            bool isFlightUpcoming = flight["upcoming"];
            
            int numberOfPayloads= 0;
            foreach (JSONNode payload in flight["rocket"]["second_stage"]["payloads"])
            {
                numberOfPayloads += 1;
            }

            /*------------------Get data from one rocket API------------------*/
            string rocketID = flight["rocket"]["rocket_id"];
            string requestURL = oneRocketURL + rocketID;
            Debug.Log(requestURL);
            UnityWebRequest rocketInfoRequest = UnityWebRequest.Get(requestURL);
            yield return rocketInfoRequest.SendWebRequest();

            if (rocketInfoRequest.isNetworkError || rocketInfoRequest.isHttpError)
            {
                Debug.LogError(rocketInfoRequest.error);
                yield break;
            }
            JSONNode rocketInfoFromWeb = JSON.Parse(rocketInfoRequest.downloadHandler.text);
            string countryOfOrigin = rocketInfoFromWeb["country"];

            viewPopulator.Populate(missionName, rocketName, numberOfPayloads, countryOfOrigin,isFlightUpcoming, flightNumber);          
        }
        loadingMessage.SetActive(false);
    }    
}
