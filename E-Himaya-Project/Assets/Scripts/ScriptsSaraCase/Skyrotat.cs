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
    public GameObject Cam1;
    bool CameraPreiority = true;
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
        if (Time.timeSinceLevelLoad <= 5)
        {
            if (_timer < Time.timeSinceLevelLoad)
            {
                _timer = Time.timeSinceLevelLoad + 0.08f;
                Color lerpedColor = Color.white;
                lerpedColor = Color.Lerp(Color.white, Color.black, Mathf.Sin(Time.timeSinceLevelLoad));

                RenderSettings.skybox.SetColor("_Tint", lerpedColor);
            }

        }
        else if(Time.timeSinceLevelLoad >= 5f && Time.timeSinceLevelLoad < 16f)
        {
            switchCAM2 = true;
        }
        else if (Time.timeSinceLevelLoad >= 16f && Time.timeSinceLevelLoad < 19)
        {
            switchCAM3 = true;
        }
        else if (Time.timeSinceLevelLoad >= 19)
        {
            switchCAM4 = true;
        }


    
    }
}
