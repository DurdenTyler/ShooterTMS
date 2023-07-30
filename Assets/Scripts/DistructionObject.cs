using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistructionObject : MonoBehaviour
{
    [SerializeField] private float _hpInit = 100;

    public void ReceiveDamage(float damage)
    {
        _hpInit -= damage;

        if (_hpInit <= 0)
        {
            Destroy(gameObject);
        }
    }
}
