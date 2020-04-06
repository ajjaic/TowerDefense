using UnityEditor;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    public bool isInteractive = true;
    private const int Gridsize = 10;

    // API
    public Vector2Int GetWorldPos()
    {
        // TODO: why is Vector2Int being returned? Should it not be Vector3? After all world position are in Vector3 Units.
        return new Vector2Int(
            Mathf.RoundToInt(transform.position.x / Gridsize) * Gridsize,
            Mathf.RoundToInt(transform.position.z / Gridsize) * Gridsize
        );
    }

    public Vector2Int GetGridPos()
    {
        return new Vector2Int(
            Mathf.RoundToInt(transform.position.x / Gridsize),
            Mathf.RoundToInt(transform.position.z / Gridsize)
        );
    }

    public void SetColor(Color color)
    {
        transform.Find("Label").GetComponent<TextMesh>().color = color;
    }
}