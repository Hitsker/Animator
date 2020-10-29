using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterSimulation : MonoBehaviour
{
    public float WaterDensity = 10f;
    private Rigidbody _rigitbody;

    private void Awake()
    {
        _rigitbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        float divePercent = -transform.position.y + transform.localScale.x + 0.5f;
        divePercent = Mathf.Clamp(divePercent, 0f, 1f);
        
        _rigitbody.AddForce(Vector3.up*divePercent*WaterDensity);
        _rigitbody.drag = divePercent * 2f;
        _rigitbody.angularDrag = divePercent * 2f;
    }
}
