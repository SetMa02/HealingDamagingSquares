using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{   
    [SerializeField] private float _maxHealth;
    private float _health;
    
    private void Start()
    {
        _health = _maxHealth;
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
        _health = Math.Clamp(value, 0, _maxHealth);
    }

    public void Heal(float value)
    {
        ChangeHealth(value);
    }

    public void Damage(float value)
    {
        ChangeHealth(-value);
    }
    
    private void Die()
    {
        gameObject.SetActive(false);
    }
}
