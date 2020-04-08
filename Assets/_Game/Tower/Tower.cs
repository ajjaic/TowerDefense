using UnityEngine;

public class Tower : MonoBehaviour
{
    private ParticleSystem.EmissionModule _bulletEmitter;
    private Transform _enemyParent;
    [SerializeField] [Range(1f, 100f)] private float detectionRange;
    [SerializeField] private ParticleSystem gunToShootWith;
    [SerializeField] private Transform objectToAimWith;

    private void Start()
    {
        _bulletEmitter = gunToShootWith.emission;
        _bulletEmitter.enabled = false;
        _enemyParent = GameObject.Find("Enemies").GetComponent<Transform>();
    }

    private void Update()
    {
        foreach (Transform child in _enemyParent.transform)
        {
            var distanceToEnemy = Vector3.Distance(child.position, transform.position);
            if (distanceToEnemy < detectionRange)
            {
                Shoot(child);
                return;
            }
        }

        _bulletEmitter.enabled = false;
    }

    private void Shoot(Transform child)
    {
        objectToAimWith.LookAt(child);
        _bulletEmitter.enabled = true;
    }
}