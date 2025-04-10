using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class timerCounterDown : MonoBehaviour
{
    public float timeRemaining = 59f;
    public TMP_Text countdownText;
    private bool isRunning = true;

    void Update()
    {
        if (isRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                UpdateCountdownText();
            }
            else
            {
                timeRemaining = 0;
                isRunning = false;
                UpdateCountdownText();
                Debug.Log("Tempo acabou!");
            }
        }
    }
    void UpdateCountdownText()
    {
        countdownText.text = "0:" + timeRemaining.ToString("F0");
    }   
}