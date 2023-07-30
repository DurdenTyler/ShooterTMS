using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private Transform _shootPoint;
    
    [SerializeField] private float _power = 5;

    [SerializeField] private float _damage = 20;

    [SerializeField] private GameObject _particleSystem;
    
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(_shootPoint.position, _shootPoint.forward, out var hit))
            {
                var rigidbody = hit.transform.gameObject.GetComponent<Rigidbody>();

                Instantiate(_particleSystem, hit.point, Quaternion.LookRotation(hit.normal, Vector3.up));

                if (rigidbody == null)
                {
                    return;
                }
                else
                {
                    rigidbody.AddForce(transform.forward * _power, ForceMode.Impulse);
                }

                var distractObject = hit.transform.gameObject.GetComponent<DistructionObject>();

                if (distractObject != null)
                {
                    distractObject.ReceiveDamage(_damage);
                }
                
                
            }
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        
        Gizmos.DrawRay(_shootPoint.position, _shootPoint.forward * 9999);
    }
}
