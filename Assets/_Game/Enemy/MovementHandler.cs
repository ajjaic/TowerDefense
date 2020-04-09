using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementHandler : MonoBehaviour
{
    [SerializeField] private Vector3 yOffset = new Vector3(0f, 4f, 0f);

    // API
    public void Walk(List<Waypoint> path)
    {
        StartCoroutine(Helper());

        IEnumerator Helper()
        {
            foreach (var waypoint in path)
            {
                transform.position = waypoint.GetWorldPos() + yOffset;
                yield return new WaitForSeconds(1);
            }
        }
    }
}