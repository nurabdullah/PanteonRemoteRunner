using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinner : MonoBehaviour
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

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.GetComponent<Patroller>()._isFail = true;
        }
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<CharacterController>().isFail = true;
        }
    }
}
