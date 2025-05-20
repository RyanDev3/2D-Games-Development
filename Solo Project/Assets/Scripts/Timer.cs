using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Timer : MonoBehaviour
{
    [Header("Component")]
    public TextMeshProUGUI timerText;

    [Header("Timer Settings")]
    public float currentTime;
    public bool countDown;

    void Update()
    {
        if (Time.timeScale == 0f) return;

        currentTime = countDown ? currentTime -= Time.deltaTime : currentTime += Time.deltaTime;

        if (countDown && currentTime < 0)
            currentTime = 0;

        UpdateTimerDisplay();
        TimerEnd();
    }

    private void UpdateTimerDisplay()
    {
        int minutes = Mathf.FloorToInt(currentTime / 60f);
        int seconds = Mathf.FloorToInt(currentTime % 60f);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    void TimerEnd()
    {
        if (currentTime > 120) 
            SceneManager.LoadScene("EndScreen");
            else if (currentTime > 0)
                Console.WriteLine("Ur Stupid");
        return;
    }
}