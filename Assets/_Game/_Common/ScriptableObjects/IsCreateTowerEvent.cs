using UnityEngine;

[CreateAssetMenu]
public class IsCreateTowerEvent : ScriptableObject
{
    public delegate void IsCreateTowerEventType(Waypoint w);

    public event IsCreateTowerEventType IsCreateTowerEventInstance;

    public void RaiseEvent(Waypoint w)
    {
        IsCreateTowerEventInstance?.Invoke(w);
    }
}