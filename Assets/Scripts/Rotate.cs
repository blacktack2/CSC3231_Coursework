using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField]
    private float _RotatePeriod = 1.0f;
    
    void FixedUpdate()
    {
        transform.RotateAround(transform.position, transform.up, Time.fixedDeltaTime * 360 / _RotatePeriod);
    }
}
