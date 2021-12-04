using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixedOrbit : MonoBehaviour
{
    [SerializeField]
    public Transform _Target;
    [SerializeField]
    public Vector3 _Axis;
    [SerializeField]
    public float _OrbitalPeriod = 1.0f;
    [SerializeField]
    public float _OrbitalRadius = 1.0f;

    [SerializeField]
    public bool _DoRotate = false;

    private Quaternion _Rotation = Quaternion.identity;

    void Start()
    {
        transform.position = (transform.position - _Target.position).normalized * _OrbitalRadius + _Target.position;
    }

    void FixedUpdate()
    {
        if (_DoRotate)
        {
            transform.RotateAround(_Target.position, _Axis, Time.fixedDeltaTime * 360 / _OrbitalPeriod);
        }
        else
        {
            transform.position = (transform.position - _Target.position).normalized * _OrbitalRadius + _Target.position;
            transform.position = RotatePointAroundPivot(transform.position, _Target.position, Quaternion.Euler(_Axis * Time.fixedDeltaTime * 360 / _OrbitalPeriod));
        }
    }

    private Vector3 RotatePointAroundPivot(Vector3 point, Vector3 pivot, Quaternion angle)
    {
        return angle * (point - pivot) + pivot;
    }
}
