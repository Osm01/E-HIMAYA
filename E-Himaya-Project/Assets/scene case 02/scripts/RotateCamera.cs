using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    [SerializeField] GameObject Cam1;
    [SerializeField] float SpeedRotate;
    public bool switchCAM2 = false;
    public bool switchCAM3 = false;
    public bool switchCAM4 = false;
    

    // Update is called once per frame
    void Update()
    {
        Rotate();
    }
    void Rotate()
    {
        if (Time.time <= 5)
        {
            if (transform.rotation.y <= 360)
            {
                Cam1.transform.Rotate(Vector3.up, SpeedRotate * Time.deltaTime);
            }
        }
        else if (Time.time >= 5f && Time.time < 30.10f)
        {
            switchCAM2 = true;
        }
        else if (Time.time >= 30.10f && Time.time < 74.12f)
        {
            
            switchCAM3 = true;
        }
        if(switchCAM4)
        {
            Debug.LogError("Hello sara");
        }
      
    }
}

