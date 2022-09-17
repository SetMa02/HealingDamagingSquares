using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]
public class Enemy : MonoBehaviour
{   
    [SerializeField] private float _maxHealth;
    private float _health;
    private Rigidbody2D _rigidbody;
    
    private void Start()
    {
        _health = _maxHealth;
        _rigidbody = GetComponent<Rigidbody2D>();
    }
    
    private void FixedUpdate()
    {
        if (_health <= 0)
        {
            Die();
        }
    }
    
    public void ChangeHealth(float value)
    {
        _health = Math.Clamp(_health + value, 0, _maxHealth);
    }

    public void AddForce(float force, Vector3 direction)
    {
        transform.position = Vector3.MoveTowards(transform.position, direction, 
            force * Time.deltaTime);
    }
    
    private void Die()
    {
        gameObject.SetActive(false);
    }
}
