using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    private Animator _animator;
    private Rigidbody _rigidbody;

    private float inputHorizontal;
    private float inputVertical;

    public float moveSpeed;
    public float rotationSpeed;

    public GameObject paint;
    public GameObject mainCam;

    [HideInInspector] public bool isFail;
    
    private void Start()
    {
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (GameManager.Manager.currentGameState == GameState.OnGamePlay)
        {
            if (Input.GetMouseButton(0))
            {
                _animator.SetBool("isRunning",true);
            }

            if (Input.GetMouseButtonUp(0))
            {
                _animator.SetBool("isRunning",false);
            }
        }

        if (isFail)
        {
            transform.position = new Vector3(0f, 0.976f, 11.79f);
            isFail = false;
        }

    }
    
    private void FixedUpdate()
    {
        if (GameManager.Manager.currentGameState == GameState.OnGamePlay)
        {
            if (Input.GetMouseButton(0))
            {
                MoveJoystick();
                LookJoystick();
            }
        }
    }

    private void MoveJoystick()
    {
        inputHorizontal = SimpleInput.GetAxis("Horizontal");
        inputVertical = SimpleInput.GetAxis("Vertical");

        Vector3 mov = new Vector3(inputHorizontal * moveSpeed, 0, inputVertical * moveSpeed);
        //_characterController.Move(mov * Time.deltaTime);
        _rigidbody.MovePosition(transform.position + mov * Time.deltaTime);
    }

    private void LookJoystick()
    {
        Vector3 direction = new Vector3(inputHorizontal, 0, inputVertical).normalized;
        Quaternion rotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation,  rotationSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Finish"))
        {
            GameManager.Manager.currentGameState = GameState.OnGameFinish;
            mainCam.SetActive(false);
            paint.SetActive(true);
        }
    }
}
