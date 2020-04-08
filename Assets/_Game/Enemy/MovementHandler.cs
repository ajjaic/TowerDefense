using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementHandler : MonoBehaviour
{
    // API
    public void Walk(List<Waypoint> path)
    {
        StartCoroutine(Helper());

        IEnumerator Helper()
        {
            foreach (var waypoint in path)
            {
                transform.position = new Vector3(waypoint.GetWorldPos().x, transform.position.y, waypoint.GetWorldPos().y);
                yield return new WaitForSeconds(1);
            }
        }
    }
}