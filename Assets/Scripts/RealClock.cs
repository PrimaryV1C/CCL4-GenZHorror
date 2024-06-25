using UnityEngine;
using System;
using UnityEngine.Events;

public class RealClock : MonoBehaviour {
    public Transform Hours;
    public Transform Minutes;
    public Transform Seconds;
    private DateTime initialTime;
    private TimeSpan startTimeOffset;

    private float startHour = 11;
    private float startMinute = 59;
    private float startSecond = 50;
    void Start () {
        //startTimeOffset = new TimeSpan((int)startHour, (int)startMinute, (int)startSecond);

        initialTime = DateTime.Now;
    }

    void Update () {
        TimeSpan elapsedTime = DateTime.Now - initialTime;

        //TimeSpan currentTime = startTimeOffset + elapsedTime;
        TimeSpan currentTime = startTimeOffset + elapsedTime;

        float hour = currentTime.Hours % 12; 
        float minute = currentTime.Minutes;
        float second = currentTime.Seconds + (float)currentTime.Milliseconds / 1000;

        hour += minute / 60f;
        minute += second / 60f;

        if (Hours)
            Hours.localRotation = Quaternion.Euler(0, 0, hour / 12 * 360); 

        if (Minutes)
            Minutes.localRotation = Quaternion.Euler(0, 0, minute / 60 * 360); 

        if (Seconds)
            Seconds.localRotation = Quaternion.Euler(0, 0, second / 60 * 360);
    }
}
