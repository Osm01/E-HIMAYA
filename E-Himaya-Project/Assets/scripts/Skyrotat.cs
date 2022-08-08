using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skyrotat : MonoBehaviour
{
    public float speed;
    float _timer = 0f;
    [SerializeField] float LerpTimer;
    public bool switchCAM2 = false;
    public bool switchCAM3 = false;
    public bool switchCAM4 = false;
    void Update()
    {
        timeSwitch();
    }
    /*public void ChangeColor()
    {
       RenderSettings.skybox.SetColor("_Tint", Color.white);
        Debug.Log(RenderSettings.skybox.name);
        StartCoroutine(timeSwitch());
    }*/
    
     void timeSwitch()
    {
        if (Time.time <= 5)
        {
            if (_timer < Time.time)
            {
                _timer = Time.time + 0.08f;
                Color lerpedColor = Color.white;
                lerpedColor = Color.Lerp(Color.white, Color.black, Mathf.Sin(Time.time));

                RenderSettings.skybox.SetColor("_Tint", lerpedColor);
            }

        }
        else if(Time.time >= 5f && Time.time<16f)
        {
            switchCAM2 = true;
        }
        else if (Time.time >= 16f && Time.time < 19)
        {
            switchCAM3 = true;
        }
        else if (Time.time >= 19)
        {
            switchCAM4 = true;
        }


    }
}
