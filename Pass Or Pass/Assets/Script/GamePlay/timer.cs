using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public TMP_Text timerText;
    private DateTime currentTime;
    private DateTime endTime;
    public int dayCount = 1;
   
    public static Timer Instance;
    private void Awake()
    {   if (Instance == null)
        Instance = this; 
    }
    private void Start()
    {
      

        currentTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 8, 30, 0);
        UpdateTimerText();

        endTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 17, 30, 0);

        StartCoroutine(IncrementTime());
    }

    private IEnumerator IncrementTime()
    {
        while (currentTime != endTime)
        {

            yield return new WaitForSecondsRealtime(0.03f);



            currentTime = currentTime.AddSeconds(5);
            UpdateTimerText();
        }
        if (currentTime == endTime)
        {
            Debug.Log("Time is Up");
            Asiner.Instince.EndGame();
        }
    }

    private void UpdateTimerText()
    {

        timerText.text = currentTime.ToString("HH:mm");
    }
}