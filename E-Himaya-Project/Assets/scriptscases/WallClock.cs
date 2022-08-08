using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallClock : MonoBehaviour
{

    public GameObject secondHand;
    public GameObject minuteHand;
    public GameObject hourHand;
    public float  speed;
    string oldSeconds;
    //public AudioSource myAudioSource;
    //public float counter;
    void Update()
    {

        string seconds = System.DateTime.UtcNow.ToString("ss");


        if (seconds != oldSeconds)
        {
            UpdateTimer();
            
        }
        oldSeconds = seconds;
    }

    void UpdateTimer()
    {
       
        speed += 5f;
        int secondsInt = int.Parse(System.DateTime.UtcNow.ToString("ss"));
        int minutesInt = int.Parse(System.DateTime.UtcNow.ToString("mm"));
        int hoursInt = int.Parse(System.DateTime.UtcNow.ToLocalTime().ToString("hh"));
        print(hoursInt + " : " + minutesInt + " : " + secondsInt);
        speed += 10f;
        iTween.RotateTo(secondHand, iTween.Hash("z", secondsInt * 6  * -speed, "time", speed, "easetype", "easeOutQuint"));
        iTween.RotateTo(minuteHand, iTween.Hash("z", minutesInt * 6  * -speed, "time", speed, "easetype", "easeOutElastic"));
        float hourDistance = (float)(minutesInt) / 60f;
        iTween.RotateTo(hourHand, iTween.Hash("z", (hoursInt + hourDistance) * speed * 360 / 12 * -1, "time", 1, "easetype", "easeOutQuint"));

    }
        
}
