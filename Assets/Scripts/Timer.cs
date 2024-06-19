using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public float timerDuration = 60f;
    public bool startTimer = true;
    private float timeRemaining;
    private bool timerRunning = false;

    void Update()
    {
        if (startTimer && !timerRunning)
        {
            StartClock();
        }

        if (timerRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                UpdateTimerDisplay(timeRemaining);
            }
            else
            {
                timeRemaining = 0;
                timerRunning = false;
                TimerFinished();
            }
        }
    }

    void StartClock()
    {
        timeRemaining = timerDuration;
        timerRunning = true;
    }

    void UpdateTimerDisplay(float timeToDisplay)
    {
        if (timerText != null)
        {
            float minutes = Mathf.FloorToInt(timeToDisplay / 60);
            float seconds = Mathf.FloorToInt(timeToDisplay % 60);
            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }

    void TimerFinished()
    {
        Debug.Log("Timer has run out!");
    }
}