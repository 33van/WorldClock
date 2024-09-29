using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class WorldClock : MonoBehaviour
{
    const float hoursToDegrees = -30f, minutesToDegrees = -6f, secondsToDegrees = -6f;
    
    enum Location {NY , Tokyo, London, Sydney};
    [SerializeField] Location place;

    [SerializeField]
	Transform hoursPivot, minutesPivot, secondsPivot;

    // Update is called once per frame
    void Update () {

         float diff = 0f;
        
        switch (place)
        {
            case Location.NY:
                diff = -4f; 
                break;
            case Location.Tokyo:
                diff = 9f; 
                break;
            case Location.London:
                diff = 1f; 
                break;
            case Location.Sydney:
                diff = 10f; 
                break;
        }

        DateTime currentTime = DateTime.UtcNow.AddHours(diff);
        TimeSpan time = currentTime.TimeOfDay;

        Debug.Log(currentTime.Hour);
        hoursPivot.localRotation = Quaternion.Euler(0f, 0f, hoursToDegrees * (float)time.TotalHours);
        minutesPivot.localRotation = Quaternion.Euler(0f, 0f, minutesToDegrees * (float)time.TotalMinutes);
        secondsPivot.localRotation = Quaternion.Euler(0f, 0f, secondsToDegrees * (float)time.TotalSeconds);
	}
}
