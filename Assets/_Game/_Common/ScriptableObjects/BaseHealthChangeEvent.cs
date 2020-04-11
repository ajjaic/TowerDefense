using UnityEngine;

[CreateAssetMenu]
public class BaseHealthChangeEvent: ScriptableObject
{
    public delegate void BaseHealthChangeType(int newHealth);

    public event BaseHealthChangeType BaseHealthChangeInstance;

    public void RaiseEvent(int newHealth)
    {
        BaseHealthChangeInstance?.Invoke(newHealth);
    }
}