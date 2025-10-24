using TMPro;
using UnityEngine;
using UnityEngine.Rendering;

public class SpeedrunTimer : MonoBehaviour
{
    public TextMeshProUGUI TimerText;
    public float Timer;
    public float Minutes;
    public string TextMinutes;
    public float Hours;
    public string TextHours;
    public string TotalTime;

    public bool TimerRun = true;

    //public string HoursPart;
    //public string MinutesPart;
    void Start()
    {
        
    }

    void Update()
    {

        if (TimerRun)
        {
            Timer = Timer + Time.deltaTime;
            TimerText.color = new Color(0.25f,1,0.25f);
        }
        if (TotalTime == "0,00")
        {
            TimerText.color = Color.white;
        }
        else if (TotalTime != "0,00" & !TimerRun)
        {
            TimerText.color = new Color(0, 0.683733f, 1);
        }
        else if (Timer >= 60)
        {
            Timer = Timer - 60;
            Minutes = Minutes + 1;
        }

        if (Minutes == 0 & Hours == 0)
        {
            TextMinutes = null;
        }
        else if (Minutes == 0 & Hours > 0)
        {
            TextMinutes = "0:";
        }
        /*else if (Minutes < 10 & Minutes > 0)
        {
            TextMinutes = "0" + Minutes + ":";
        }*/
        else if (Minutes > 0)
        {
            TextMinutes = Minutes.ToString() + ":";
        }

        if (Hours == 0)
        {
            TextHours = null;
        }
        if (Minutes == 60)
        {
            Minutes = Minutes - 60;
            Hours = Hours + 1;
        }
        if (Hours > 0)
        {
            TextHours = Hours.ToString() + ":";
        }
        TotalTime = TextHours + TextMinutes + Timer.ToString("F2");

        TimerText.text = TotalTime;
    }
}
