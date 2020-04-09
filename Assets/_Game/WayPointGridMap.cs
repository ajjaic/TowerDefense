using System.Collections.Generic;
using UnityEngine;

public class WayPointGridMap : MonoBehaviour
{
    private readonly Dictionary<Vector2Int, Waypoint> _waypointGrid = new Dictionary<Vector2Int, Waypoint>();
    [SerializeField] private Waypoint endWayPoint;
    [SerializeField] private GridMapLoadedEvent gridMapLoadedEvent;
    [SerializeField] private Waypoint startWayPoint;

    // messages
    private void Start()
    {
        LoadWayPoints();
        SetStartEndColors();
        gridMapLoadedEvent.RaiseEvent(_waypointGrid, startWayPoint, endWayPoint);
    }

    // methods
    private void SetStartEndColors()
    {
        startWayPoint.SetColor(Color.green);
        endWayPoint.SetColor(Color.red);
    }

    /*
     * Finds all the waypoints that are a part of the grid and stores in dictionary
     */
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