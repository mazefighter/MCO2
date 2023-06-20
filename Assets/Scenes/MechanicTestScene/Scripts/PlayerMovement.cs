using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidBody;
    [SerializeField] private Transform _model;
    private float _speed = 5;
    private float _turnSpeed = 600;
    private Vector3 _input;
    [SerializeField] private Animator _animator;

    private bool isGrounded;

    private Vector3 lastGroundPos;
    
    private void Update()
    {
        if (transform.position.y < -2)
        {
            transform.position = lastGroundPos;
            transform.rotation = new Quaternion(0, 0, 0, 0);
        }
        GroundCheck();
        GatherInput();
        Look();
    }
    

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            lastGroundPos = transform.position;
        }
    }

    void GroundCheck()
    {
        RaycastHit hit;
        float distance = 1f;
        Vector3 dir = new Vector3(0, -1);

        if(Physics.Raycast(transform.position, dir, out hit, distance))
        {
            isGrounded = true;
            _animator.SetBool("Fly",!isGrounded);
        }
        else
        {
            isGrounded = false;
            _animator.SetBool("Fly",!isGrounded);
        }
    }

    private void FixedUpdate() {
        MovePlayer();
    }
    public void GatherInput()
    {
        _input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
    }
    private void Look() {
        if (_input == Vector3.zero) return;

        Quaternion rot = Quaternion.LookRotation(_input.ToIso(), Vector3.up);
        _model.rotation = Quaternion.RotateTowards(_model.rotation, rot, _turnSpeed * Time.deltaTime);
    }
    private void MovePlayer() {
        _animator.SetFloat("Velocity",_input.magnitude);
        _rigidBody.MovePosition(transform.position + _input.ToIso() * _input.normalized.magnitude * _speed * Time.deltaTime);
    }
}
