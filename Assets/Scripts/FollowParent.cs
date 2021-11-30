using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowParent : MonoBehaviour
{
    [Serializable]
    public struct DisableTransform
    {
        public bool x;
        public bool y;
        public bool z;
    }
    [SerializeField]
    private DisableTransform _DisableTransform;
    [Serializable]
    public struct DisableRotation
    {
        public bool x;
        public bool y;
        public bool z;
    }
    [SerializeField]
    private DisableRotation _DisableRotation;

    private Transform _Target;
    private Vector3 _Offset;

    void Awake()
    {
        _Target = transform.parent;
        _Offset = transform.localPosition;
        transform.SetParent(null);
    }

    void FixedUpdate()
    {
        transform.position = _Target.position + _Offset;
        Vector3 newPos = transform.position;
        if (!_DisableTransform.x)
            newPos.x = _Target.position.x;
        if (!_DisableTransform.y)
            newPos.y = _Target.position.y;
        if (!_DisableTransform.x)
            newPos.z = _Target.position.z;
        transform.position = newPos;
        
        Vector3 newRot = transform.eulerAngles;
        if (!_DisableRotation.x)
            newRot.x = _Target.eulerAngles.x;
        if (!_DisableRotation.y)
            newRot.y = _Target.eulerAngles.y;
        if (!_DisableRotation.x)
            newRot.z = _Target.eulerAngles.z;
        transform.eulerAngles = newRot;
    }
}
