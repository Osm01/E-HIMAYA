using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class TransitionCameras : MonoBehaviour
{
    DoorScript doorScript;
    public CinemachineVirtualCamera Cam2;
    public CinemachineVirtualCamera Cam3;
    public CinemachineVirtualCamera Cam4;
    bool switchCam3 = false;
     public bool switchCam4 = false;
    float _timer = 0;
    int inex=0;
    
    private void Start()
    {
        doorScript = FindObjectOfType<DoorScript>();
    }
    void Update()
    {
        if (doorScript.SwitchCam2)
        {
            Cam2.Priority = 11;
            switchCam3 = true;
        }
        if(switchCam3)
        {
            if(_timer < Time.timeSinceLevelLoad)
            {
                _timer = Time.timeSinceLevelLoad + 5;
                inex += 1;
                if(inex > 1)
                {
                    Cam3.Priority = 12;
                } 
            }
        }if(switchCam4)
        {
            Cam4.Priority = 14;
        }
    }
}
