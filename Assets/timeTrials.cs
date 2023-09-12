using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class timeTrials : MonoBehaviour
{

    public float timerTime;
    public bool timerControl;
    public TextMeshPro timerText;
    // Start is called before the first frame update
    void Start()
    {
        timerTime = 0.0f;
        timerControl = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (timerControl)
        {
            timerTime += Time.deltaTime;
            UpdateTimer();
        }
    }

    public void StartTimer()
    {
        timerControl = true;
    }

    public void EndTimer()
    {
        timerControl= false;
    }

    public void ResetTimer()
    {
        timerTime = 0.0f;
        timerText.text = timerTime.ToString("F2").Replace(".", ":");
    }

    void UpdateTimer()
    {
        if(timerTime < 60)
        {
            string workWithMe = timerTime.ToString("F2");
            timerText.text = workWithMe.Replace(".", ":");
        }
        else
        {
            int minutes = (int) timerTime / 60;
            int seconds = (int) timerTime % 60;
            string secString;
            if(seconds < 10) { secString = "0" + seconds; }
            else { secString = seconds.ToString(); }
            string workingString = minutes.ToString() + ":" + secString;
            timerText.text = workingString;
        }
    }
}
