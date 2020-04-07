using System;
using UnityEditor;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] private Transform objectToAimWith;
    [SerializeField] private ParticleSystem gunToShootWith;
    [SerializeField] [Range(1f, 100f)] private float detectionRange;
    private Transform _enemyParent;
    private ParticleSystem.EmissionModule _bulletEmitter;

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
            float distanceToEnemy = Vector3.Distance(child.position, transform.position);
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