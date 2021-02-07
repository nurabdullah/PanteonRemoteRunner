using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingPlatformSpinner : MonoBehaviour
{
    public Vector3 rotation;
    
    Rigidbody _rigidbody;
    
    Vector3 rot;
    
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.centerOfMass = Vector3.zero;
        rot = transform.eulerAngles;
    }
    
    void FixedUpdate()
    {
        rot += Time.fixedDeltaTime * rotation;
        _rigidbody.MoveRotation(Quaternion.Euler(rot));
    }

   
}
