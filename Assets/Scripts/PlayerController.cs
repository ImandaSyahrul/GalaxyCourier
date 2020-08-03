﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private Collider col;
    private float _speed = 30f;
    private float counter;
    private float rad = 0.4f;
    [SerializeField] private Transform center;

    // Awake is called when object instantiated
    void Awake()
    {
        col = GetComponent<Collider>();
        rb = GetComponent<Rigidbody>();    
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        if (Input.GetAxis("Horizontal") != 0)
        {
            transform.RotateAround(center.position, new Vector3( 0, 0, Input.GetAxis("Horizontal")), _speed * Time.deltaTime);
        }
        
    }
}