using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Handgun : MonoBehaviour
{
    [SerializeField] private float _power = 5;
    
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(transform.position, transform.forward, out var hit))
            {
                var rigidbody = hit.transform.gameObject.GetComponent<Rigidbody>();

                if (rigidbody == null)
                {
                    return;
                }
                else
                {
                    rigidbody.AddForce(transform.forward * _power, ForceMode.Impulse);
                }
            }
        }

    }
}
