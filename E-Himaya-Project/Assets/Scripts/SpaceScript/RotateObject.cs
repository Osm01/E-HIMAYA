using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    GameObject Sun;
    [SerializeField] float SpeedRotate;
    [SerializeField] GameObject[] Planets;
    void Start()
    {
        Sun = GameObject.Find("Sun");
    }

    // Update is called once per frame
    void Update()
    {
        Rotate();
    }
    void Rotate()
    {
        foreach(GameObject a in Planets)
        {
           if(!Planets.Equals(Sun))
           {
              a.transform.RotateAround(Sun.transform.position,Vector3.up,SpeedRotate * Time.deltaTime * a.GetComponent<Rigidbody>().mass);
           }
              
        }
    }
}
