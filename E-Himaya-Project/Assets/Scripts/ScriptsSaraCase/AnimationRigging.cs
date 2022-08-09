using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;
public class AnimationRigging : MonoBehaviour
{
    public MultiAimConstraint aimConstraint;
    public Transform nabih;
    public float difdistance;
    Skyrotat skyrotat;
    public bool ActiveQts;
    public float  speed;
    public float speed01;
    // Start is called before the first frame update
    void Start()
    {
        ActiveQts = false;
        skyrotat = FindObjectOfType<Skyrotat>();
        speed = 0f;
        speed01 = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if(!ActiveQts)
        {
            if (skyrotat.switchCAM4)
            {
                speed += 0.01f;
                WeightedTransformArray weightedTransforms = aimConstraint.data.sourceObjects;
                weightedTransforms.SetWeight(0, 0f);
                weightedTransforms.SetWeight(1, speed);
                weightedTransforms.SetWeight(2, 0f);
                aimConstraint.data.sourceObjects = weightedTransforms;
            }
        }
        else
        {
            speed01 += 0.01f;
            WeightedTransformArray weightedTransforms = aimConstraint.data.sourceObjects;
            weightedTransforms.SetWeight(0, 0f);
            weightedTransforms.SetWeight(1, 0f);
            weightedTransforms.SetWeight(2, speed01);
            aimConstraint.data.sourceObjects = weightedTransforms;
        }
        
        
    }
}
