using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _rotateSpeed;
    
    private void FixedUpdate()
    {
        TryRotate();
        TryMove();
    }

    private void TryRotate()
    {
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0,0,-_rotateSpeed,Space.Self); 
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0,0,_rotateSpeed,Space.Self);
        }
    }

    private void TryMove()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += transform.up * _speed * Time.deltaTime;
        }
    }
}
