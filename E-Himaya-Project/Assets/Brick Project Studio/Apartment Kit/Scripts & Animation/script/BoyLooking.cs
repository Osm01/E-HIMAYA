using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;
public class BoyLooking : MonoBehaviour
{
    public MultiAimConstraint multiAim;
    public GameObject Girl;
    public float dis;
     float value;
    float valueCam;
    public static bool LookCamera;
    // Start is called before the first frame update
    void Start()
    {
        value = 0;
        valueCam = 0;
        LookCamera = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(!LookCamera)
        {
            if (Vector3.Distance(transform.position, Girl.transform.position) < dis)
            {
                Debug.Log("Hello");
                value += 0.01f;
                WeightedTransformArray weightedTransforms = multiAim.data.sourceObjects;
                weightedTransforms.SetWeight(0, 0f);
                weightedTransforms.SetWeight(1, value);
                multiAim.data.sourceObjects = weightedTransforms;
            }
        }else
        {
            valueCam += 0.007f;
            WeightedTransformArray weightedTransforms = multiAim.data.sourceObjects;
            weightedTransforms.SetWeight(0, 0f);
            weightedTransforms.SetWeight(1, 0f);
            weightedTransforms.SetWeight(2, valueCam);
            multiAim.data.sourceObjects = weightedTransforms;
        }
           
    }
}
