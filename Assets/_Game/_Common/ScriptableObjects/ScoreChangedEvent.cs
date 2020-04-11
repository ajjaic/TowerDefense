using UnityEngine;

[CreateAssetMenu]
public class ScoreChangedEvent: ScriptableObject
{
    public delegate void ScoreChangedType(int scoreDelta);

    public event ScoreChangedType ScoreChangedInstance;

    public void RaiseEvent(int scoreDelta)
    {
        ScoreChangedInstance?.Invoke(scoreDelta);
    }
}