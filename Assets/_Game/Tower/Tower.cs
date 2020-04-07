using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] private Transform objectToAimAt;
    [SerializeField] private Transform objectToAimWith;

    private void Start()
    {
        objectToAimAt = FindObjectOfType<Movement>().transform;
    }

    private void Update()
    {
        objectToAimWith.LookAt(objectToAimAt);
    }
}