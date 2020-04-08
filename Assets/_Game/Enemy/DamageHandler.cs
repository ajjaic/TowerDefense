using UnityEngine;

public class DamageHandler : MonoBehaviour
{
    private int _currentHits;
    [SerializeField] private int maxHits = 12;

    // Messages
    private void OnParticleCollision(GameObject other)
    {
        _currentHits += 1;
        if (_currentHits >= maxHits)
        {
            enabled = false;
            Destroy(gameObject);
        }
    }
}