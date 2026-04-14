using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Events/Floats Event Channel")]

public class FloatEventChannel : ScriptableObject
{
    public UnityAction<float> onEventRaised;

    public void RaiseEvents(float value)
    {
        if (onEventRaised == null) return;
        onEventRaised.Invoke(value);
    }
}
