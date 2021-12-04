using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeFogChanger : MonoBehaviour
{
    [SerializeField]
    private ToD_Base _TimeOfDay;
    [SerializeField]
    private Material[] _ToApply;

    [SerializeField]
    private Color _DayFog;
    [SerializeField]
    private Color _NightFog;

    void Awake()
    {

    }

    void Update()
    {
        float time = _TimeOfDay.Get_fCurrentTimeOfDay;
        Color c;
        if (time > 0.5)
            c = Color.Lerp(_DayFog, _NightFog, time);
        else
            c = Color.Lerp(_NightFog, _DayFog, time);
        foreach(Material mat in _ToApply)
            mat.SetColor("_FogColor", c);
    }
}
