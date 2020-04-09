﻿using UnityEngine;

public class DamageHandler : MonoBehaviour
{
    private int _currentHits;
    [SerializeField] private int maxHits = 12;
    [SerializeField] private ParticleSystem hitVFX;
    [SerializeField] private ParticleSystem deathVFX;

    // Messages
    private void OnParticleCollision(GameObject other)
    {
        _currentHits += 1;
        var hitVFXInstance = Instantiate(hitVFX, transform);
        Destroy(hitVFXInstance.gameObject, 1f);
        
        if (_currentHits >= maxHits)
        {
            enabled = false;
            Destroy(gameObject);
            var deathVFXInstance = Instantiate(deathVFX, transform.position, transform.rotation);
            Destroy(deathVFXInstance.gameObject, 1f);
        }
    }
}