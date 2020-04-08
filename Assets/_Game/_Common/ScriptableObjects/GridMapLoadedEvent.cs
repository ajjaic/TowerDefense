using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class GridMapLoadedEvent : ScriptableObject
{
    public delegate void GridMapLoadedType(Dictionary<Vector2Int, Waypoint> gridMap, Waypoint startWayPoint,
        Waypoint endWayPoint);

    public event GridMapLoadedType GridMapLoadedInstance;

    public void RaiseEvent(Dictionary<Vector2Int, Waypoint> gridMap, Waypoint startWayPoint, Waypoint endWayPoint)
    {
        GridMapLoadedInstance?.Invoke(gridMap, startWayPoint, endWayPoint);
    }
}