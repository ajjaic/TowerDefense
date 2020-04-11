using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementHandler : MonoBehaviour
{
    private float destroyAtEndSec = 1;
    [SerializeField] private ParticleSystem reachedEndParticleSys;
    [SerializeField] private float moveInterval = 1;
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
                yield return new WaitForSeconds(moveInterval);
            }

            ParticleSystem p = Instantiate(reachedEndParticleSys, transform.position, transform.rotation);
            Destroy(p.gameObject, destroyAtEndSec);
            Destroy(gameObject);
        }
    }
}