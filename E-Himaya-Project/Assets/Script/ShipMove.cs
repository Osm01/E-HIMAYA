using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class ShipMove : MonoBehaviour
{
    [SerializeField] Transform SpaceShip;
    [SerializeField] Transform SystelSolor;
    [SerializeField] CinemachineVirtualCamera Cam2;
    [SerializeField] CinemachineVirtualCamera Cam3;
    [SerializeField] float SpeedtoMove;
    bool switchCamera = false;
    int helper = 0;
    public float dis;
    
    IEnumerator Fun_SwitchCamera()
    {
        Cam2.Priority = 11;
       yield return new WaitForSeconds(4);
        Cam3.Priority = Cam2.Priority + 1;
    }
    private void FixedUpdate()
    {
        //Move Ship

        if (Vector3.Distance(SpaceShip.position, SystelSolor.position) < dis)
        {
            this.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
            switchCamera = true;
            helper++;
        }else
        {
            transform.Translate(Vector3.forward * SpeedtoMove);
        }
        if (switchCamera && helper == 1)
        {
            StartCoroutine(Fun_SwitchCamera());
            switchCamera = false;
        }
    }
}
