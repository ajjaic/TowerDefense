using UnityEngine;

public class Waypoint : MonoBehaviour
{
    private const int Gridsize = 10;
    private bool _isHasTower;
    [SerializeField] private IsCreateTowerEvent isCreateTowerEvent;

    public bool
        isInteractive =
            true; // TODO: interactive and non-interactive blocks should be entirely different game objects with different scripts.

    [SerializeField] private Tower tower;

    // messages
    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
            if (!IsHasTower())
                isCreateTowerEvent.RaiseEvent(this);
    }

    // API
    public void SetIsHasTower(bool s)
    {
        _isHasTower = s;
    }

    public bool IsHasTower()
    {
        return _isHasTower;
    }

    public void PlaceTower()
    {
        if (!IsHasTower())
        {
            var t = Instantiate(tower, transform);
            t.transform.position = GetWorldPos();
            SetIsHasTower(true);
        }
    }

    public void RemoveTower()
    {
        if (IsHasTower())
        {
            var t = transform.GetComponentInChildren<Tower>();
            Destroy(t.gameObject);
            SetIsHasTower(false);
        }
    }

    public Vector3 GetWorldPos()
    {
        Vector2Int xzPos = GetGridPos(); 
        
        float xPos = xzPos.x * Gridsize;
        var yPos = transform.position.y;
        float zPos = xzPos.y * Gridsize;

        return new Vector3(xPos, yPos, zPos);
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