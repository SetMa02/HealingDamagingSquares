using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
[RequireComponent(typeof(Player))]
public class Beam : MonoBehaviour
{
    [SerializeField] private LineRenderer _lazerBeam;
    [SerializeField] private float _value;
    [SerializeField] private float _force;
    [SerializeField] private float _tick;
    [SerializeField] private Color _lineColor;

    private IEnumerator _castBeamCourutine;
    private IEnumerator _castEffectCourutine;
    private Movement _player;
    
    private void Start()
    {
        _lazerBeam = GetComponent<LineRenderer>();
        _player = GetComponent<Movement>();
        _lazerBeam.enabled = false;
    }
    
    private void FixedUpdate()
    {
        TryCastBeam();
    }

    public void StopBeaming()
    {
        _lazerBeam.enabled = false;
        if (_castBeamCourutine != null && _castEffectCourutine != null)
        {
            StopCoroutine(_castBeamCourutine);
            StartCoroutine(_castEffectCourutine);
        }
    }

    private void TryCastBeam()
    {
        if (Input.GetMouseButton(0))
        {
            RaycastHit2D[] hit2D = Physics2D.RaycastAll(transform.position, 
                Camera.main.ScreenToWorldPoint(Input.mousePosition));
            
            Debug.DrawLine(transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition), Color.red);
            
            if (hit2D != null)
            {
                foreach (var hit in hit2D)
                {
                    Debug.Log(hit.transform.name);
                    
                    if (hit.collider.gameObject.TryGetComponent<Enemy>(out Enemy enemy))
                    {
                        _lazerBeam.enabled = true;
                        _lazerBeam.startColor = _lineColor;
                        _lazerBeam.endColor = _lineColor;

                        _castBeamCourutine = CastBeam(hit);
                        _castEffectCourutine = CastEffect(enemy);
                        
                        StartCoroutine(_castBeamCourutine);
                        StartCoroutine(_castEffectCourutine);
                    }
                }
            }
        }
    }

    private IEnumerator CastEffect( Enemy enemy)
    {
        while (true)
        {
            enemy.ChangeHealth(_value);
            enemy.AddForce(_force, _player.transform.position);
            yield return new WaitForSeconds(_tick);
        }
    }

    private IEnumerator CastBeam(RaycastHit2D hit)
    {
        while (true)
        {
            _lazerBeam.SetPosition(0, transform.position);
            _lazerBeam.SetPosition(1, hit.point);
            yield return null;
        }
        
    }
}
