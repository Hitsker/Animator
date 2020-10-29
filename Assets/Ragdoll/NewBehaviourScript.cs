﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    public float maxDistance = 100.0f; 
    
    public float spring = 50.0f; 
    public float damper = 5.0f; 
    public float drag = 10.0f; 
    public float angularDrag = 5.0f; 
    public float distance = 0.2f; 
    public bool attachToCenterOfMass = false; 
 
    private SpringJoint springJoint; 
    
    void Update() 
    { 
        if(!Input.GetMouseButtonDown(0)) 
            return;

        if(!Physics.Raycast(mainCamera.ScreenPointToRay(Input.mousePosition), out var hit, maxDistance)) 
            return; 
        if(!hit.rigidbody || hit.rigidbody.isKinematic) 
            return; 
        
        if(!springJoint) 
        { 
            var go = new GameObject("Rigidbody dragger"); 
            Rigidbody body = go.AddComponent<Rigidbody>(); 
            body.isKinematic = true; 
            springJoint = go.AddComponent<SpringJoint>(); 
        } 
        
        springJoint.transform.position = hit.point; 
        if(attachToCenterOfMass) 
        { 
            Vector3 anchor = transform.TransformDirection(hit.rigidbody.centerOfMass) + hit.rigidbody.transform.position; 
            anchor = springJoint.transform.InverseTransformPoint(anchor); 
            springJoint.anchor = anchor; 
        } 
        else 
        { 
            springJoint.anchor = Vector3.zero; 
        } 
        
        springJoint.spring = spring; 
        springJoint.damper = damper; 
        springJoint.maxDistance = distance; 
        springJoint.connectedBody = hit.rigidbody; 
        
        StartCoroutine(DragObject(hit.distance)); 
    } 
    
    IEnumerator DragObject(float distance) 
    { 
        float oldDrag             = springJoint.connectedBody.drag; 
        float oldAngularDrag     = springJoint.connectedBody.angularDrag; 
        springJoint.connectedBody.drag             = this.drag; 
        springJoint.connectedBody.angularDrag     = this.angularDrag;
        Camera cam = mainCamera;
        
        while(Input.GetMouseButton(0)) 
        { 
            Ray ray = cam.ScreenPointToRay(Input.mousePosition); 
            springJoint.transform.position = ray.GetPoint(distance); 
            yield return null; 
        } 
        
        if(springJoint.connectedBody) 
        { 
            springJoint.connectedBody.drag             = oldDrag; 
            springJoint.connectedBody.angularDrag     = oldAngularDrag; 
            springJoint.connectedBody                 = null; 
        } 
    }
}
