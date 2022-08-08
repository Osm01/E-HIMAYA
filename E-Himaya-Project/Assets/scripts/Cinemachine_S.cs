using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class Cinemachine_S : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera Cam1;
    [SerializeField] CinemachineVirtualCamera Cam2;
    [SerializeField] CinemachineVirtualCamera Cam3;
    [SerializeField] CinemachineVirtualCamera Cam4;
    [SerializeField] float SpeedtoMove;
    Skyrotat skyrotat;
    //private GameObject Character;
    [SerializeField] GameObject CanvasDialog;
    int ShowOneTime = 0;
    public void Start()
    {
        skyrotat = FindObjectOfType<Skyrotat>();
        CanvasDialog.SetActive(false);
    }
    public void Update()
    {
        if(skyrotat.switchCAM2==true)
        {
            Cam2.Priority = Cam1.Priority + 1;
            
            //Character.GetComponent<Animator>().enable = true;
            //For stop the animation
            //Character.GetComponent<Animator>().enabled = false;
        }
        if (skyrotat.switchCAM3 == true)
        {
            Cam3.Priority = Cam2.Priority + 1;
        }
        if(skyrotat.switchCAM4 == true)
        {
            if(ShowOneTime!=0)
            {
                return;
            }
            CanvasDialog.SetActive(true);
            Cam4.Priority = Cam3.Priority + 1;
            ShowOneTime++;
        }


    }
    
}
