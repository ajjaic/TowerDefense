using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WayPointGridMap: MonoBehaviour
{
    [SerializeField] private Movement enemyMovement;
    [SerializeField] private Transform enemyParent;
    [SerializeField] private Waypoint startWayPoint;
    [SerializeField] private Waypoint endWayPoint;
    private Dictionary<Vector2Int, Waypoint> _waypointGrid = new Dictionary<Vector2Int, Waypoint>();
    private readonly Vector2Int[] _neighborDirections = {Vector2Int.up, Vector2Int.right, Vector2Int.down, Vector2Int.left};

    // messages
    private void Start()
    {
        LoadWayPoints();
        SetStartEndColors();
        StartCoroutine(CreateEnemy());
    }

    // methods
    // TODO: why is the pathfinder creating enemies?
    private IEnumerator CreateEnemy()
    {
        while (true)
        {
            if (enemyParent.childCount < 1)
            {
                Movement e = Instantiate(enemyMovement, enemyParent);
                e.Walk(GetPathFromStartToEnd());
            }
            yield return new WaitForSeconds(3);
        }
    }
    
    private List<Waypoint> GetPathFromStartToEnd()
    {
        if (startWayPoint == endWayPoint)
            return new List<Waypoint> {startWayPoint};
        
        Queue<Waypoint> bfsQueue = new Queue<Waypoint>(new [] { startWayPoint });
        Dictionary<Waypoint, Waypoint> toFrom = new Dictionary<Waypoint, Waypoint> {[startWayPoint] = null};

        while (bfsQueue.Count > 0)
        {
            Waypoint currentWayPoint = bfsQueue.Dequeue();

            if (currentWayPoint == endWayPoint)
                break;
            
            List<Waypoint> neighborsForCurrentWaypoint = GetNeighbors(currentWayPoint);
            foreach (var neighbor in neighborsForCurrentWaypoint)
            {
                if (!toFrom.ContainsKey(neighbor))
                {
                    toFrom[neighbor] = currentWayPoint;
                    bfsQueue.Enqueue(neighbor);   
                }
            }
        }
        return AssemblePath(toFrom, startWayPoint, endWayPoint);
    }

    private List<Waypoint> AssemblePath(Dictionary<Waypoint,Waypoint> toFrom, Waypoint startPoint, Waypoint endPoint)
    {
        List<Waypoint> path = new List<Waypoint>();

        while (endPoint != null)
        {
            path.Add(endPoint);
            endPoint = toFrom[endPoint];
        }

        path.Add(startPoint);
        path.Reverse();
        return path;
    }

    private List<Waypoint> GetNeighbors(Waypoint w)
    {
        List<Waypoint> neighbors = new List<Waypoint>();
        var waypointGridPos = w.GetGridPos();
        
        foreach (Vector2Int direction in _neighborDirections)
        {
            if (_waypointGrid.ContainsKey(waypointGridPos + direction))
            {
                neighbors.Add(_waypointGrid[waypointGridPos + direction]);
            }
        }

        return neighbors;
    }

    private void SetStartEndColors()
    {
        startWayPoint.SetColor(Color.green);
        endWayPoint.SetColor(Color.red);
    }

    private void LoadWayPoints()
    {
        var interactiveWayPoints = transform.GetComponentsInChildren<Waypoint>();
        foreach (var waypoint in interactiveWayPoints)
        {
            var gridPos = waypoint.GetGridPos();
            if (_waypointGrid.ContainsKey(gridPos))
                Debug.Log("already added");
            else
                _waypointGrid.Add(gridPos, waypoint);
        }
    }
}