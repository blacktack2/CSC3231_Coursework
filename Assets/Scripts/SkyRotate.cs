using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyRotate : MonoBehaviour
{
    [SerializeField]
    private Camera _SkyboxCam;
    [SerializeField]
    private float _DayPeriod = 1.0f;

    void FixedUpdate()
    {
        _SkyboxCam.transform.RotateAround(_SkyboxCam.transform.position, _SkyboxCam.transform.right, Time.fixedDeltaTime * 360 / _DayPeriod);
    }
}
