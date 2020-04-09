using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFactory : MonoBehaviour
{
    [SerializeField] private float enemyCreationInterval;
    [SerializeField] private MovementHandler enemy;
    [SerializeField] private GridMapLoadedEvent gridMapLoadedEvent;

    // messages
    private void OnEnable()
    {
        gridMapLoadedEvent.GridMapLoadedInstance += OnGridMapLoaded;
    }

    private void OnDisable()
    {
        gridMapLoadedEvent.GridMapLoadedInstance -= OnGridMapLoaded;
    }

    // custom messages
    private void OnGridMapLoaded(Dictionary<Vector2Int, Waypoint> gridMap, Waypoint startWayPoint, Waypoint endWaypoint)
    {
        StartCoroutine(CreateEnemy(gridMap, startWayPoint, endWaypoint));
    }

    // methods
    private IEnumerator CreateEnemy(Dictionary<Vector2Int, Waypoint> gridMap, Waypoint startWayPoint, Waypoint endWayPoint)
    {
        var path = WayPointPathFinder.GetPathFromStartToEnd(gridMap, startWayPoint, endWayPoint);

        while (true)
        {
            var e = Instantiate(enemy, transform);
            e.Walk(path);
            yield return new WaitForSeconds(enemyCreationInterval);
        }
    }
}