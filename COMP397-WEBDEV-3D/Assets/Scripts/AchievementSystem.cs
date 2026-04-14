using Unity.Android.Gradle.Manifest;
using UnityEngine;

public class AchievementSystem : MonoBehaviour
{

    // Start is called once before the first execution of Update after the MonoBehaviour is created

    [SerializeField] private VoidEventChannel voidChannel;
    [SerializeField] private GameDataEventChannel gameDataChannel;
    [SerializeField] private FloatEventChannel floatChannel;

    private int achievementJumps = 10;
    private int currentJumps = 0;

    private void OnEnable()
    {
        voidChannel.OnEventRaised += EventCalled;
        gameDataChannel.OnEventRaised += GameDataEventCalled;

    }

    // Update is called once per frame
    private void OnDisable()
    {
        voidChannel.OnEventRaised -= EventCalled;
        gameDataChannel.OnEventRaised-= GameDataEventCalled;
    }

    private void EventCalled()
    {
        Debug.Log("Event called by listening to the event channel of the void type");

        currentJumps++;
        if(currentJumps >= achievementJumps)
        {
            Debug.Log("Achievement Compelted: Jumped 10 times");
        }
    }

    private void GameDataEventCalled (GameData data)
    {
        Debug.Log("Event with GameData data passed on with filename as " + data.fileName);
    }

}
