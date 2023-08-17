using UnityEngine;
using TMPro;

public class DayTimeManager : MonoBehaviour
{
    [SerializeField] private TMP_Text dayText;
    [SerializeField] private TMP_Text timeText;
    [SerializeField] private float currentTime = 720; // 12 * 60

    public bool timerIsRunning = false;

    public static DayTimeManager Instance;

    void Start()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }

        // Day and Time update
        // dayText.text = UpdateDay(); // do not exist for now
        timeText.text = "12:00 AM";

        StartTimer();
    }

    void Update()
    {
        if (timerIsRunning)
        {
            if (currentTime / 60 < 18)
            {
                currentTime += Time.deltaTime;
                DisplayTime(currentTime);
            }
            else
            {
                Debug.Log("Time has run out!");
                currentTime = 0;
                timerIsRunning = false;
            }
        }
    }
    
    public void StartTimer()
    {
        timerIsRunning = true;
    }

    public void StopTimer()
    {
        timerIsRunning = false;
    }

    void DisplayTime(float timeToDisplay)
    {
        float hours = Mathf.FloorToInt(timeToDisplay / 60);
        float minutes = Mathf.FloorToInt(timeToDisplay % 60);
        timeText.text = string.Format("{0:00}:{1:00} AM", hours, minutes);
    }
}
