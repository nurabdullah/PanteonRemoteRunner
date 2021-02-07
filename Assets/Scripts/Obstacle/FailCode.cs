using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FailCode : MonoBehaviour
{
  
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
