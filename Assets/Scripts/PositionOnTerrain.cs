using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionOnTerrain : MonoBehaviour
{
    void Awake()
    {
        Reposition();
    }

    public void Reposition()
    {
        CharacterController cc = GetComponent<CharacterController>();
        if (cc)
            cc.enabled = false;
        Rigidbody rigidbody = GetComponent<Rigidbody>();
        Vector3 pos = transform.position;
        pos.y = Terrain.activeTerrain.SampleHeight(transform.position);
        transform.position = pos;
        if (cc)
            cc.enabled = true;
    }
}
