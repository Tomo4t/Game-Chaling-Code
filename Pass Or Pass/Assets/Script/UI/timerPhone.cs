using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class TimerPhone : MonoBehaviour
{


    public TMP_Text timerText;
    private float elapsedTime = 0f;
    private int minutes = 30;
    private int hours = 17;

    void Start()
    {
        // Set initial timer display
        UpdateTimerDisplay();
        // Start the timer
        InvokeRepeating("IncreaseTime", 10f, 10f); // Invoke the method every 60 seconds
    }

    void UpdateTimerDisplay()
    {
        timerText.text = hours.ToString("00") + ":" + minutes.ToString("00");
    }

    void IncreaseTime()
    {
        elapsedTime += 60f; // Increase elapsed time by 60 seconds (1 minute)
        minutes++;
        if (minutes >= 60)
        {
            hours++;
            minutes = 0;
            if (hours >= 24)
            {
                hours = 0;
            }
        }
        UpdateTimerDisplay();
    }
}




