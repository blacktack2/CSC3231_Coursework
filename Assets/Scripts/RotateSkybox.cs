using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateSkybox : MonoBehaviour
{
    [SerializeField]
    private float _Period;

    private float _Rotation;

    void FixedUpdate()
    {
        _Rotation += 360 * Time.fixedDeltaTime / _Period;
        while (_Rotation >= 360)
            _Rotation -= 360;
        RenderSettings.skybox.SetFloat("_Rotation", _Rotation);
    }
}
