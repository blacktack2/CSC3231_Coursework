using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeHandler : MonoBehaviour
{
    [Serializable]
    public struct OrbitalObject
    {
        public GameObject toOrbit;
        public Vector3 orbitAxis;
        public float orbitPeriod;
        public float orbitRadius;
    }
    [SerializeField]
    private OrbitalObject[] _OrbitalObjects;
    [SerializeField]
    private GameObject[] _SkyObjects;
    [SerializeField]
    private ToD_Base _TimeOfDayHandler;

    [SerializeField]
    private float _DayPeriod = 60.0f;

    private float _TimeOfDay = 0.0f;

    void Awake()
    {
        Transform mainCamera = Camera.main.transform;
        foreach (GameObject skyObject in _SkyObjects)
        {
            FixedOrbit orbitConfig = skyObject.AddComponent<FixedOrbit>();
            orbitConfig._DoRotate = true;
            orbitConfig._Axis = new Vector3(1, 0, 0);
            orbitConfig._OrbitalPeriod = _DayPeriod;
            orbitConfig._Target = mainCamera;
        }
        foreach (OrbitalObject orbitalObject in _OrbitalObjects)
        {
            FixedOrbit orbitConfig = orbitalObject.toOrbit.AddComponent<FixedOrbit>();
            orbitConfig._DoRotate = false;
            orbitConfig._Axis = orbitalObject.orbitAxis;
            orbitConfig._OrbitalPeriod = orbitalObject.orbitPeriod;
            orbitConfig._OrbitalRadius = orbitalObject.orbitRadius;
            orbitConfig._Target = mainCamera;
        }
    }

    void Start()
    {
        _TimeOfDayHandler.GetSet_fSecondInAFullDay = _DayPeriod;
    }

    void Update()
    {

    }

    void FixedUpdate()
    {
        _TimeOfDay += 360 * Time.fixedDeltaTime / _DayPeriod;
        while (_TimeOfDay >= 360)
            _TimeOfDay -= 360;
        RenderSettings.skybox.SetFloat("_Rotation", _TimeOfDay);
    }
}
