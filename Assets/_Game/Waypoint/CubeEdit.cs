﻿using UnityEngine;

[ExecuteInEditMode]
[SelectionBase]
[RequireComponent(typeof(Waypoint))]
public class CubeEdit : MonoBehaviour
{
    private Waypoint _waypoint;

    private void Awake()
    {
        _waypoint = GetComponent<Waypoint>();
    }

    private void Update()
    {
        SnapToGrid();
        if (_waypoint.isInteractive)
        {
            SetTopLabel();
            SetName();
        }
    }

    private void SnapToGrid()
    {
        transform.position = _waypoint.GetWorldPos();
    }

    private void SetTopLabel()
    {
        var cubePosLbl = GetComponentInChildren<TextMesh>();
        cubePosLbl.text = GetLabel();
    }

    private void SetName()
    {
        gameObject.name = GetLabel();
    }

    private string GetLabel()
    {
        var gridPos = _waypoint.GetGridPos();
        return gridPos.x + ", " + gridPos.y;
    }
}