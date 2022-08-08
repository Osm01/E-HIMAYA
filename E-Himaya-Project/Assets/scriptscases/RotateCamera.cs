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

    bool shouldRotate = true;

    private void Start()
    {
        StartCoroutine(enumeratFunction());
    }
    // Update is called once per frame
    void Update()
    {
        // Rotate();
        
        if (Cam1.transform.eulerAngles.y <= 360f && Cam1.transform.eulerAngles.y > 358f)
        {
            shouldRotate = false;
           // StopCoroutine(enumeratFunction());
        }
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
        else if (Time.time >= 5f && Time.time < 17.75f)
        {
            switchCAM2 = true;
        }
        else if (Time.time >= 17.75f && Time.time < 50f)
        {
            
            switchCAM3 = true;
        }
        if(switchCAM4)
        {
            Debug.LogError("Hello sara");
        }
      
    }
    IEnumerator enumeratFunction()
    {
        while (shouldRotate) { 
            Cam1.transform.Rotate(Vector3.up, SpeedRotate*Time.deltaTime);
            yield return new WaitForSeconds(0f);
        }
        if(!shouldRotate)
        {
            if(Cam1.transform.eulerAngles.y > 358f)
            {
                switchCAM2 = true;
                yield return new WaitForSeconds(17.75f);
                switchCAM3 = true;
                yield return new WaitForSeconds(50f);
            }
        }
    }
}

