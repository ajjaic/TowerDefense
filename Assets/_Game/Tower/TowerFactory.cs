using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : MonoBehaviour
{
    private Queue<Waypoint> _waypointsWithTowers;
    [SerializeField] private IsCreateTowerEvent isCreateTowerEvent;
    [SerializeField] private int maxTowersOnAllWaypoints = 3;

    // messages 
    private void Start()
    {
        _waypointsWithTowers = new Queue<Waypoint>(maxTowersOnAllWaypoints);
    }

    private void OnEnable()
    {
        isCreateTowerEvent.IsCreateTowerEventInstance += ProcessIsCreateTowerEvent;
    }

    private void OnDisable()
    {
        isCreateTowerEvent.IsCreateTowerEventInstance -= ProcessIsCreateTowerEvent;
    }

    // methods
    private void ProcessIsCreateTowerEvent(Waypoint w)
    {
        if (_waypointsWithTowers.Count < maxTowersOnAllWaypoints)
        {
            _waypointsWithTowers.Enqueue(w);
            w.PlaceTower();
        }
        else
        {
            var oldestWaypointWithTower = _waypointsWithTowers.Dequeue();
            oldestWaypointWithTower.RemoveTower();
            _waypointsWithTowers.Enqueue(w);
            w.PlaceTower();
        }
    }
}