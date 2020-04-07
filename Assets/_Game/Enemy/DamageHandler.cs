using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageHandler : MonoBehaviour
{
    [SerializeField] private int maxHits = 12;
    private int _currentHits;
    
    // Messages
    private void OnParticleCollision(GameObject other)
    {
        print("hit");
        _currentHits += 1;
        if (_currentHits >= maxHits)
        {
            enabled = false;
            Destroy(gameObject);
        }
    }
}
