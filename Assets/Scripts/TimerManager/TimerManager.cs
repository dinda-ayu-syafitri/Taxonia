using UnityEngine;
using System;

public class TimerManager : MonoBehaviour
{
    public static TimerManager instance;

    public float totalTime = 10.0f; 
    private float currentTime;
    public event Action onTimeUp; 
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Found more than one Timer Manager in the scene.");
        }
        instance = this;
    }

    void Start()
    {
        currentTime = totalTime;
        InvokeRepeating("Countdown", 1.0f, 1.0f); 
    }

    void Countdown()
    {
        currentTime -= 1.0f;
        if (currentTime <= 0)
        {
            CancelInvoke("Countdown"); 
            if (onTimeUp != null)
            {
                onTimeUp(); 
            }
        }
    }

    public float GetCurrentTime()
    {
        return currentTime;
    }
}
