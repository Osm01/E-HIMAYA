using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolarSystem : MonoBehaviour
{
    GameObject[] Planets;
    readonly float G = 100f;
    public float SpeedRotate;
    void Start()
    {
        Planets = GameObject.FindGameObjectsWithTag("Planets");
    }

    private void Update()
    {
        RotateObject();
    }
    void PhysicSystem()
    {
        foreach (GameObject a in Planets)
        {
            foreach (GameObject b in Planets)
            {
                if (!a.Equals(b))
                {
                    float m1 = a.GetComponent<Rigidbody>().mass;
                    float m2 = b.GetComponent<Rigidbody>().mass;
                    float r = Vector3.Distance(a.transform.position, b.transform.position);
                    a.GetComponent<Rigidbody>().AddForce((b.transform.position - a.transform.position).normalized * (G * (m1 * m2) / (r * r)));
                    Debug.Log(r);
                }
            }
        }
    }
    void initialvelocity()
    {
        foreach(GameObject a in Planets)
        {
            foreach(GameObject b in Planets)
            {
                if(!a.Equals(b))
                {
                    float m2 = b.GetComponent<Rigidbody>().mass;
                    float r = Vector3.Distance(a.transform.position, b.transform.position);
                    a.transform.LookAt(b.transform);
                    a.GetComponent<Rigidbody>().velocity += a.transform.right * Mathf.Sqrt((G * m2) / r);
                }
            }
        }
    }
    void RotateObject()
    {
        foreach (GameObject a in Planets)
        {
            if (a.Equals(GameObject.Find("Sun")))
            {
                a.transform.Rotate(new Vector3(0, SpeedRotate, 0) * Time.deltaTime);
            }
            if (a.Equals(GameObject.Find("Mercury")))
            {
                GameObject Sun = GameObject.Find("Sun");
                a.transform.RotateAround(Sun.transform.position, Vector3.up,SpeedRotate * Time.deltaTime);
            }

        }
    }
}
