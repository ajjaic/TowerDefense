using System.Collections.Generic;
using UnityEngine;

public class WayPointPathFinder
{
    private static readonly Vector2Int[] NeighborDirections = {Vector2Int.up, Vector2Int.right, Vector2Int.down, Vector2Int.left};

    public static List<Waypoint> GetPathFromStartToEnd(Dictionary<Vector2Int, Waypoint> gridMap, Waypoint startWayPoint, Waypoint endWayPoint)
    {
        if (startWayPoint == endWayPoint)
            return new List<Waypoint> {startWayPoint};

        var bfsQueue = new Queue<Waypoint>(new[] {startWayPoint});
        var toFrom = new Dictionary<Waypoint, Waypoint> {[startWayPoint] = null};

        while (bfsQueue.Count > 0)
        {
            var currentWayPoint = bfsQueue.Dequeue();

            if (currentWayPoint == endWayPoint)
                break;

            var neighborsForCurrentWaypoint = GetNeighbors(gridMap, currentWayPoint);
            foreach (var neighbor in neighborsForCurrentWaypoint)
                if (!toFrom.ContainsKey(neighbor))
                {
                    toFrom[neighbor] = currentWayPoint;
                    bfsQueue.Enqueue(neighbor);
                }
        }

        return AssemblePath(toFrom, startWayPoint, endWayPoint);
    }

    private static List<Waypoint> AssemblePath(Dictionary<Waypoint, Waypoint> toFrom, Waypoint startPoint, Waypoint endPoint)
    {
        var path = new List<Waypoint>();

        while (endPoint != null)
        {
            endPoint.SetIsPlaceable(false);
            path.Add(endPoint);
            endPoint = toFrom[endPoint];
        }

        path.Add(startPoint);
        path.Reverse();
        return path;
    }

    private static List<Waypoint> GetNeighbors(Dictionary<Vector2Int, Waypoint> gridMap, Waypoint w)
    {
        var neighbors = new List<Waypoint>();
        var waypointGridPos = w.GetGridPos();

        foreach (var direction in NeighborDirections)
            if (gridMap.ContainsKey(waypointGridPos + direction))
                neighbors.Add(gridMap[waypointGridPos + direction]);
        return neighbors;
    }
}