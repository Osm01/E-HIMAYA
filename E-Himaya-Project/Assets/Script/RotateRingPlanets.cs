using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateRingPlanets : MonoBehaviour
{
    [SerializeField] Vector3 R_vector3;
    private void Update()
    {
        transform.Rotate(R_vector3 * Time.deltaTime);
    }
}
