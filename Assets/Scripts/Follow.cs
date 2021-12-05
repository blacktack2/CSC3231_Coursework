using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    [SerializeField]
    private Transform _Target;

    [Serializable]
    public struct PositionArgs
    {
        public bool x;
        public bool y;
        public bool z;
    }
    [SerializeField]
    private PositionArgs _FollowPosition;
    [SerializeField]
    private PositionArgs _FollowRotation;
    [SerializeField]
    private PositionArgs _FollowScale;
    
    void FixedUpdate()
    {
        Vector3 newPos = transform.position;
        if (_FollowPosition.x)
            newPos.x = _Target.position.x;
        if (_FollowPosition.y)
            newPos.y = _Target.position.y;
        if (_FollowPosition.z)
            newPos.z = _Target.position.z;
        transform.position = newPos;

        Vector3 newRot = transform.eulerAngles;
        if (_FollowRotation.x)
            newRot.x = _Target.eulerAngles.x;
        if (_FollowRotation.y)
            newRot.y = _Target.eulerAngles.y;
        if (_FollowRotation.z)
            newRot.z = _Target.eulerAngles.z;
        transform.eulerAngles = newRot;

        Vector3 newSca = transform.localScale;
        if (_FollowScale.x)
            newSca.x = _Target.localScale.x;
        if (_FollowScale.y)
            newSca.y = _Target.localScale.y;
        if (_FollowScale.z)
            newSca.z = _Target.localScale.z;
        transform.localScale = newSca;
    }
}
