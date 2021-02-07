using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Horizontal : MonoBehaviour
{
    [SerializeField] 
    private float MoveRange, Speed;
    Vector3 StartPos;
    Vector3 rot;
    public Vector3 _rotation;
    private Rigidbody _rigidbody;
    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.centerOfMass = Vector3.zero;
        rot = transform.eulerAngles;
        StartPos = transform.position;
    }

     void FixedUpdate()
     {
         rot += Time.fixedDeltaTime * _rotation;
         _rigidbody.MoveRotation(Quaternion.Euler(rot));
     }

    void Update()
    {
        Vector3 mov = StartPos;
        mov.x += MoveRange * Mathf.Sin(Time.time * Speed);
        transform.position = mov;
    }
}
