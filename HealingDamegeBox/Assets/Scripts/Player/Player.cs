using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField]private Beam _damageBeam;
    [SerializeField]private Beam _healBeam;
    
    private Beam _currentBeam;
    public Beam CurrentBeam => _currentBeam;

    private void Start()
    {
        _currentBeam = _damageBeam;
    }

    private void FixedUpdate()
    {
        MagicSwitch();
    }

    private void MagicSwitch()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            StopBeaming();
            _currentBeam = _damageBeam;
            Debug.Log("Damage mode");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            StopBeaming();
            _currentBeam = _healBeam;
            Debug.Log("Heal mode");
        }
    }

    public void StopBeaming()
    {
        if (_currentBeam.enabled == true)
        {
            _currentBeam.enabled = false;
            _currentBeam.StopBeaming();
        }
    }

    public void EnableBeaming()
    {
        CurrentBeam.enabled = true;
    }
}
