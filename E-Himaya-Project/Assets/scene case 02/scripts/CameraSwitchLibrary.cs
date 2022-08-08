using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraSwitchLibrary : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera Cam1;
    [SerializeField] CinemachineVirtualCamera Cam2;
    [SerializeField] CinemachineVirtualCamera Cam3;
    public CinemachineVirtualCamera Cam4;
    [SerializeField] GameObject CaseCanvas;
    [SerializeField] float SpeedtoMove;
    RotateCamera RotateCamera;
    //private GameObject Character;
    [SerializeField] GameObject CanvasDialog;
    int ShowOneTime = 0;
    public void Start()
    {
        RotateCamera = FindObjectOfType<RotateCamera>();
        CanvasDialog.SetActive(false);
        CaseCanvas.SetActive(false);
    }
    public void Update()
    {
        if (RotateCamera.switchCAM2 == true)
        {
            Cam2.Priority = Cam1.Priority + 1;

            //Character.GetComponent<Animator>().enable = true;
            //For stop the animation
            //Character.GetComponent<Animator>().enabled = false;
        }

        if (RotateCamera.switchCAM3 == true)
        {
            if (ShowOneTime != 0)
            {
                return;
            }
            Debug.Log("Im here");
            if (Time.time >= 30.17f && Time.time < 74.12f)
            {
                CanvasDialog.SetActive(true);
                ShowOneTime++;
            }

            Cam3.Priority = Cam2.Priority + 1;

        }
        if (RotateCamera.switchCAM4 == true)
        {
            CaseCanvas.SetActive(true);
        }
        Debug.Log("value of cam4 is :" + RotateCamera.switchCAM4);
    }

}
