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

    private Vector3 lastGroundPos;
    
    private void Update()
    {
        if (transform.position.y < -2)
        {
            transform.position = lastGroundPos;
            transform.rotation = new Quaternion(0, 0, 0, 0);
        }
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
        // if (_input.magnitude > 0)
        // {
        //     _animator.SetBool("Walking", true);
        // }
        // else
        // {
        //     _animator.SetBool("Walking", false);
        // }
        _rigidBody.MovePosition(transform.position + _input.ToIso() * _input.normalized.magnitude * _speed * Time.deltaTime);
    }
}
