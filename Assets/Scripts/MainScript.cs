using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainScript : MonoBehaviour
{
    [SerializeField] private float _power = 1;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(transform.position, transform.forward, out var hit))
            {
                print(hit.transform.gameObject.name);

                var rigidbody = hit.transform.gameObject.GetComponent<Rigidbody>();

                if (rigidbody == null)
                {
                    hit.transform.gameObject.SetActive(false);
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
