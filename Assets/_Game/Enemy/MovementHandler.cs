using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementHandler : MonoBehaviour
{
    [SerializeField] [Range(1f, 10f)] private float yOffset = 4;
    // API
    public void Walk(List<Waypoint> path)
    {
        StartCoroutine(Helper());

        IEnumerator Helper()
        {
            float yPos = transform.position.y + yOffset;
            foreach (var waypoint in path)
            {
                transform.position = new Vector3(waypoint.GetWorldPos().x, yPos, waypoint.GetWorldPos().y);
                yield return new WaitForSeconds(1);
            }
        }
    }
}