using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] private Transform objectToAimAt;
    [SerializeField] private Transform objectToAimWith;

    private void Start()
    {
        objectToAimAt = FindObjectOfType<EnemyMovement>().transform;
    }

    private void Update()
    {
        objectToAimWith.LookAt(objectToAimAt);
    }
}