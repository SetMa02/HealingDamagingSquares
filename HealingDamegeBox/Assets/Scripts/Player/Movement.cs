using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Player))]
public class Movement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _rotateSpeed;
    
    private Rigidbody2D _rigidbody;
    private Player _player;

    private void Start()
     {
         _rigidbody = GetComponent<Rigidbody2D>();
         _player = GetComponent<Player>();
     }

     private void FixedUpdate()
    {
        BeamingCheck();
        TryRotate();
        TryMove();
        
    }

     private void BeamingCheck()
     {
         if (_player.CurrentBeam.enabled == true)
         {
             _player.StopBeaming();
         }
     }
     
    private void TryRotate()
    {
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0,0,-_rotateSpeed,Space.Self); 
        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0,0,_rotateSpeed,Space.Self);
        }
        else
        {
            _player.EnableBeaming();
        }
        
    }

    private void TryMove()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += transform.up * _speed * Time.deltaTime;
        }
        else
        {
            _player.EnableBeaming();
        }
        
    }
}
