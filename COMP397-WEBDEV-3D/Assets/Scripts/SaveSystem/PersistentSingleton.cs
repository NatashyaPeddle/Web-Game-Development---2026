using UnityEngine;

public class PersistentSingleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T _instance;

    // Public property to access the instance
    public static T Instance
    {
        get
        {
            // If the instance is null, look for it
            if (_instance == null)
            {
                _instance = FindObjectOfType<T>();

                // If no instance is found, create a new one
                if (_instance == null)
                {
                    GameObject singletonObject = new GameObject(typeof(T).Name);
                    _instance = singletonObject.AddComponent<T>();
                    DontDestroyOnLoad(singletonObject); // Persist the singleton object across scenes
                }
            }

            return _instance;
        }
    }

    // Awake is called when the script is initialized
    protected virtual void Awake()
    {
        // Ensure only one instance exists, destroy duplicates
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject); // Destroy this duplicate instance
        }
        else
        {
            _instance = this as T;
            DontDestroyOnLoad(gameObject); // Keep this object across scenes
        }
    }
}