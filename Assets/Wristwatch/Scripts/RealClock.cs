using UnityEngine;
using System;

public class RealClock : MonoBehaviour {
    public Transform Hours;
    public Transform Minutes;
    public Transform Seconds;

    private DateTime initialTime;
    private TimeSpan startTimeOffset;

    private float startHour = 11;
    private float startMinute = 57;
    private float startSecond = 0;

    // Use this for initialization
    void Start () {
        // Initialize startTimeOffset to ensure the clock starts at 11:57:00
        startTimeOffset = new TimeSpan((int)startHour, (int)startMinute, (int)startSecond);

        // Store the initial time when the game starts
        initialTime = DateTime.Now;
    }

    // Update is called once per frame
    void Update () {
        // Calculate the elapsed time since the game started
        TimeSpan elapsedTime = DateTime.Now - initialTime;

        // Calculate the current time on the clock
        TimeSpan currentTime = startTimeOffset + elapsedTime;

        // Extract hours, minutes, and seconds from the current time
        float hour = currentTime.Hours % 12; // Ensure hours stay within 0-11 range
        float minute = currentTime.Minutes;
        float second = currentTime.Seconds + (float)currentTime.Milliseconds / 1000;

        // Smooth hour and minute hand movements
        hour += minute / 60f;
        minute += second / 60f;

        // Update the rotations of the clock hands
        if (Hours)
            Hours.localRotation = Quaternion.Euler(0, 0, hour / 12 * 360); // Positive direction

        if (Minutes)
            Minutes.localRotation = Quaternion.Euler(0, 0, minute / 60 * 360); // Positive direction

        if (Seconds)
            Seconds.localRotation = Quaternion.Euler(0, 0, second / 60 * 360); // Positive direction
    }
}
