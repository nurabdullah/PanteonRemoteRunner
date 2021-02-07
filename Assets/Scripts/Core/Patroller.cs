using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patroller : MonoBehaviour
{
    public Transform[] wayPoints;
    public int speed;

    private int _wayPointIndex;
    private float _dist;

    private bool _isFinish;
    public bool _isFail;

    private Animator _animator;

    private Rigidbody _rb;

    void Start()
    {
        _wayPointIndex = 0;
        transform.LookAt(wayPoints[_wayPointIndex].position);
        _animator = GetComponent<Animator>();

        _rb = GetComponent<Rigidbody>();
    }


    void Update()
    {
        if (GameManager.Manager.currentGameState == GameState.OnGamePlay)
        {
            if (!_isFail)
            {
                Vector3 direction = Vector3.zero;
                if(Vector3.Distance(transform.position, wayPoints[_wayPointIndex].position) > 1f && !_isFinish)
                {
                    transform.LookAt(wayPoints[_wayPointIndex].position);
                    direction = (wayPoints[_wayPointIndex].position - transform.position).normalized * speed;
                    //_rb.velocity= direction;
                    transform.Translate(direction*Time.deltaTime);
                }
                else
                {
                    IncreaseIndex();
                }
        
                if(!_isFinish)
                    _animator.SetBool("isRunning", true);
            }
            else
            {
                transform.position = Vector3.zero;
                _wayPointIndex = 0;
                _isFail = false;
            }
        
            if (_wayPointIndex >= wayPoints.Length-1)
            {
                _isFinish = true;
                _animator.SetBool("isRunning", false);
                _rb.isKinematic = true;
            }   
        }
    }
    
    void IncreaseIndex()
    {
        _wayPointIndex++;
        transform.LookAt(wayPoints[_wayPointIndex].position);
    }
    
}

