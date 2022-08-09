using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DayNight : MonoBehaviour
{
    public float time;
    public TimeSpan currenttime;
    public Transform Suntransform;
    public Light Sun;
    public Text TimeText;
    public int days;
    public float intensity;
    public Color fogday = Color.white;
    public Color fognight = Color.black;
    public int speed; 
    

   
     void Update()
    {
        ChangeTime();
    }
    public void ChangeTime()
    {
        time += Time.deltaTime * (speed / 2);
        if(time > 86400)
        {
            days += 1;
            time = 0;
        }
        currenttime = TimeSpan.FromSeconds(time);
        string[] temptime = currenttime.ToString().Split(":"[0]);
        TimeText.text = temptime[0] + ":" + temptime [1];
        //Skybox<GameObject>transform.getcolor.color   = Quaternion.Euler(new Vector3((time - 21600)/86400*360,0,0));
        if (time < 43200)
        {
            intensity = 1 - (43200 - time) / 43200;
        }
        else
        {
            intensity =  1 - ((43200 - time) / 43200 *-1);
        }
        RenderSettings.fogColor = Color.Lerp(fognight, fogday, intensity * intensity);
        Sun.intensity = intensity;
    }
}
