using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class TimerController : Singleton<TimerController>
{
    public TMP_Text timerText; // Riferimento all'elemento di testo TMP per mostrare il timer
    public TMP_Text survivedTimeText; // Riferimento all'elemento di testo TMP per mostrare il survivedTime
    public bool IsNight = false;
    public float dayDuration; // Durata del gioco in secondi
    public float dayTimer;
    public float nightDuration;
    public float nightTimer;
    public float survivedTime;
    public bool changingEra;
    public bool latestEra;

    private void Start()
    {
        ResetDayTimer();
        ResetNightTimer();
        changingEra = false;
        latestEra = false;
    }

    private void ResetDayTimer()
    {
        dayTimer = dayDuration;
    }
    private void ResetNightTimer()
    {
        nightTimer = nightDuration;
    }

    private void Update()
    {

        if (changingEra == false )
        {
            

            if (!IsNight)
            {
                dayTimer -= Time.deltaTime;
                timerText.text = "Night in: " + Mathf.RoundToInt(dayTimer).ToString();
                if (dayTimer <= 0f)
                {
                    IsNight = true;
                    ResetDayTimer();
                    Debug.Log("Notte");
                }
            }
            else
            {
                nightTimer -= Time.deltaTime;
                timerText.text = "Day in: " + Mathf.RoundToInt(nightTimer).ToString();
                if (nightTimer <= 0f )
                {
                    IsNight = false;
                    changingEra = true;
                    ResetNightTimer();
                }
               
            }

            survivedTime += Time.deltaTime;
            // Aggiorna il testo del timer
            survivedTimeText.text = "Survived for: " + Mathf.RoundToInt(survivedTime).ToString() + " s";
        }
        if (latestEra)
        {

            timerText.text = "Need to Die";
            survivedTime += Time.deltaTime;
            survivedTimeText.text = "Survived for: " + Mathf.RoundToInt(survivedTime).ToString() + " s";
        }

    }
}


